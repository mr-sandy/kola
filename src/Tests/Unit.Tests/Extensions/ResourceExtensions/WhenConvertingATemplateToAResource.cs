namespace Unit.Tests.Extensions.ResourceExtensions
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Templates;
    using Kola.Extensions;
    using Kola.Resources;

    using NUnit.Framework;

    public class WhenConvertingATemplateToAResource
    {
        private TemplateResource templateResource;

        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            var template = new PageTemplate(templatePath);

            var child1 = new ContainerTemplate("child1", null);
            template.AddComponent(child1, 0);

            var grandchild1 = new AtomTemplate("grandchild1", null);
            child1.AddComponent(grandchild1, 0);

            var child2 = new AtomTemplate("child2", null);
            template.AddComponent(child2, 1);

            this.templateResource = template.ToResource();
        }

        [Test]
        public void ShouldReturnATemplateResource()
        {
            this.templateResource.Should().NotBeNull();
        }

        [Test]
        public void ShouldReturnALinkRelForSelf()
        {
            this.templateResource.Links.Should().Contain(l => l.Rel == "self");
        }
        [Test]
        public void ShouldReturnUrlInLinkRelForSelf()
        {
            var rel = this.templateResource.Links.Where(l => l.Rel == "self").Single();

            rel.Href.Should().Be("/test/path");
        }

        [Test]
        public void ShouldReturnAChildResourceForEachChild()
        {
            this.templateResource.Components.Should().HaveCount(2);
        }

        [Test]
        public void ShouldReturnCorrectLinkRelForFirstChild()
        {
            var rel = this.templateResource.Components.ElementAt(0).Links.Where(l => l.Rel == "componentPath").Single();

            rel.Href.Should().Be("0");
        }

        [Test]
        public void ShouldReturnCorrectLinkRelForSecondChild()
        {
            var rel = this.templateResource.Components.ElementAt(1).Links.Where(l => l.Rel == "componentPath").Single();

            rel.Href.Should().Be("1");
        }

        [Test]
        public void ShouldReturnCorrectLinkRelForFirstGrandchild()
        {
            var rel = this.templateResource.Components.ElementAt(0).Components.ElementAt(0).Links.Where(l => l.Rel == "componentPath").Single();

            rel.Href.Should().Be("0/0");
        }
    }
}