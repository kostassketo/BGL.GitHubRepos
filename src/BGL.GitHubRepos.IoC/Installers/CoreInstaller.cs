using BGL.GitHubRepos.Abstractions;
using BGL.GitHubRepos.Business;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BGL.GitHubRepos.IoC.Installers
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container == null)
            {
                return;
            }

            container.Register(Component.For<IHttpClient>().ImplementedBy<GplHttpClient>());
        }
    }
}
