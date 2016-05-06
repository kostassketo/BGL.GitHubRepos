using System.Reflection;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace BGL.GitHubRepos.IoC
{
    public static class GplDependencyResolver
    {
        internal static IWindsorContainer Container { get; private set; }

        internal static Assembly CallingAssembly { get; private set; }

        public static void Register(Assembly callingAssembly)
        {
            Register(callingAssembly, null);
        }

        public static IControllerFactory CreateControllerFactory()
        {
            return new GplControllerFactory(Container.Kernel);
        }

        public static IHttpControllerActivator CreateApiControllerActivator()
        {
            return new GplApiControllerActivator(Container);
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static void DisposeContainer()
        {
            Container.Dispose();
        }

        internal static void Register(Assembly callingAssembly, ComponentModelDelegate componentModelDelegate)
        {
            CallingAssembly = callingAssembly;

            var container = new WindsorContainer();
            // This allows you to inject all implementations of a certain interface
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));
            container.Install(FromAssembly.This(new GplInstallerFactory()));
            Container = container;
        }
    }
}
