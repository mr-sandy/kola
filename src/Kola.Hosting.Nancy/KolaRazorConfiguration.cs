﻿using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy
{
    public class KolaRazorConfiguration : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            return new[] { "Sample.Plugin", "Kola.Hosting.Nancy" };
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            return new[] { "Sample.Plugin", "Kola.Hosting.Nancy", "Kola.Hosting.Nancy.Extensions" };
        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}
