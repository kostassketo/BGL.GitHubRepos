using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BGL.GitHubRepos.IoC.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container == null)
            {
                return;
            }

            var assembly = GplDependencyResolver.CallingAssembly;
            container.Register(Classes.FromAssembly(assembly).InNamespace("BGL.GitHubRepos.Website.Controllers").LifestyleTransient());
            container.Register(Classes.FromAssembly(assembly).BasedOn<IController>().LifestyleTransient());
        }
    }
}
