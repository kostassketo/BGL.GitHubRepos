using System;
using System.Collections.Generic;
using Castle.Windsor.Installer;

namespace BGL.GitHubRepos.IoC
{
    public class GplInstallerFactory : InstallerFactory
    {
        public override IEnumerable<Type> Select(IEnumerable<Type> installerTypes)
        {
            return installerTypes;
        }
    }
}
