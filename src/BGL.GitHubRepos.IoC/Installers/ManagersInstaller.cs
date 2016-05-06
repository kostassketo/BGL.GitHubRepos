using BGL.GitHubRepos.Abstractions;
using BGL.GitHubRepos.Business;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BGL.GitHubRepos.IoC.Installers
{
    public class ManagersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container == null)
            {
                return;
            }

            container.Register(Component.For<IGitHubManager>().ImplementedBy<GitHubManager>());
        }
    }
}
