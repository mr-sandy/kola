namespace Unit.Tests.ResourceBuilding
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.ParameterValues;
    using Kola.ResourceBuilders;
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
                    new Atom("atom 0", new[]
                        {
                            new Parameter("parameter 0", "parameter 0 type", new FixedParameterValue("parameter 0 value"))
                        }), 
                    new Container("container 1", components: new[] { new Atom("atom 1.0") }),
                    new Widget("widget 2", areas: new[] { new Area(new[] { new Atom("atom 2.0.0") }), })
                });

            var builder = new TemplateResourceBuilder();

            this.resource = builder.Build(template);
        }

        [Test]
        public void ShouldSetCorrectSelfLink()
        {
            this.resource.Links.Single(l => l.Rel == "self").Href.Should().Be("/test/path");
        }

        [Test]
        public void ShouldBuildAllRootComponents()
        {
            this.resource.Components.Should().HaveCount(3);
        }

        [Test]
        public void ShouldSetCorrectNameForComponent0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Name.Should().Be("atom 0");
        }

        [Test]
        public void ShouldSetCorrectPathForComponent0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Path.Should().BeEquivalentTo(new[] { 0 });
        }

        [Test]
        public void ShouldSetCorrectSelfLinkForComponent0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Links.Single(l => l.Rel == "self").Href.Should().Be("/test/path/_components/0");
        }

        [Test]
        public void ShouldSetCorrectNameForComponent0Parameter0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Parameters.ElementAt(0).Name.Should().Be("parameter 0");
        }

        [Test]
        public void ShouldSetCorrectTypeForComponent0Parameter0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Parameters.ElementAt(0).Type.Should().Be("parameter 0 type");
        }

        [Test]
        public void ShouldSetCorrectValueTypeForComponent0Parameter0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Parameters.ElementAt(0).Value.As<FixedParameterValueResource>().Type.Should().Be("fixed");
        }

        [Test]
        public void ShouldSetCorrectValueForComponent0Parameter0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Parameters.ElementAt(0).Value.As<FixedParameterValueResource>().Value.Should().Be("parameter 0 value");
        }

        [Test]
        public void ShouldSetCorrectNameForComponent1()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Name.Should().Be("container 1");
        }

        [Test]
        public void ShouldSetCorrectPathForComponent1()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Path.Should().BeEquivalentTo(new[] { 1 });
        }

        [Test]
        public void ShouldSetCorrectSelfLinkForComponent1()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Links.Single(l => l.Rel == "self").Href.Should().Be("/test/path/_components/1");
        }

        [Test]
        public void ShouldSetCorrectNameForComponent10()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Components.ElementAt(0).As<AtomResource>().Name.Should().Be("atom 1.0");
        }

        [Test]
        public void ShouldSetCorrectPathForComponent10()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Components.ElementAt(0).As<AtomResource>().Path.Should().BeEquivalentTo(new[] { 1, 0 });
        }

        [Test]
        public void ShouldSetCorrectSelfLinkForComponent10()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Components.ElementAt(0).As<AtomResource>().Links.Single(l => l.Rel == "self").Href.Should().Be("/test/path/_components/1/0");
        }


        [Test]
        public void ShouldSetCorrectNameForComponent2()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Name.Should().Be("widget 2");
        }

        [Test]
        public void ShouldSetCorrectPathForComponent2()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Path.Should().BeEquivalentTo(new[] { 2 });
        }

        [Test]
        public void ShouldSetCorrectSelfLinkForComponent2()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Links.Single(l => l.Rel == "self").Href.Should().Be("/test/path/_components/2");
        }

        [Test]
        public void ShouldSetCorrectNameForComponent200()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Areas.ElementAt(0).Components.ElementAt(0).As<AtomResource>().Name.Should().Be("atom 2.0.0");
        }

        [Test]
        public void ShouldSetCorrectPathForComponent200()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Areas.ElementAt(0).Components.ElementAt(0).As<AtomResource>().Path.Should().BeEquivalentTo(new[] { 2, 0, 0 });
        }

        [Test]
        public void ShouldSetCorrectSelfLinkForComponent200()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Areas.ElementAt(0).Components.ElementAt(0).As<AtomResource>().Links.Single(l => l.Rel == "self").Href.Should().Be("/test/path/_components/2/0/0");
        }

    }
}