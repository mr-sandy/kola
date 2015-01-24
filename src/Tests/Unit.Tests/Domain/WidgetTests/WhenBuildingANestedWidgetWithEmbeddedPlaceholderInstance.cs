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

    public class WhenBuildingANestedWidgetWithEmbeddedPlaceholderInstance
    {
        private WidgetInstance instance;

        [SetUp]
        /*
         * == given specifications ==
         * Widget specification 1
         * ├─ Atom A
         * ├─ Placeholder
         * └─ Container A
         *    └─ Placeholder
         * 
         * Widget specification 2
         * ├─ Placeholder
         * └─ Widget (widget specification 1)
         *    ├─ Area
         *    │  └─ Placeholder
         *    └─ Area
         *       └─ Atom B
         *
         * == and widget template ==
         * Widget (widget specification 2)
         * ├─ Area
         * │  └─ Atom C
         * └─ Area
         *    └─ Atom D
         * 
         * == should build to ==
         * WidgetInstance (widget specification 2)      0
         * ├─ PlaceholderInstance                       0.0
         * │  └─ AtomInstance C                         0.0.0
         * └─ WidgetInstance (widget specification 1)   1
         *    ├─ AtomInstance A                         1.0
         *    ├─ PlaceholderInstance                    1.1
         *    │  └─ PlaceholderInstance                 1.1.0
         *    │    └─ AtomInstance D                    1.1.0.0
         *    └─ ContainerInstance A                    1.2
         *       └─ PlaceholderInstance                 1.2.0
         *          └─ AtomInstance B                   1.2.0.0
         */
        public void EstablishContext()
        {
            var specification1 = new WidgetSpecification(
                "widget 1",
                Enumerable.Empty<PropertySpecification>(),
                new IComponent[]
                    {
                        new Atom("atom a", Enumerable.Empty<Property>()), 
                        new Placeholder("area 1"), 
                        new Container(
                            "container a",
                            Enumerable.Empty<Property>(),
                            new[]
                                {
                                    new Placeholder("area 2")
                                }) 
                    });

            var specification2 = new WidgetSpecification(
                "widget 2",
                Enumerable.Empty<PropertySpecification>(),
                new IComponent[]
                    {
                        new Placeholder("area 1"), 
                        new Widget(
                            "widget 1", 
                            new[]
                                {
                                    new Area(
                                        "area 1",
                                        new[]
                                            {
                                                new Placeholder("area 2")
                                        }),
                                    new Area(
                                        "area 2",
                                        new[]
                                            {
                                                new Atom("atom b", Enumerable.Empty<Property>())
                                        })
                                })
                    });

            var widget = new Widget(
                "widget 2",
                new[]
                    {
                        new Area(
                            "area 1", 
                            new IComponent[]
                                {
                                    new Atom("atom c", Enumerable.Empty<Property>())
                                }),
                        new Area(
                            "area 2", 
                            new IComponent[]
                                {
                                    new Atom("atom d", Enumerable.Empty<Property>()),
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
        public void WidgetInstanceShouldHaveTwoComponents()
        {
            this.instance.Components.Should().HaveCount(2);
        }

        [Test]
        public void Component_0_ShouldBeAPlaceholderInstance()
        {
            this.instance.Components.ElementAt(0).Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void Component_1_ShouldBeAWidgetInstance()
        {
            this.instance.Components.ElementAt(1).Should().BeOfType<WidgetInstance>();
        }

        [Test]
        public void Component_0_ShouldHaveOneComponent()
        {
            var placeholder = this.instance.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.Should().HaveCount(1);
        }

        [Test]
        public void Component_0_0_ShouldBeAnAtomInstance()
        {
            var placeholder = this.instance.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_0_0_ShouldBeAtomInstanceC()
        {
            var placeholder = this.instance.Components.ElementAt(0) as PlaceholderInstance;
            var atom = placeholder.Content.As<AreaInstance>().Components.ElementAt(0) as AtomInstance;
            atom.Name.Should().Be("atom c");
        }

        [Test]
        public void Component_1_ShouldHaveThreeComponents()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            widget.Components.Should().HaveCount(3);
        }

        [Test]
        public void Component_1_0_ShouldBeAnAtomInstance()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            widget.Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_1_0_ShouldBeAtomInstanceA()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var atom = widget.Components.ElementAt(0) as AtomInstance;
            atom.Name.Should().Be("atom a");
        }

        [Test]
        public void Component_1_1_ShouldBeAPlaceholderInstance()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            widget.Components.ElementAt(1).Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void Component_1_2_ShouldBeAContainerInstance()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            widget.Components.ElementAt(2).Should().BeOfType<ContainerInstance>();
        }

        [Test]
        public void Component_1_1_ShouldHaveOneComponent()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var placeholder = widget.Components.ElementAt(1) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.Should().HaveCount(1);
        }

        [Test]
        public void Component_1_1_0_ShouldBeAPlaceholderInstance()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var placeholder = widget.Components.ElementAt(1) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.ElementAt(0).Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void Component_1_1_0_ShouldHaveOneComponent()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var placeholder = widget.Components.ElementAt(1) as PlaceholderInstance;
            var placeholder2 = placeholder.Content.As<AreaInstance>().Components.ElementAt(0) as PlaceholderInstance;
            placeholder2.Content.As<AreaInstance>().Components.Should().HaveCount(1);
        }

        [Test]
        public void Component_1_1_0_0_ShouldBeAnAtomInstance()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var placeholder = widget.Components.ElementAt(1) as PlaceholderInstance;
            var placeholder2 = placeholder.Content.As<AreaInstance>().Components.ElementAt(0) as PlaceholderInstance;
            placeholder2.Content.As<AreaInstance>().Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_1_1_0_0_ShouldBeAtomInstanceD()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var placeholder = widget.Components.ElementAt(1) as PlaceholderInstance;
            var placeholder2 = placeholder.Content.As<AreaInstance>().Components.ElementAt(0) as PlaceholderInstance;
            var atom = placeholder2.Content.As<AreaInstance>().Components.ElementAt(0) as AtomInstance;
            atom.Name.Should().Be("atom d");
        }

        [Test]
        public void Component_1_2_ShouldHaveOneComponent()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var container = widget.Components.ElementAt(2) as ContainerInstance;
            container.Components.Should().HaveCount(1);
        }

        [Test]
        public void Component_1_2_0_ShouldBeAPlaceholderInstance()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var container = widget.Components.ElementAt(2) as ContainerInstance;
            container.Components.ElementAt(0).Should().BeOfType<PlaceholderInstance>();
        }

        [Test]
        public void Component_1_2_0_ShouldHaveOneComponent()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var container = widget.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.Should().HaveCount(1);
        }

        [Test]
        public void Component_1_2_0_0_ShouldBeAnAtomInstance()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var container = widget.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            placeholder.Content.As<AreaInstance>().Components.ElementAt(0).Should().BeOfType<AtomInstance>();
        }

        [Test]
        public void Component_1_2_0_0_ShouldBeAtomInstanceB()
        {
            var widget = this.instance.Components.ElementAt(1) as WidgetInstance;
            var container = widget.Components.ElementAt(2) as ContainerInstance;
            var placeholder = container.Components.ElementAt(0) as PlaceholderInstance;
            var atom = placeholder.Content.As<AreaInstance>().Components.ElementAt(0) as AtomInstance;
            atom.Name.Should().Be("atom b");
        }
    }
}