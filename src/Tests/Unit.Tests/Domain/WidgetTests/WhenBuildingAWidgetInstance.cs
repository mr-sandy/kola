namespace Unit.Tests.Domain.WidgetTests
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;
    using Kola.Domain.Rendering;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenBuildingAWidgetInstance
    {
        private WidgetInstance instance;

        [SetUp]
        public void SetUp()
        {
            var specification = new WidgetSpecification(
                "widget name",
                Enumerable.Empty<PropertySpecification>(),
                new IComponent[]
                    {
                        new Atom("atom", Enumerable.Empty<Property>()), 
                        new Placeholder("area 1"), 
                        new Container("container", Enumerable.Empty<Property>(), new[] { new Placeholder("area 2") }) 
                    });

            var widget = new Widget(
                "widget name",
                new[]
                    {
                        new Area("area 1", new IComponent[] { new Atom("atom", Enumerable.Empty<Property>()), new Atom("atom", Enumerable.Empty<Property>()) }),
                        new Area("area 2", new IComponent[] { new Atom("atom", Enumerable.Empty<Property>()), new Atom("atom", Enumerable.Empty<Property>()), new Atom("atom", Enumerable.Empty<Property>()) })
                    });

            var buildContext = new BuildContext();

            var builder = new Builder(new RenderingInstructions(false, true), n => specification);
            
            this.instance = (WidgetInstance)widget.Build(builder, new[] { 0 }, buildContext);
        }

        [Test]
        public void WidgetInstanceShouldHaveThreeChildren()
        {
            this.instance.Components.Should().HaveCount(3);
        }

        [Test]
        public void FirstPlaceholderInstancesContentShouldHaveTwoChildren()
        {
            var placeholder = this.instance.Components.ElementAt(1) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.Should().HaveCount(2);
        }

        [Test]
        public void ContainerIntanceShouldContainPlaceholderInstance()
        {
            var containerInstance = (ContainerInstance)this.instance.Components.ElementAt(2);

            containerInstance.Components.Single().Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void SecondPlaceholderInstanceShouldHaveThreeChildren()
        {
            var containerInstance = (ContainerInstance)this.instance.Components.ElementAt(2);
            var placeholder = containerInstance.Components.Single() as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.Should().HaveCount(3);
        }
    }
}