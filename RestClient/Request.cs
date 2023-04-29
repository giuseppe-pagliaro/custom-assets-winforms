namespace RestClient
{
    public class Request
    {
        public Request()
        {
            baseUrl = "localhost:8080";
            path = "/";
            args = new string[0];
            jsonTestResult = "{}";
        }

        public Request(string baseUrl, string path, string[] args, string jsonTestResult)
        {
            this.baseUrl = baseUrl;
            this.path = path;
            this.args = args;
            this.jsonTestResult = jsonTestResult;
        }

        private String baseUrl;
        private String path;
        private String[] args;
        private String jsonTestResult;

        public String BaseUrl
        {
            get { return baseUrl; }
        }

        public String Path
        {
            get { return path; }
        }

        public String[] Args
        {
            get { return args; }
        }

        public String FullUrl
        {
            get
            {
                if (this.args.Length == 0)
                {
                    return this.baseUrl + this.path;
                }

                String formattedArgs = "?" + args[0];
                for (int i = 1; i < args.Length; i++)
                {
                    formattedArgs += "&" + args[i];
                }

                return this.baseUrl + this.path + formattedArgs;
            }
        }

        public String JsonTestResult
        {
            get { return jsonTestResult; }
        }
    }
}