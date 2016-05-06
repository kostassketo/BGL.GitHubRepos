using System.Threading.Tasks;
using System.Web.Http;
using BGL.GitHubRepos.Abstractions;
using BGL.GitHubRepos.Domain;

namespace BGL.GitHubRepos.Website.Controllers
{
    public class GitRepositoriesController : ApiController
    {
        private readonly IGitHubManager _gitHubManager;
        private readonly IWebSettings _webSettings;

        public GitRepositoriesController(IGitHubManager gitHubManager, IWebSettings webSettings)
        {
            _gitHubManager = gitHubManager;
            _webSettings = webSettings;
        }

        public async Task<User> Get(string userName)
        {
            _gitHubManager.UserAgent = Request.Headers.UserAgent.ToString();
            return await _gitHubManager.GetUserAsync(string.Format(_webSettings.GitHubUsersUrl, userName));
        }
    }
}
