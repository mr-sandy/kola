namespace Integration.Tests.Nancy.Modules.TinyIocTests
{
    using FluentAssertions;

    using global::Nancy.TinyIoc;

    using Kola.Configuration;
    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Nancy.Modules;
    using Kola.Persistence;
    using Kola.Service;
    using Kola.Service.Services;

    using NUnit.Framework;

    public class TinyIocTest
    {
        private TinyIoCContainer container;

        private RenderingModule renderingModule;

        [SetUp]
        public void SetUp()
        {
            this.container = new TinyIoCContainer();
            this.container.Register<IFileSystemHelper>((c, o) => new FileSystemHelper("name"));
            this.container.Register<ISerializationHelper>((c, o) => new SerializationHelper("name"));
            this.container.Register<IContentRepository, ContentRepository>();
            this.container.Register<IDynamicSourceProvider, DynamicSourceProvider>();
            this.container.Register<IContentFinder, ContentFinder>();
            this.container.Register<IWidgetSpecificationRepository, WidgetSpecificationRepository>();
            this.container.Register<IKolaConfigurationRegistry, KolaConfigurationRegistry>();
            this.container.Register<IComponentSpecificationLibrary, ComponentSpecificationLibrary>();
            this.container.Register<IComponentSpecificationService, ComponentSpecificationService>();
            this.container.Register<IRenderingService, RenderingService>();
            this.renderingModule = this.container.Resolve<RenderingModule>();
        }

        [Test]
        public void ShouldResolve()
        {
            this.renderingModule.Should().NotBeNull();
        }

    }
}