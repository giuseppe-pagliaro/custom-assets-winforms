using RestClient;

namespace Example
{
    public static class Endpoints
    {
        static Endpoints()
        {
            UnisSearchResult[] SearchUnisTestResult = { new(), new() };

            SearchUnisTestResult[0].Id = 1;
            SearchUnisTestResult[0].WebPages = new[] { "http://www.angelicum.org/" };
            SearchUnisTestResult[0].Domains = new[] { "angelicum.org" };
            SearchUnisTestResult[0].Country = "Italy";
            SearchUnisTestResult[0].Name = "Pontificia Università S. Tommaso";
            SearchUnisTestResult[0].StateOrProvince = "Lazio";
            SearchUnisTestResult[0].AlphaTwoCode = "IT";

            SearchUnisTestResult[1].Id = 1;
            SearchUnisTestResult[1].WebPages = new[] { "http://www.antonianum.ofm.org/" };
            SearchUnisTestResult[1].Domains = new[] { "antonianum.ofm.org" };
            SearchUnisTestResult[1].Country = "Italy";
            SearchUnisTestResult[1].Name = "Pontificio Ateneo Antonianum";
            SearchUnisTestResult[1].StateOrProvince = "Lazio";
            SearchUnisTestResult[1].AlphaTwoCode = "IT";

            SEARCH_UNIS_BY_COUNTRY = new("http://universities.hipolabs.com", SearchUnisTestResult);
        }

        public static readonly CustomEndpoint<UnisSearchResult> SEARCH_UNIS_BY_COUNTRY;
    }
}