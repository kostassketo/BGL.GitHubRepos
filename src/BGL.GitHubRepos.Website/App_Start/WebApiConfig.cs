using System.Web.Http;

namespace BGL.GitHubRepos.Website
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                        "Api.GitRepositories",
                        "api/gitrepositories/{userName}",
                        new { controller = "GitRepositories", @namespace = "Api" });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
