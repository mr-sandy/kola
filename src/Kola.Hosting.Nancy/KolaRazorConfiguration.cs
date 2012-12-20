using System.Collections.Generic;
using System.Linq;
using Kola.Configuration.Ideas;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy
{
    public class KolaRazorConfiguration : IRazorConfiguration
    {
        private readonly KolaHostConfiguration kolaConfiguration;

        public KolaRazorConfiguration(KolaHostConfiguration kolaConfiguration)
        {
            this.kolaConfiguration = kolaConfiguration;
        }

        public IEnumerable<string> GetAssemblyNames()
        {
            return this.kolaConfiguration.AssemblyNames.Union(new[] { "Kola.Hosting.Nancy" });
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            return new[] { "Kola.Hosting.Nancy", "Kola.Hosting.Nancy.Extensions" };
        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}
