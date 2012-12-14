using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kola.Configuration.Ideas;
using Kola.Configuration.Plugins;
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
            base.ConfigureApplicationContainer(container);

            var kolaConfiguration = new KolaBootstrapper().BuildConfiguration();

            container.Register<KolaConfiguration>().AsSingleton();
            container.Register<IRazorConfiguration, KolaRazorConfiguration>();

            foreach (var viewLocation in kolaConfiguration.ViewLocations)
            {
                ResourceViewLocationProvider.RootNamespaces.Add(viewLocation.Assembly, viewLocation.Location);
            }

            ResourceViewLocationProvider.Ignore.Add(typeof(RazorViewEngine).Assembly);
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return
                    NancyInternalConfiguration.WithOverrides(
                        c => c.ViewLocationProvider = typeof(ResourceViewLocationProvider));
            }
        }
    }
}