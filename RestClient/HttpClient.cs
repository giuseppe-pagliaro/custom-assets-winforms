namespace RestClient
{
    public static class HttpClient
    {
        private static readonly System.Net.Http.HttpClient httpClient = new();
        private static HttpResponseMessage? httpResponseMessage;
        private static ClientMode mode = ClientMode.Live;

        public static ClientMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public static async Task<String> MakeRequest(Request request, String[] argValues)
        {
            if (mode == ClientMode.Test)
            {
                return request.TestResult;
            }

            try
            {
                httpResponseMessage = await httpClient.GetAsync(request.GetFullUrl(argValues));
                httpResponseMessage.EnsureSuccessStatusCode();
                return await httpResponseMessage.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                return "(Failed: " + e.Message + ")";
            }
        }
    }

    public enum ClientMode
    {
        Live,
        Test
    }
}