using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BGL.GitHubRepos.Abstractions;
using Newtonsoft.Json;

namespace BGL.GitHubRepos.Business
{
    public class GplHttpClient : IHttpClient
    {
        public Dictionary<string, string> HttpHeaders { get; set; }

        public GplHttpClient()
        {
            HttpHeaders = new Dictionary<string, string>();
        }

        public async Task<T> GetAsync<T>(string baseUrl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                foreach (var httpHeader in HttpHeaders)
                {
                    client.DefaultRequestHeaders.Add(httpHeader.Key, httpHeader.Value);
                }

                var results = await client.GetAsync(baseUrl).Result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(results);
            }
        }
    }
}
