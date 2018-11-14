namespace Kola.Nancy
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;

    using Kola.Client;
    using Kola.Configuration;
    using Kola.Configuration.Plugins;
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
    using global::Nancy.Security;
    using global::Nancy.TinyIoc;
    using global::Nancy.ViewEngines;
    using global::Nancy.ViewEngines.Razor;

    using Kola.Domain.Instances.Config;

    public class KolaNancyBootstrapper : DefaultNancyBootstrapper
    {
        public KolaNancyBootstrapper()
        {
            var plugins = new PluginFinder().FindPlugins().ToArray();

            this.ConfigureNamespaces(plugins);

            KolaConfigurationRegistry.RegisterPlugins(plugins);
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer tinyIoCContainer, NancyContext context)
        {
            tinyIoCContainer.Register(this.GetAccessToken(context), "access_token");

            tinyIoCContainer.Register<ITemplateService, TemplateService>();
            tinyIoCContainer.Register<IRenderingService, RenderingService>();
            tinyIoCContainer.Register<ISitemapService, SitemapService>();

            tinyIoCContainer.Register<IContentRepository, ContentRepository>();

            tinyIoCContainer.Register<IContentFinder, ContentFinder>();
            tinyIoCContainer.Register<IContentLister, ContentLister>();

            tinyIoCContainer.Register<IPathInstanceBuilder, PathInstanceBuilder>();
            tinyIoCContainer.Register<IDynamicSourceProvider, DynamicSourceProvider>();
            tinyIoCContainer.Register<IPluginContextProvider, PluginContextProvider>();

            var sourceTypes = KolaConfigurationRegistry.Plugins.SelectMany(plugin => plugin.SourceTypes).ToArray();
            tinyIoCContainer.Register((c, o) => sourceTypes.Select(c.Resolve).Cast<IDynamicSource>());

            var contentProviderTypes = KolaConfigurationRegistry.Plugins.SelectMany(plugin => plugin.ContextProviderTypes).ToArray();
            tinyIoCContainer.Register((c, o) => contentProviderTypes.Select(c.Resolve).Cast<IContextProvider>());

            var container = new TinyIoCAdapter(tinyIoCContainer);

            var componentSpecifications = KolaConfigurationRegistry.Plugins.SelectMany(plugin => plugin.ComponentTypeSpecifications);
            KolaConfigurationRegistry.RegisterRenderer(new MultiRenderer(new RendererFactory(componentSpecifications, container)));

            foreach (var plugin in KolaConfigurationRegistry.Plugins)
            {
                plugin.ConfigureContainer(container);
            }
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer tinyIoCContainer)
        {
            var contentRoot = ConfigurationManager.AppSettings["ContentRoot"];
            tinyIoCContainer.Register<IFileSystemHelper>((c, o) => new FileSystemHelper(contentRoot));
            tinyIoCContainer.Register<ISerializationHelper>((c, o) => new SerializationHelper(contentRoot));

            tinyIoCContainer.Register<IKolaConfigurationRegistry, KolaConfigurationRegistry>();
            tinyIoCContainer.Register<IConfigurationRepository, ConfigurationRepository>();

            tinyIoCContainer.Register<IWidgetSpecificationService, WidgetSpecificationService>();
            tinyIoCContainer.Register<IWidgetSpecificationRepository, WidgetSpecificationRepository>();

            tinyIoCContainer.Register<IComponentSpecificationService, ComponentSpecificationService>();
            tinyIoCContainer.Register<IComponentSpecificationLibrary, ComponentSpecificationLibrary>();

            tinyIoCContainer.Register<IResourceBuilder<AmendmentDetails>, AmendmentDetailsResourceBuilder>();
            tinyIoCContainer.Register<IResourceBuilder<AmendmentsDetails>, AmendmentsDetailsResourceBuilder>();
            tinyIoCContainer.Register<IResourceBuilder<Template>, TemplateResourceBuilder>();
            tinyIoCContainer.Register<IResourceBuilder<ComponentDetails>, ComponentDetailsResourceBuilder>();
            tinyIoCContainer.Register<IResourceBuilder<UndoAmendmentDetails>, UndoAmendmentDetailsResourceBuilder>();
            tinyIoCContainer.Register<IResourceBuilder<WidgetSpecification>, WidgetSpecificationResourceBuilder>();
            tinyIoCContainer.Register<IResourceBuilder<IEnumerable<IComponentSpecification<IComponentWithProperties>>>, ComponentSpecificationsResourceBuilder>();
        }

        private void ConfigureNamespaces(IEnumerable<PluginConfiguration> plugins)
        {
            foreach (var plugin in plugins)
            {
                ResourceViewLocationProvider.RootNamespaces.Add(plugin.GetType().Assembly, plugin.ViewLocation);
            }

            ResourceViewLocationProvider.RootNamespaces.Add(typeof(KolaNancyBootstrapper).Assembly, "Kola.Nancy");
            ResourceViewLocationProvider.Ignore.Add(typeof(RazorViewEngine).Assembly);
            ResourceViewLocationProvider.Ignore.Add(Assembly.Load("System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"));
            AppDomainAssemblyTypeScanner.AddAssembliesToScan(AppDomainAssemblyTypeScanner.DefaultAssembliesToScan.ToArray());
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

            foreach (var plugin in KolaConfigurationRegistry.Plugins)
            {
                conventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("/_kola/plugins/" + plugin.PluginName, plugin.GetType().Assembly, "/editors"));
            }
        }

        private string GetAccessToken(NancyContext context)
        {
            return context.Items.ContainsKey("OWIN_REQUEST_ENVIRONMENT")
                       ? context?.GetMSOwinUser()?.Claims?.FirstOrDefault(claim => claim.Type == "access_token")?.Value
                       : string.Empty;
        }
    }
}