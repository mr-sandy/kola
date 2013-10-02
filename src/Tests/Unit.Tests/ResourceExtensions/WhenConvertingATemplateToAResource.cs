namespace Unit.Tests.ResourceExtensions
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Resources;

    using NUnit.Framework;

    using Kola.Nancy.Extensions;

    public class WhenConvertingATemplateToAResource
    {
        private TemplateResource templateResource;

        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            var template = new Template(templatePath);

            var child1 = new Component("child1");
            template.AddComponent(child1);

            var grandchild1 = new Component("grandchild1");
            child1.AddComponent(grandchild1);

            var child2 = new Component("child2");
            template.AddComponent(child2);

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