using System;
using Kola.Configuration;
using Kola.Configuration.Ideas;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.ViewEngines;

namespace Kola.Hosting.Nancy
{
    public static class ViewEngineStuff
    {
        public static void RegisterIocBootstrapper(Action<TinyIoCContainer> iocBootstrapper)
        {
            Bootstrapper = iocBootstrapper;
        }

        internal static Action<TinyIoCContainer> Bootstrapper { get; set; }
    }

    public class KolaNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            KolaConfiguration.BuildConfiguration();

            base.ConfigureApplicationContainer(container);

            ViewEngineStuff.Bootstrapper(container);

            //container.Register<IRazorConfiguration, MyRazorConfiguration>();

            //foreach (var viewLocation in Registry.Configuration.ViewLocations)
            //{
            //    ResourceViewLocationProvider.RootNamespaces.Add(viewLocation.Assembly, viewLocation.Location);
            //}

            //ResourceViewLocationProvider.Ignore.Add(typeof(RazorViewEngine).Assembly);
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