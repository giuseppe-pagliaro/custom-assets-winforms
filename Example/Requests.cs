using RestClient;

namespace Example
{
    public static class Requests
    {
        static Requests()
        {
            String UNIS_BY_COUNTRY_BASE_URL = "http://universities.hipolabs.com";

            SEARCH_UNIS_BY_COUNTRY = new (UNIS_BY_COUNTRY_BASE_URL, "/search", new Arg[] { new("country") },
                "{\"mode\": \"Test\"}");
        }

        public static readonly Request SEARCH_UNIS_BY_COUNTRY;
    }
}