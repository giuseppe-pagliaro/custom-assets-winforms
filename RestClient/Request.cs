namespace RestClient
{
    public class Request
    {
        public Request()
        {
            this.baseUrl = "localhost:8080";
            this.path = "/";
            this.args = Array.Empty<Arg>();
            this.numVariableArgs = 0;
            this.jsonTestResult = "{}";
        }

        public Request(String baseUrl, String path, String jsonTestResult)
        {
            this.baseUrl = baseUrl;
            this.path = path;
            this.args = Array.Empty<Arg>();
            this.numVariableArgs = 0;
            this.jsonTestResult = jsonTestResult;
        }

        public Request(String baseUrl, String path, Arg[] args, String jsonTestResult)
        {
            this.baseUrl = baseUrl;
            this.path = path;
            this.args = args;
            this.numVariableArgs = CountVariableArgs(this.args);
            this.jsonTestResult = jsonTestResult;
        }

        private String baseUrl;
        private String path;
        private Arg[] args;
        private String jsonTestResult;

        private int numVariableArgs;

        public String JsonTestResult
        {
            get { return jsonTestResult; }
        }

        private static int CountVariableArgs(Arg[] args)
        {
            int count = 0;

            foreach (Arg arg in args)
            {
                if (arg.isVariable)
                {
                    count++;
                }
            }

            return count;
        }

        public String GetFullUrl(String[] argValues)
        {
            if (argValues.Length != this.numVariableArgs)
            {
                throw new ArgValuesNumberMismatchException();
            }

            if (this.args.Length == 0)
            {
                return this.baseUrl + this.path;
            }

            int indArgValues = 0;
            String formattedArgs = "";

            if (this.args[0].isVariable)
            {
                formattedArgs = "?" + args[0].GetFormatted(argValues[0]);
                indArgValues++;
            }
            else
            {
                formattedArgs = "?" + args[0].GetFormatted();
            }

            for (int i = 1; i < this.args.Length; i++)
            {
                if (this.args[0].isVariable)
                {
                    formattedArgs = "&" + args[0].GetFormatted(argValues[indArgValues]);
                    indArgValues++;
                }
                else
                {
                    formattedArgs = "&" + args[0].GetFormatted();
                }
            }

            return this.baseUrl + this.path + formattedArgs;
        }
    }

    public class ArgValuesNumberMismatchException : Exception
    {
        public ArgValuesNumberMismatchException()
            : base("The number of argValues provided does not match the number of variable args.") { }
    }
}