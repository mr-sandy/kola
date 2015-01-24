using NUnit.Framework;

namespace Unit.Tests.Domain.WidgetTests
{
    using System;
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
                Enumerable.Empty<PropertySpecification>(),
                new IComponent[]
                    {
                        new Atom("atom", Enumerable.Empty<Property>()), 
                        new Placeholder("area 1"), 
                        new Container(
                            "container",
                            Enumerable.Empty<Property>(),
                            new[] { new Placeholder("area 2") }) 
                    });

            var specification2 = new WidgetSpecification(
                "widget 2",
                Enumerable.Empty<PropertySpecification>(),
                new IComponent[]
                    {
                        new Atom("atom", Enumerable.Empty<Property>()), 
                        new Placeholder("area 1")
                    });

            var widget = new Widget(
                "widget 1",
                new[]
                    {
                        new Area(
                            "area 1", 
                            new IComponent[]
                            {
                                new Atom("atom", Enumerable.Empty<Property>())
                            }),
                        new Area(
                            "area 2", 
                            new IComponent[]
                            {
                                new Atom("atom", Enumerable.Empty<Property>()),
                                new Atom("atom", Enumerable.Empty<Property>()),
                                new Widget(
                                    "widget 2", 
                                    new[]
                                        {
                                            new Area(
                                                "area 1", 
                                                new[]
                                                {
                                                    new Atom("atom", Enumerable.Empty<Property>())
                                                })
                                        })
                            })
                    });

            var buildContext = new BuildContext
                {
                    WidgetSpecificationFinder = n => n == "widget 1" ? specification1 : specification2
                };

            var builder = new Builder(new RenderingInstructions(false, true));
            this.instance = (WidgetInstance)widget.Build(builder, new[] { 0 }, buildContext);
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
            placeholder.Content.As<AreaInstance>().Components.Should().HaveCount(1);
        }

        [Test]
        public void Component_1_0_ShouldBeAnAtomInstance()
        {
            var placeholder = this.instance.Components.ElementAt(1) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.ElementAt(0).Should().BeOfType<AtomInstance>();
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
            placeholder.Content.As<AreaInstance>().Components.Should().HaveCount(3);
        }

        [Test]
        public void Component_2_0_0_ShouldBeAnAtomInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_2_0_1_ShouldBeAnAtomInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.ElementAt(1).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_2_0_2_ShouldBeAWidgetInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.ElementAt(2).Should().BeOfType<WidgetInstance>();
        }

        [Test]
        public void Component_2_0_2_ShouldHaveTwoComponents()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var widget = placeholder.Content.As<AreaInstance>().Components.ElementAt(2) as WidgetInstance;
            widget.Components.Should().HaveCount(2);
        }

        [Test]
        public void Component_2_0_2_0_ShouldBeAnAtomInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var widget = placeholder.Content.As<AreaInstance>().Components.ElementAt(2) as WidgetInstance;
            widget.Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_2_0_2_1_ShouldBeAPlaceholderInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var widget = placeholder.Content.As<AreaInstance>().Components.ElementAt(2) as WidgetInstance;
            widget.Components.ElementAt(1).Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void Component_2_0_2_1_ShouldBeHaveOneComponent()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var widget = placeholder.Content.As<AreaInstance>().Components.ElementAt(2) as WidgetInstance;
            var placeholder2 = widget.Components.ElementAt(1) as PlaceholderInstance;
            placeholder2.Content.As<AreaInstance>().Components.Should().HaveCount(1);
        }

        [Test]
        public void Component_2_0_2_1_0_ShouldBeAnAtomInstance()
        {
            var container = this.instance.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var widget = placeholder.Content.As<AreaInstance>().Components.ElementAt(2) as WidgetInstance;
            var placeholder2 = widget.Components.ElementAt(1) as PlaceholderInstance;
            placeholder2.Content.As<AreaInstance>().Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }
    }
}