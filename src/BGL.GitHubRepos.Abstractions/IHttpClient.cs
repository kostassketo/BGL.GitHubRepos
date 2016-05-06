using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGL.GitHubRepos.Abstractions
{
    public interface IHttpClient
    {
        Dictionary<string, string> HttpHeaders { get; set; }

        Task<T> GetAsync<T>(string baseUrl);
    }
}
