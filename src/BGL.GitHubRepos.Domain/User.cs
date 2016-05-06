using System.Collections.Generic;
using Newtonsoft.Json;

namespace BGL.GitHubRepos.Domain
{
    public class User
    {
        public User()
        {
            Repositories = new List<Repository>();
        }

        public string Login { get; set; }

        public string Location { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("repos_url")]
        public string ReposUrl { get; set; }

        public IEnumerable<Repository> Repositories { get; set; }
    }
}
