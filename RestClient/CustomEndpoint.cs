using Newtonsoft.Json;
using System.Net;
using CustomLists;

namespace RestClient
{
    public class CustomEndpoint<T> where T : ItemDatas
    {
        public CustomEndpoint(String url, T[] jsonTestResult)
        {
            this.url = url;
            this.jsonTestResult = jsonTestResult;
            mode = EndpointMode.Live;
        }

        private static readonly System.Net.Http.HttpClient client = new(
            new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(1)});

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
            for (int i = 1; i < formattedArgs.Length; i++)
            {
                formattedArgs += "&" + args[i].GetFormatted();
            }

            var result = client.GetAsync(url + formattedArgs).Result;
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

            String jsonNewObj = JsonConvert.SerializeObject(newObj);
            StringContent payload = new(jsonNewObj, System.Text.Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, payload).Result;
            lastStatusCode = result.StatusCode;
            result.EnsureSuccessStatusCode();
            T? desResult = JsonConvert.DeserializeObject<T>(result.Content.ReadAsStringAsync().Result);

            if (desResult is null)
            {
                return Activator.CreateInstance<T>();
            }
            return desResult;
        }

        public T Put(T newObj)
        {
            if (mode == EndpointMode.Test)
            {
                lastStatusCode = HttpStatusCode.OK;
                return jsonTestResult[0];
            }

            return Activator.CreateInstance<T>(); // TODO
        }

        public T Patch()
        {
            if (mode == EndpointMode.Test)
            {
                lastStatusCode = HttpStatusCode.OK;
                return jsonTestResult[0];
            }

            return Activator.CreateInstance<T>(); // TODO
        }

        public void Delete(int id)
        {
            if (mode == EndpointMode.Test)
            {
                lastStatusCode = HttpStatusCode.OK;
            }
            else
            {
                lastStatusCode = client.DeleteAsync(url + "?id=" + id).Result.StatusCode;
            }   
        }
    }

    public enum EndpointMode
    {
        Live,
        Test
    }
}