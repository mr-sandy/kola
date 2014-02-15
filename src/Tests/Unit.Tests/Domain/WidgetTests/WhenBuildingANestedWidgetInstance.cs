namespace Unit.Tests.Domain.WidgetTests
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;
    using Kola.Domain.Specifications;
    using Kola.Domain.Composition;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenBuildingANestedWidgetInstance
    {
        private WidgetInstance instance;

        [SetUp]
        /*
         * == given specifications ==
         * Widget specification 1
         * ├─ Atom
         * ├─ Placeholder
         * └─ Container
         *    └─ Placeholder
         * 
         * Widget specification 2
         * ├─ Atom
         * └─ Placeholder
         *
         * == and widget template ==
         * Widget (widget specification 1)
         * ├─ Area
         * │  └─ Atom
         * └─ Area
         *    ├─ Atom
         *    ├─ Atom
         *    └─ Widget (widget specification 2)
         *       └─ Area
         *          └─ Atom
         *
         * == should build to ==
         * WidgetInstance (widget specification 1)
         * ├─ AtomInstance
         * ├─ PlaceholderInstance
         * │  └─ AtomInstance
         * └─ ContainerInstance
         *    └─ PlaceholderInstance
         *       ├─ AtomInstance
         *       ├─ AtomInstance
         *       └─ WidgetInstance (widget specification 2)
         *          ├─ AtomInstance
         *          └─ PlaceholderInstance
         *             └─ Atom
         */
        public void EstablishContext()
        {
            var specification1 = new WidgetSpecification(
                "widget 1",
                new IComponent[]
                    {
                        new Atom("atom", Enumerable.Empty<Parameter>()), 
                        new Placeholder(), 
                        new Container(
                            "container",
                            Enumerable.Empty<Parameter>(),
                            new[] { new Placeholder() }) 
                    });

            var specification2 = new WidgetSpecification(
                "widget 2",
                new IComponent[]
                    {
                        new Atom("atom", Enumerable.Empty<Parameter>()), 
                        new Placeholder()
                    });

            var widget = new Widget(
                "widget 1",
                Enumerable.Empty<Parameter>(),
                new[]
                    {
                        new Area(
                            new IComponent[]
                            {
                                new Atom("atom", Enumerable.Empty<Parameter>())
                            }),
                        new Area(
                            new IComponent[]
                            {
                                new Atom("atom", Enumerable.Empty<Parameter>()),
                                new Atom("atom", Enumerable.Empty<Parameter>()),
                                new Widget(
                                    "widget 2", 
                                    Enumerable.Empty<Parameter>(),
                                    new[]
                                        {
                                            new Area(new[]
                                                {
                                                    new Atom("atom", Enumerable.Empty<Parameter>())
                                                })
                                        })
                            })
                    });

            var buildContext = MockRepository.GenerateStub<IBuildContext>();
            buildContext.Stub(c => c.WidgetSpecificationFinder).Return(n => n == "widget 1" ? specification1 : specification2);
            buildContext.Stub(c => c.Areas).Return(new Stack<Queue<IEnumerable<IComponentInstance>>>());

            this.instance = (WidgetInstance)widget.Build(buildContext);
        }

        [Test]
        public void WidgetInstanceShouldHaveThreeComponents()
        {
            this.instance.Components.Should().HaveCount(3);
        }

        [Test]
        public void Component_0_ShouldBeAnAtomInstance()
        {
            this.instance.Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_1_ShouldBeAnPlaceholderInstance()
        {
            this.instance.Components.ElementAt(1).Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void Component_2_ShouldBeAnContainerInstance()
        {
            this.instance.Components.ElementAt(2).Should().BeOfType<ContainerInstance>();
        }

        [Test]
        public void Component_1_ShouldHaveOneComponent()
        {
            var placeholder = this.instance.Components.ElementAt(1) as PlaceholderInstance;
            placeholder.Components.Should().HaveCount(1);
        }

        [Test]
        public void Component_1_0_ShouldBeAnAtomInstance()
        {
            var placeholder = this.instance.Components.ElementAt(1) as PlaceholderInstance;
            placeholder.Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_2_ShouldHaveOneComponent()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            container.Components.Should().HaveCount(1);
        }

        [Test]
        public void Component_2_0_ShouldBeAPlaceholderInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            container.Components.ElementAt(0).Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void Component_2_0_ShouldHaveThreeComponents()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Components.Should().HaveCount(3);
        }

        [Test]
        public void Component_2_0_0_ShouldBeAnAtomInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_2_0_1_ShouldBeAnAtomInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Components.ElementAt(1).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_2_0_2_ShouldBeAWidgetInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Components.ElementAt(2).Should().BeOfType<WidgetInstance>();
        }

        [Test]
        public void Component_2_0_2_ShouldHaveTwoComponents()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var widget = placeholder.Components.ElementAt(2) as WidgetInstance;
            widget.Components.Should().HaveCount(2);
        }

        [Test]
        public void Component_2_0_2_0_ShouldBeAnAtomInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var widget = placeholder.Components.ElementAt(2) as WidgetInstance;
            widget.Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_2_0_2_1_ShouldBeAPlaceholderInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var widget = placeholder.Components.ElementAt(2) as WidgetInstance;
            widget.Components.ElementAt(1).Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void Component_2_0_2_1_ShouldBeHaveOneComponent()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var widget = placeholder.Components.ElementAt(2) as WidgetInstance;
            var placeholder2 = widget.Components.ElementAt(1) as PlaceholderInstance;
            placeholder2.Components.Should().HaveCount(1);
        }

        [Test]
        public void Component_2_0_2_1_0_ShouldBeAnAtomInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var widget = placeholder.Components.ElementAt(2) as WidgetInstance;
            var placeholder2 = widget.Components.ElementAt(1) as PlaceholderInstance;
            placeholder2.Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }
    }
}