namespace Unit.Tests.Domain.WidgetTests
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenBuildingAWidgetInstance
    {
        private WidgetInstance instance;

        [SetUp]
        public void EstablishContext()
        {
            var specification = new WidgetSpecification(
                "widget name",
                new IComponent[]
                    {
                        new Atom("atom", Enumerable.Empty<Parameter>()), 
                        new Placeholder(), 
                        new Container("container", Enumerable.Empty<Parameter>(), new[] { new Placeholder() }) 
                    });

            var widget = new Widget(
                "widget name",
                new[]
                    {
                        new Area(new IComponent[] { new Atom("atom", Enumerable.Empty<Parameter>()), new Atom("atom", Enumerable.Empty<Parameter>()) }),
                        new Area(new IComponent[] { new Atom("atom", Enumerable.Empty<Parameter>()), new Atom("atom", Enumerable.Empty<Parameter>()), new Atom("atom", Enumerable.Empty<Parameter>()) })
                    });

            var buildContext = MockRepository.GenerateStub<IBuildContext>();
            var widgetStack = new Stack<Queue<ComponentInstance>>();
            buildContext.Stub(c => c.WidgetSpecificationFinder).Return(n => specification);
            buildContext.Stub(c => c.AreaContents).Return(widgetStack);

            this.instance = (WidgetInstance)widget.Build(new[] { 0 }, buildContext);
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