namespace Unit.Tests.Extensions.ResourceExtensions
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
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
            var template = new Template(templatePath);

            var child1 = new Container("child1", null);
            template.Insert(0, child1);

            var grandchild1 = new Atom("grandchild1", null);
            child1.Insert(0, grandchild1);

            var child2 = new Atom("child2", null);
            template.Insert(1, child2);

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
            this.templateResource.Components.ElementAt(0).Path.Should().BeEquivalentTo(new[] { 0 });
        }

        [Test]
        public void ShouldReturnCorrectLinkRelForSecondChild()
        {
            this.templateResource.Components.ElementAt(1).Path.Should().BeEquivalentTo(new[] { 1 });
        }

        [Test]
        public void ShouldReturnCorrectLinkRelForFirstGrandchild()
        {
            this.templateResource.Components.ElementAt(0).As<ContainerResource>().Components.ElementAt(0).As<AtomResource>().Path.Should().BeEquivalentTo(new[] { 0, 0 });
        }
    }
}