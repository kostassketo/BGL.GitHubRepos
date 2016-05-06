using System.Threading.Tasks;
using BGL.GitHubRepos.Domain;

namespace BGL.GitHubRepos.Abstractions
{
    public interface IGitHubManager
    {
        string UserAgent { get; set; }

        Task<User> GetUserAsync(string login);
    }
}
