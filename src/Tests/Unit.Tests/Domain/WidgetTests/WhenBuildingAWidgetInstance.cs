namespace Unit.Tests.Domain.WidgetTests
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Instances;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

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
                new IComponentTemplate[]
                    {
                        new AtomTemplate("atom", Enumerable.Empty<ParameterTemplate>()), 
                        new PlaceholderTemplate(), 
                        new ContainerTemplate("container", Enumerable.Empty<ParameterTemplate>(), new[] { new PlaceholderTemplate() }) 
                    });

            var widget = new WidgetTemplate(
                "widget name",
                Enumerable.Empty<ParameterTemplate>(),
                new[]
                    {
                        new Area(new IComponentTemplate[] { new AtomTemplate("atom", Enumerable.Empty<ParameterTemplate>()), new AtomTemplate("atom", Enumerable.Empty<ParameterTemplate>()) }),
                        new Area(new IComponentTemplate[] { new AtomTemplate("atom", Enumerable.Empty<ParameterTemplate>()), new AtomTemplate("atom", Enumerable.Empty<ParameterTemplate>()), new AtomTemplate("atom", Enumerable.Empty<ParameterTemplate>()) })
                    });

            var buildContext = MockRepository.GenerateStub<IBuildContext>();
            var widgetStack = new Stack<Queue<Area>>();
            buildContext.Stub(c => c.WidgetSpecificationFinder).Return(n => specification);
            buildContext.Stub(c => c.Areas).Return(widgetStack);

            this.instance = (WidgetInstance)widget.Build(buildContext);
        }

        [Test]
        public void WidgetInstanceShouldHaveThreeChildren()
        {
            this.instance.Children.Should().HaveCount(3);
        }

        [Test]
        public void FirstPlaceholderInstanceShouldHaveTwoChildren()
        {
            var placeholder = this.instance.Children.ElementAt(1) as PlaceholderInstance;
            placeholder.Components.Should().HaveCount(2);
        }

        [Test]
        public void ContainerIntanceShouldContainPlaceholderInstance()
        {
            var containerInstance = (ContainerInstance)this.instance.Children.ElementAt(2);

            containerInstance.Children.Single().Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void SecondPlaceholderInstanceShouldHaveThreeChildren()
        {
            var containerInstance = (ContainerInstance)this.instance.Children.ElementAt(2);
            var placeholder = containerInstance.Children.Single() as PlaceholderInstance;
            placeholder.Components.Should().HaveCount(3);
        }
    }
}