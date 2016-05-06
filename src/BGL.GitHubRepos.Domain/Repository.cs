using Newtonsoft.Json;

namespace BGL.GitHubRepos.Domain
{
    public class Repository
    {
        public string Name { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("stargazers_count")]
        public int StarGazersCount { get; set; }
    }
}
