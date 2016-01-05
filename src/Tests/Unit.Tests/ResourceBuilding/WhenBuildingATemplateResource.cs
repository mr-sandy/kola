namespace Unit.Tests.ResourceBuilding
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.DynamicSources;
    using Kola.Resources;
    using Kola.Service.ResourceBuilding;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenBuildingATemplateResource
    {
        private TemplateResource resource;

        [SetUp]
        public void SetUp()
        {
            var dynamicSourceProvider = MockRepository.GenerateMock<IDynamicSourceProvider>();
            var pathInstanceBuilder = new PathInstanceBuilder(dynamicSourceProvider);

            var template = new Template(new[] { "test", "path" }, new IComponent[]
                {
                    new Atom("atom 0", new[]
                        {
                            new Property("property 0", "property 0 type", new FixedPropertyValue("property 0 value")),
                            new Property("property 1", "property 1 type", new InheritedPropertyValue("property 1 key")),
                        }), 
                    new Container("container 1", components: new[] { new Atom("atom 1.0") }),
                    new Widget("widget 2", areas: new[] { new Area("area 1", new[] { new Atom("atom 2.0.0") }), })
                });

            this.resource = new TemplateResourceBuilder(pathInstanceBuilder).Build(template) as TemplateResource;
        }

        [Test]
        public void ShouldSetCorrectSelfLink()
        {
            this.resource.Links.Single(l => l.Rel == "self").Href.Should().Be("/_kola/template?templatePath=/test/path");
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
            this.resource.Components.ElementAt(0).As<AtomResource>().Path.Should().Be("/0");
        }

        [Test]
        public void ShouldSetCorrectSelfLinkForComponent0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Links.Single(l => l.Rel == "self").Href.Should().Be("/_kola/template/components?templatePath=/test/path&componentPath=/0");
        }

        [Test]
        public void ShouldSetCorrectNameForComponent0Property0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Properties.ElementAt(0).Name.Should().Be("property 0");
        }

        [Test]
        public void ShouldSetCorrectTypeForComponent0Property0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Properties.ElementAt(0).Type.Should().Be("property 0 type");
        }

        [Test]
        public void ShouldSetCorrectValueTypeForComponent0Property0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Properties.ElementAt(0).Value.As<FixedPropertyValueResource>().Type.Should().Be("fixed");
        }

        [Test]
        public void ShouldSetCorrectValueForComponent0Property0()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Properties.ElementAt(0).Value.As<FixedPropertyValueResource>().Value.Should().Be("property 0 value");
        }

        [Test]
        public void ShouldSetCorrectNameForComponent0Property1()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Properties.ElementAt(1).Name.Should().Be("property 1");
        }

        [Test]
        public void ShouldSetCorrectTypeForComponent0Property1()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Properties.ElementAt(1).Type.Should().Be("property 1 type");
        }

        [Test]
        public void ShouldSetCorrectValueTypeForComponent0Property1()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Properties.ElementAt(1).Value.As<InheritedPropertyValueResource>().Type.Should().Be("inherited");
        }

        [Test]
        public void ShouldSetCorrectValueForComponent0Property1()
        {
            this.resource.Components.ElementAt(0).As<AtomResource>().Properties.ElementAt(1).Value.As<InheritedPropertyValueResource>().Key.Should().Be("property 1 key");
        }


        [Test]
        public void ShouldSetCorrectNameForComponent1()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Name.Should().Be("container 1");
        }

        [Test]
        public void ShouldSetCorrectPathForComponent1()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Path.Should().Be("/1");
        }

        [Test]
        public void ShouldSetCorrectSelfLinkForComponent1()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Links.Single(l => l.Rel == "self").Href.Should().Be("/_kola/template/components?templatePath=/test/path&componentPath=/1");
        }

        [Test]
        public void ShouldSetCorrectNameForComponent10()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Components.ElementAt(0).As<AtomResource>().Name.Should().Be("atom 1.0");
        }

        [Test]
        public void ShouldSetCorrectPathForComponent10()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Components.ElementAt(0).As<AtomResource>().Path.Should().Be("/1/0");
        }

        [Test]
        public void ShouldSetCorrectSelfLinkForComponent10()
        {
            this.resource.Components.ElementAt(1).As<ContainerResource>().Components.ElementAt(0).As<AtomResource>().Links.Single(l => l.Rel == "self").Href.Should().Be("/_kola/template/components?templatePath=/test/path&componentPath=/1/0");
        }


        [Test]
        public void ShouldSetCorrectNameForComponent2()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Name.Should().Be("widget 2");
        }

        [Test]
        public void ShouldSetCorrectPathForComponent2()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Path.Should().Be("/2");
        }

        [Test]
        public void ShouldSetCorrectSelfLinkForComponent2()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Links.Single(l => l.Rel == "self").Href.Should().Be("/_kola/template/components?templatePath=/test/path&componentPath=/2");
        }

        [Test]
        public void ShouldSetCorrectNameForComponent200()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Areas.ElementAt(0).As<AreaResource>().Components.ElementAt(0).As<AtomResource>().Name.Should().Be("atom 2.0.0");
        }

        [Test]
        public void ShouldSetCorrectPathForComponent200()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Areas.ElementAt(0).As<AreaResource>().Components.ElementAt(0).As<AtomResource>().Path.Should().Be("/2/0/0");
        }

        [Test]
        public void ShouldSetCorrectSelfLinkForComponent200()
        {
            this.resource.Components.ElementAt(2).As<WidgetResource>().Areas.ElementAt(0).As<AreaResource>().Components.ElementAt(0).As<AtomResource>().Links.Single(l => l.Rel == "self").Href.Should().Be("/_kola/template/components?templatePath=/test/path&componentPath=/2/0/0");
        }

    }
}