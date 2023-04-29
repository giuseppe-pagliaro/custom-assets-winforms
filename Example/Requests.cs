using RestClient;
using System;

namespace Example
{
    // TODO turn into singleton? This way we can have a constructor and declare the helper objs in there.
    // They wouldn't be kept in memory.
    public static class Requests
    {
        #region Helper Objects

        private static String GOOGLE_BASE_URL = "https://www.google.com";
        private static String LOCALHOST_BASE_URL = "localhost:8080";

        private static String JSON_TEST_GET_LISTITEMS = "{\"items\":[{\"id\":1,\"value\":\"Ciao\"},{\"" +
            "id\":2,\"value\":\"Ciao\"},{\"id\":3,\"value\":\"Ciao\"},{\"id\":4,\"value\":\"Ciao\"}," +
            "{\"id\":5,\"value\":\"Ciao\"},{\"id\": 6,\"value\":\"Ciao\"},{\"id\":7,\"value\":\"Ciao\"}," +
            "{\"id\":8,\"value\":\"Ciao\"},{\"id\": 9,\"value\":\"Ciao\"},{\"id\":10,\"value\":\"Ciao\"}]}";

        #endregion

        public static readonly Request SEARCH_FIRST_RESULT = new Request(GOOGLE_BASE_URL, "/search",
            new string[] {"q=ciao", "num=1"}, "{\"mode\": \"Test\"}");

        public static readonly Request GET_LISTITEMS = new(LOCALHOST_BASE_URL, "/",
            Array.Empty<String>(), JSON_TEST_GET_LISTITEMS);
    }
}