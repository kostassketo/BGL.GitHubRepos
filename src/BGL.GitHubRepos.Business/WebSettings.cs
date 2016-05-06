using System.Configuration;
using BGL.GitHubRepos.Abstractions;

namespace BGL.GitHubRepos.Business
{
    public class WebSettings : IWebSettings
    {
        public string GitHubUsersUrl
        {
            get { return ConfigurationManager.AppSettings["api.GitHub.Users.Url"]; }
        }
    }
}
