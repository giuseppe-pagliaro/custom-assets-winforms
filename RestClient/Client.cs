namespace RestClient
{
    // TODO make singleton
    public class Client
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private HttpResponseMessage? httpResponseMessage;
        private String? url;

        public String Url
        {
            get
            {
                if (url is null)
                {
                    return "(URL is Null)";
                }
                else
                {
                    return url;
                }
            }
            set { url = value; }
        }

        private String GetFullUrl(String route, String[] args)
        {
            if (args.Length == 0)
            {
                return this.url + route;
            }

            String formattedArgs = "?" + args[0];
            for (int i = 1; i < args.Length; i++)
            {
                formattedArgs += "&" + args[i];
            }

            return this.url + route + formattedArgs;
        }

        public async Task<String> MakeRequest(String route, String[] args)
        {
            if (url is null)
            {
                return "(URL is Null)";
            }

            String fullUrl = GetFullUrl(route, args);

            try
            {
                this.httpResponseMessage = await httpClient.GetAsync(fullUrl);
                this.httpResponseMessage.EnsureSuccessStatusCode();
                return await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                return "(Failed: " + e.Message + ")";
            }
        }
    }
}