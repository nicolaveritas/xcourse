using System;
using System.Threading.Tasks;
using System.Net.Http;
namespace FormsSample
{
    public static class RestService
    {

        private static string _baseUrl = "https://jsonplaceholder.typicode.com/posts/";

        public static async Task<HttpResponseMessage> GetAllPosts() {
            using (var client = new HttpClient()) {
                var response = await client.GetAsync(_baseUrl);
                return response;
            }
        }
    }
}
