using BGL.GitHubRepos.Abstractions;
using BGL.GitHubRepos.Business;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BGL.GitHubRepos.IoC.Installers
{
    public class SettingsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container == null)
            {
                return;
            }

            container.Register(Component.For<IWebSettings>().ImplementedBy<WebSettings>());
        }
    }
}
