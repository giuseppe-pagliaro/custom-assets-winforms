using RestClient;

namespace Example
{
    public static class Requests
    {
        static Requests()
        {
            String GOOGLE_BASE_URL = "https://www.google.com";
            String LOCALHOST_BASE_URL = "http://localhost:8080";
            String JSON_TEST_GET_LISTITEMS = "{\"items\":[{\"id\":1,\"value\":\"Ciao\"},{\"" +
            "id\":2,\"value\":\"Ciao\"},{\"id\":3,\"value\":\"Ciao\"},{\"id\":4,\"value\":\"Ciao\"}," +
            "{\"id\":5,\"value\":\"Ciao\"},{\"id\": 6,\"value\":\"Ciao\"},{\"id\":7,\"value\":\"Ciao\"}," +
            "{\"id\":8,\"value\":\"Ciao\"},{\"id\": 9,\"value\":\"Ciao\"},{\"id\":10,\"value\":\"Ciao\"}]}";

            SEARCH_FIRST_RESULT = new Request(GOOGLE_BASE_URL, "/search", new Arg[] { new("q"),
                new("num", "1") }, "{\"mode\": \"Test\"}");

            GET_LISTITEMS = new(LOCALHOST_BASE_URL, "/", JSON_TEST_GET_LISTITEMS);
        }

        public static readonly Request SEARCH_FIRST_RESULT;

        public static readonly Request GET_LISTITEMS;
    }
}