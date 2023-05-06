namespace RestClient
{
    public class Request
    {
        public Request()
        {
            baseUrl = "localhost:8080";
            path = "/";
            args = Array.Empty<Arg>();
            numVariableArgs = 0;
            testResult = "{}";
        }

        public Request(String baseUrl, String path, String testResult)
        {
            this.baseUrl = baseUrl;
            this.path = path;
            args = Array.Empty<Arg>();
            numVariableArgs = 0;
            this.testResult = testResult;
        }

        public Request(String baseUrl, String path, Arg[] args, String testResult)
        {
            this.baseUrl = baseUrl;
            this.path = path;
            this.args = args;
            numVariableArgs = CountVariableArgs(this.args);
            this.testResult = testResult;
        }

        private String baseUrl;
        private String path;
        private Arg[] args;
        private String testResult;

        private int numVariableArgs;

        public String TestResult
        {
            get { return testResult; }
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
            if (argValues.Length != numVariableArgs)
            {
                throw new ArgValuesNumberMismatchException();
            }

            if (args.Length == 0)
            {
                return baseUrl + path;
            }

            int indArgValues = 0;
            String formattedArgs = "";

            if (args[0].isVariable)
            {
                formattedArgs = "?" + args[0].GetFormatted(argValues[0]);
                indArgValues++;
            }
            else
            {
                formattedArgs = "?" + args[0].GetFormatted();
            }

            for (int i = 1; i < numVariableArgs; i++)
            {
                if (args[0].isVariable)
                {
                    formattedArgs = "&" + args[0].GetFormatted(argValues[indArgValues]);
                    indArgValues++;
                }
                else
                {
                    formattedArgs = "&" + args[0].GetFormatted();
                }
            }

            return baseUrl + path + formattedArgs;
        }
    }

    public class ArgValuesNumberMismatchException : Exception
    {
        public ArgValuesNumberMismatchException()
            : base("The number of argValues provided does not match the number of variable args.") { }
    }
}