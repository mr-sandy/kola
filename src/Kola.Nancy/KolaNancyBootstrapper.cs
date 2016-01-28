namespace Kola.Nancy
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;

    using Kola.Client;
    using Kola.Configuration;
    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;
    using Kola.Persistence;
    using Kola.Service;
    using Kola.Service.ResourceBuilding;
    using Kola.Service.Services;
    using Kola.Service.Services.Models;

    using global::Nancy;
    using global::Nancy.Bootstrapper;
    using global::Nancy.Conventions;
    using global::Nancy.Embedded.Conventions;
    using global::Nancy.Json;
    using global::Nancy.TinyIoc;
    using global::Nancy.ViewEngines;
    using global::Nancy.ViewEngines.Razor;

    using Kola.Nancy.Processors;

    public class KolaNancyBootstrapper : DefaultNancyBootstrapper
    {
        public KolaNancyBootstrapper()
        {
            
        }
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

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            var objectFactory = new TinyIoCObjectFactory(container);

            container.Register<IKolaConfigurationRegistry, KolaConfigurationRegistry>();
            container.Register<IComponentSpecificationService, ComponentSpecificationService>();
            container.Register<IComponentSpecificationLibrary, ComponentSpecificationLibrary>();
            container.Register<IWidgetSpecificationRepository, WidgetSpecificationRepository>();


            var contentRoot = ConfigurationManager.AppSettings["ContentRoot"];

            container.Register<IFileSystemHelper>((c, o) => new FileSystemHelper(contentRoot));
            container.Register<ISerializationHelper>((c, o) => new SerializationHelper(contentRoot));

            container.Register<IContentFinder, ContentFinder>();
            container.Register<IDynamicSourceProvider, DynamicSourceProvider>();
            container.Register<IRenderingService, RenderingService>();
            container.Register<IContentRepository, ContentRepository>();
            container.Register<IConfigurationRepository, ConfigurationRepository>();
            container.Register<ITemplateService, TemplateService>();
            container.Register<IWidgetSpecificationService, WidgetSpecificationService>();
            container.Register<IPathInstanceBuilder, PathInstanceBuilder>();


            var sourceTypes = KolaConfigurationRegistry.Instance.Plugins.SelectMany(plugin => plugin.SourceTypes).ToArray();
            container.Register((c, o) => sourceTypes.Select(c.Resolve).Cast<IDynamicSource>());

            var rendererMappings = KolaConfigurationRegistry.Instance.Plugins.SelectMany(c => c.ComponentTypeSpecifications);
            var rendererFactory = new RendererFactory(rendererMappings, objectFactory);
            KolaConfigurationRegistry.Instance.Renderer = new MultiRenderer(rendererFactory);

            foreach (var plugin in KolaConfigurationRegistry.Instance.Plugins)
            {
                plugin.ConfigureRequestFactory(objectFactory);
            }

        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            var plugins = new PluginFinder().FindPlugins().ToArray();
            
            KolaConfigurationRegistry.Register(new KolaConfiguration(null, plugins));

            container.Register<IResourceBuilder<AmendmentDetails>, AmendmentDetailsResourceBuilder>();
            container.Register<IResourceBuilder<AmendmentsDetails>, AmendmentsDetailsResourceBuilder>();
            container.Register<IResourceBuilder<Template>, TemplateResourceBuilder>();
            container.Register<IResourceBuilder<ComponentDetails>, ComponentDetailsResourceBuilder>();
            container.Register<IResourceBuilder<UndoAmendmentDetails>, UndoAmendmentDetailsResourceBuilder>();
            container.Register<IResourceBuilder<WidgetSpecification>, WidgetSpecificationResourceBuilder>();
            container.Register<IResourceBuilder<IEnumerable<IComponentSpecification<IComponentWithProperties>>>, ComponentSpecificationsResourceBuilder>();

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