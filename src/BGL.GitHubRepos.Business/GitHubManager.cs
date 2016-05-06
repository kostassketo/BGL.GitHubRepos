using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGL.GitHubRepos.Abstractions;
using BGL.GitHubRepos.Domain;

namespace BGL.GitHubRepos.Business
{
    public class GitHubManager : IGitHubManager
    {
        private readonly IHttpClient _httpClient;

        public string UserAgent { get; set; }

        public GitHubManager(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> GetUserAsync(string login)
        {
            if (!_httpClient.HttpHeaders.ContainsKey(HttpHeaders.UserAgent))
            {
                // https://developer.github.com/v3/#user-agent-required
                _httpClient.HttpHeaders.Add(HttpHeaders.UserAgent, UserAgent);
            }

            var user = await _httpClient.GetAsync<User>(login);

            if (user != null)
            {
                var repositories = await _httpClient.GetAsync<List<Repository>>(user.ReposUrl);
                user.Repositories = repositories.OrderByDescending(x => x.StarGazersCount).Take(5);
            }

            return user;
        }
    }
}
