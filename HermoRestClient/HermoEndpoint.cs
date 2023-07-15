using HermoCommons;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace HermoRestClient
{
    public class HermoEndpoint<T> where T : ItemDatas
    {
        public HermoEndpoint(String url, T[] jsonTestResult)
        {
            this.url = url;
            this.jsonTestResult = jsonTestResult;
            mode = EndpointMode.Live;
            lastStatusCode = HttpStatusCode.OK;
        }

        private static readonly HttpClient client = new(new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(1) });

        private String url;
        private T[] jsonTestResult;
        private EndpointMode mode;
        private HttpStatusCode lastStatusCode;

        public EndpointMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public HttpStatusCode LastStatusCode
        {
            get { return lastStatusCode; }
        }

        public T[] Get(Arg[] args)
        {
            if (mode == EndpointMode.Test)
            {
                lastStatusCode = HttpStatusCode.OK;
                return jsonTestResult;
            }

            String formattedArgs = "?" + args[0].GetFormatted();
            for (int i = 1; i < args.Length; i++)
            {
                formattedArgs += "&" + args[i].GetFormatted();
            }

            HttpResponseMessage result = client.GetAsync(url + formattedArgs).Result;
            lastStatusCode = result.StatusCode;
            result.EnsureSuccessStatusCode();
            T[]? desResult = JsonConvert.DeserializeObject<T[]>(result.Content.ReadAsStringAsync().Result);

            if (desResult is null)
            {
                return Array.Empty<T>();
            }
            return desResult;
        }

        public T Post(T newObj)
        {
            if (mode == EndpointMode.Test)
            {
                lastStatusCode = HttpStatusCode.OK;
                return jsonTestResult[0];
            }

            String jsonNewObj = JsonConvert.SerializeObject(newObj, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new PostRequestContractResolver() });
            StringContent payload = new(jsonNewObj, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage result = client.PostAsync(url, payload).Result;
            lastStatusCode = result.StatusCode;
            result.EnsureSuccessStatusCode();
            T? desResult = JsonConvert.DeserializeObject<T>(result.Content.ReadAsStringAsync().Result);

            if (desResult is null)
            {
                return Activator.CreateInstance<T>();
            }
            return desResult;
        }

        public T Put(T modObj)
        {
            if (mode == EndpointMode.Test)
            {
                lastStatusCode = HttpStatusCode.OK;
                return jsonTestResult[0];
            }

            String jsonModObj = JsonConvert.SerializeObject(modObj);
            StringContent payload = new(jsonModObj, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage result = client.PutAsync(url, payload).Result;
            lastStatusCode = result.StatusCode;
            result.EnsureSuccessStatusCode();
            T? desResult = JsonConvert.DeserializeObject<T>(result.Content.ReadAsStringAsync().Result);

            if (desResult is null)
            {
                return Activator.CreateInstance<T>();
            }
            return desResult;
        }

        public T Patch(T oldObj, T modObj, IdPassingMode idPassingMode)
        {
            if (mode == EndpointMode.Test)
            {
                lastStatusCode = HttpStatusCode.OK;
                return jsonTestResult[0];
            }

            bool allDifferent = true;
            PropertyInfo[] properties = oldObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.Name != "Id").ToArray();
            bool[] includeProperties = new bool[properties.Length];
            int i = 0;
            foreach (PropertyInfo property in properties)
            {
                object? oldPropValue = property.GetValue(oldObj);
                if (oldPropValue is not null)
                {
                    includeProperties[i] = !oldPropValue.Equals(property.GetValue(modObj));
                    if (!includeProperties[i])
                    {
                        allDifferent = false;
                    }
                }
                else
                {
                    if (property.GetValue(modObj) is null)
                    {
                        includeProperties[i] = false;
                        allDifferent = false;
                    }
                    else
                    {
                        includeProperties[i] = true;
                    }
                }

                i++;
            }

            if (allDifferent) return Put(modObj);

            String jsonModObj = JsonConvert.SerializeObject(modObj, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new PatchRequestContractResolver(includeProperties) });
            StringContent payload = new(jsonModObj, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage result;
            if (idPassingMode == IdPassingMode.Parameter)
            {
                result = client.PatchAsync(url + "?id=" + oldObj.Id, payload).Result;
            }
            else
            {
                result = client.PatchAsync(url + "/" + oldObj.Id, payload).Result;
            }

            lastStatusCode = result.StatusCode;
            result.EnsureSuccessStatusCode();
            T? desResult = JsonConvert.DeserializeObject<T>(result.Content.ReadAsStringAsync().Result);

            if (desResult is null)
            {
                return Activator.CreateInstance<T>();
            }
            return desResult;
        }

        public void Delete(int id, IdPassingMode idPassingMode)
        {
            if (mode == EndpointMode.Test)
            {
                lastStatusCode = HttpStatusCode.OK;
            }
            else
            {
                if (idPassingMode == IdPassingMode.Parameter)
                {
                    lastStatusCode = client.DeleteAsync(url + "?id=" + id).Result.StatusCode;
                }
                else
                {
                    lastStatusCode = client.DeleteAsync(url + "/" + id).Result.StatusCode;
                }
            }
        }
    }

    public enum EndpointMode
    {
        Live,
        Test
    }

    public enum IdPassingMode
    {
        Parameter,
        Path
    }
}