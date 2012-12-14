using System.Collections.Generic;
using Kola.Configuration.Ideas;
using Nancy.TinyIoc;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy
{
    public class KolaRazorConfiguration : IRazorConfiguration
    {
        private readonly KolaConfiguration kolaConfiguration;

        public KolaRazorConfiguration(KolaConfiguration kolaConfiguration)
        {
            this.kolaConfiguration = kolaConfiguration;
        }

        public IEnumerable<string> GetAssemblyNames()
        {
            return new[] { "Sample.Host", "Linn.Cms.Service" };
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            return new[] { "Linn.Cms.Core.Extensions" };
        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}
