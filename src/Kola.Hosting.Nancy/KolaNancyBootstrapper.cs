using System;
using System.Collections.Generic;
using Kola.Configuration.Ideas;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.ViewEngines;
using Nancy.ViewEngines.Razor;

namespace Kola.Hosting.Nancy
{
    public class KolaNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            var kolaConfiguration = new KolaBootstrapper().BuildConfiguration();
            container.Register(kolaConfiguration);
            //container.Register<IRazorConfiguration, KolaRazorConfiguration>().AsSingleton();

            foreach (var viewLocation in kolaConfiguration.ViewLocations)
            {
                ResourceViewLocationProvider.RootNamespaces.Add(viewLocation.Assembly, viewLocation.Location);
            }

            ResourceViewLocationProvider.RootNamespaces.Add(typeof(KolaNancyBootstrapper).Assembly, "Kola.Hosting.Nancy");
            ResourceViewLocationProvider.Ignore.Add(typeof(RazorViewEngine).Assembly);

            base.ConfigureApplicationContainer(container);
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(c => c.ViewLocationProvider = typeof(ResourceViewLocationProvider));
            }
        }
    }

    public class MyRazorConfiguration : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            throw new NotImplementedException();
        }

        public bool AutoIncludeModelNamespace
        {
            get { throw new NotImplementedException(); }
        }
    }
}