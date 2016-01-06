namespace Unit.Tests.ResourceBuilding
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Resources;
    using Kola.Service.ResourceBuilding;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenBuildingATemplateResourceForTheHomepage
    {
        private TemplateResource resource;

        [SetUp]
        public void SetUp()
        {
            var dynamicSourceProvider = MockRepository.GenerateMock<IDynamicSourceProvider>();
            var pathInstanceBuilder = new PathInstanceBuilder(dynamicSourceProvider);

            var template = new Template(Enumerable.Empty<string>());

            this.resource = new TemplateResourceBuilder(pathInstanceBuilder).Build(template) as TemplateResource;
        }

        [Test]
        public void ShouldSetCorrectSelfLink()
        {
            this.resource.Links.Single(l => l.Rel == "self").Href.Should().Be("/_kola/template?templatePath=/");
        }

        [Test]
        public void ItShouldHaveAPreviewLink()
        {
            this.resource.Links.Where(l => l.Rel == "preview" && l.Href == "/?preview=y").Should().HaveCount(1);
        }
    }
}