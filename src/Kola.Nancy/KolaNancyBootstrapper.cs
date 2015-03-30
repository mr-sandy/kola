namespace Kola.Nancy
{
    using System.Linq;
    using System.Reflection;

    using Kola.Client;
    using Kola.Configuration;

    using global::Nancy;
    using global::Nancy.Bootstrapper;
    using global::Nancy.Conventions;
    using global::Nancy.Embedded.Conventions;
    using global::Nancy.TinyIoc;
    using global::Nancy.ViewEngines;
    using global::Nancy.ViewEngines.Razor;

    public class KolaNancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(c =>
                    {
                        c.ViewLocationProvider = typeof(CachingResourceViewLocationProvider);
                    });
            }
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            // TODO {SC} Use the IOC container to hold the Kola configuration
            new KolaConfigurationBuilder().Build(new PluginFinder(), new TinyIoCObjectFactory(container));

            foreach (var plugin in KolaConfigurationRegistry.Instance.Plugins)
            {
                ResourceViewLocationProvider.RootNamespaces.Add(plugin.GetType().Assembly, plugin.ViewLocation);
            }

            ResourceViewLocationProvider.RootNamespaces.Add(typeof(KolaNancyBootstrapper).Assembly, "Kola.Nancy");
            ResourceViewLocationProvider.Ignore.Add(typeof(RazorViewEngine).Assembly);
            ResourceViewLocationProvider.Ignore.Add(Assembly.Load("System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"));
            AppDomainAssemblyTypeScanner.AddAssembliesToScan(AppDomainAssemblyTypeScanner.DefaultAssembliesToScan.ToArray());

            base.ConfigureApplicationContainer(container);
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            global::Nancy.Json.JsonSettings.MaxJsonLength = int.MaxValue;
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);
            conventions.StaticContentsConventions.AddDirectory("/Scripts");
            conventions.StaticContentsConventions.AddDirectory("/cdn");
            conventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("/_kola/fonts", typeof(ClientIdentifier).Assembly, "/fonts"));
            conventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("/_kola/Scripts", typeof(ClientIdentifier).Assembly, "/Scripts"));
            conventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("/_kola/Content", typeof(ClientIdentifier).Assembly, "/Content"));

            foreach (var plugin in KolaConfigurationRegistry.Instance.Plugins)
            {
                conventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("/_kola/Editors/" + plugin.PluginName, plugin.GetType().Assembly, "/Editors"));
            } 
        }
    }
}