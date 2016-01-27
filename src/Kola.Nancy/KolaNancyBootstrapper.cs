namespace Kola.Nancy
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;

    using global::Nancy;
    using global::Nancy.Bootstrapper;
    using global::Nancy.Conventions;
    using global::Nancy.Embedded.Conventions;
    using global::Nancy.Json;
    using global::Nancy.TinyIoc;
    using global::Nancy.ViewEngines;
    using global::Nancy.ViewEngines.Razor;

    using Kola.Client;
    using Kola.Configuration;
    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Specifications;
    using Kola.Persistence;
    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services.Models;

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
            base.ConfigureApplicationContainer(container);

            var objectFactory = new TinyIoCObjectFactory(container);
            
            // TODO {SC} Use the IOC container to hold the Kola configuration
            new KolaConfigurationBuilder().Build(new PluginFinder(), objectFactory);

            container.Register<IResourceBuilder<AmendmentDetails>, AmendmentDetailsResourceBuilder>();
            container.Register<IResourceBuilder<AmendmentsDetails>, AmendmentsDetailsResourceBuilder>();
            container.Register<IResourceBuilder<Template>, TemplateResourceBuilder>();
            container.Register<IResourceBuilder<ComponentDetails>, ComponentDetailsResourceBuilder>();
            container.Register<IResourceBuilder<UndoAmendmentDetails>, UndoAmendmentDetailsResourceBuilder>();
            container.Register<IResourceBuilder<WidgetSpecification>, WidgetSpecificationResourceBuilder>();
            container.Register<IResourceBuilder<IEnumerable<IComponentSpecification<IComponentWithProperties>>>, ComponentSpecificationsResourceBuilder>();

            var contentRoot = ConfigurationManager.AppSettings["ContentRoot"];
            container.Register<IFileSystemHelper>((c, o) => new FileSystemHelper(contentRoot));
            container.Register<ISerializationHelper>((c, o) => new SerializationHelper(contentRoot));

            foreach (var plugin in KolaConfigurationRegistry.Instance.Plugins)
            {
                plugin.Register(objectFactory);
            }

            // TODO {SC} This should probably be moved somewhere into the Kola Config - it's not really Nancy/TinyIoc specific
            var sourceTypes = from plugin in KolaConfigurationRegistry.Instance.Plugins
                                  from source in plugin.SourceTypes
                                  select source;
            container.Register((c, o) => sourceTypes.Select(c.Resolve).Cast<IDynamicSource>());

            foreach (var plugin in KolaConfigurationRegistry.Instance.Plugins)
            {
                ResourceViewLocationProvider.RootNamespaces.Add(plugin.GetType().Assembly, plugin.ViewLocation);
            }

            ResourceViewLocationProvider.RootNamespaces.Add(typeof(KolaNancyBootstrapper).Assembly, "Kola.Nancy");
            ResourceViewLocationProvider.Ignore.Add(typeof(RazorViewEngine).Assembly);
            ResourceViewLocationProvider.Ignore.Add(Assembly.Load("System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"));
            AppDomainAssemblyTypeScanner.AddAssembliesToScan(AppDomainAssemblyTypeScanner.DefaultAssembliesToScan.ToArray());
        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            JsonSettings.MaxJsonLength = int.MaxValue;
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);
            conventions.StaticContentsConventions.AddDirectory("/Scripts");
            conventions.StaticContentsConventions.AddDirectory("/cdn");
            conventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("/_kola/fonts", typeof(ClientIdentifier).Assembly, "/fonts"));
            conventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("/_kola/scripts", typeof(ClientIdentifier).Assembly, "/scripts"));
            conventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("/_kola/content", typeof(ClientIdentifier).Assembly, "/content"));

            foreach (var plugin in KolaConfigurationRegistry.Instance.Plugins)
            {
                conventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("/_kola/plugins/" + plugin.PluginName, plugin.GetType().Assembly, "/editors"));
            } 
        }
    }
}