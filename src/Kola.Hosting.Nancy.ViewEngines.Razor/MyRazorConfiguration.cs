using System;
using System.Collections.Generic;
using Nancy.TinyIoc;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy.ViewEngines.Razor
{
    public static class Bootstrapper
    {
        static Bootstrapper()
        {
            ViewEngineStuff.RegisterIocBootstrapper(c => c.Register<IRazorConfiguration, MyRazorConfiguration>());
        }
    }

    public class MyRazorConfiguration : IRazorConfiguration
    {
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
