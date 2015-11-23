namespace Unit.Tests.ResourceBuilding
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Context;
    using Kola.Resources;
    using Kola.Service.ResourceBuilding;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenBuildingATemplateResourceForATemplateWithADynamicPath
    {
        private TemplateResource resource;

        [SetUp]
        public void SetUp()
        {
            var source1 = new TestSource
            {
                Name = "-artist-",
                GetAllItemsFunc = c => new[]
                {
                    new DynamicItem("beatles", new [] { new ContextItem("artist-id", "1") }),
                    new DynamicItem("beach-boys", new [] { new ContextItem("artist-id", "2") })
                }
            };

            var source2 = new TestSource
            {
                Name = "-album-",
                GetAllItemsFunc = c =>
                    {
                        return c.Any(i => i.Name == "artist-id" && i.Value == "1") 
                        ? new[] { new DynamicItem("revolver") } 
                        : new[] { new DynamicItem("pet-sounds") };
                    }
            };

            var dynamicSourceProvider = MockRepository.GenerateMock<IDynamicSourceProvider>();

            dynamicSourceProvider.Stub(p => p.Get("-artist-")).Return(source1);
            dynamicSourceProvider.Stub(p => p.Get("-album-")).Return(source2);

            var template = new Template(new[] { "static", "-artist-", "-album-" });

            this.resource = new TemplateResourceBuilder(dynamicSourceProvider).Build(template) as TemplateResource;
        }

        [Test]
        public void ItShouldHaveAPreviewLinkForEachPermutation()
        {
            this.resource.Links.Where(l => l.Rel == "preview").Should().HaveCount(2);
        }

        [Test]
        public void ItShouldHaveAPreviewLinkForEachPermutation1()
        {
            this.resource.Links.Where(l => l.Rel == "preview" && l.Href == "/static/beatles/revolver?preview=y").Should().HaveCount(1);
        }

        [Test]
        public void ItShouldHaveAPreviewLinkForEachPermutation4()
        {
            this.resource.Links.Where(l => l.Rel == "preview" && l.Href == "/static/beach-boys/pet-sounds?preview=y").Should().HaveCount(1);
        }
    }
}