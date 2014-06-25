namespace Unit.Tests.ResourceBuilding
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Extensions;
    using Kola.Resources;

    using NUnit.Framework;

    public class WhenBuildingATemplateResource
    {
        private TemplateResource resource;

        [SetUp]
        public void EstablishContext()
        {
            var template = new Template(new[] { "test", "path" }, new IComponent[]
                    {
                        new Atom("atom 0"), 
                        new Container("container 1", components: new[] { new Atom("atom 1.0") }),
                        new Widget("widget 2", areas: new[] { new Area(new[] { new Atom("atom 2.0.0") }), })
                    });

            var builder = new TemplateResourceBuilder();

            this.resource = builder.Build(template);
        }

        [Test]
        public void ShouldHaveFourRootComponents()
        {
            this.resource.Components.Should().HaveCount(4);
        }

        [Test]
        public void ShouldSetCorrectNameForComponent0()
        {
            this.resource.Components.ElementAt(0).Name.Should().Be("atom 0");
        }

        [Test]
        public void ShouldSetCorrectNameForComponent1()
        {
            this.resource.Components.ElementAt(1).Name.Should().Be("container 1");
        }

        [Test]
        public void ShouldSetCorrectNameForComponent2()
        {
            this.resource.Components.ElementAt(2).Name.Should().Be("widget 2");
        }
    }
}