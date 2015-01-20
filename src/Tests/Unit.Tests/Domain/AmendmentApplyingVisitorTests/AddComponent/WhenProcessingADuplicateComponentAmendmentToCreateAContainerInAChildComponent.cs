namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.AddComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Composition.PropertyValues;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenProcessingADuplicateComponentAmendmentToCreateAContainerInAChildComponent : ContextBase
    {
        private Container parent;

        [SetUp]
        public void EstablishContext()
        {
            this.parent = new Container("parent");
            this.Template.Insert(0, this.parent);

            // add the container to be duplicated
            var container = new Container(
                "container",
                new[] { new Property("container property", "container property type", new FixedPropertyValue("container property value")) });
            var atom = new Atom(
                "atom",
                new[] { new Property("atom property", "atom property type", new FixedPropertyValue("atom property value")) });
            container.Insert(0, atom);

            this.parent.Insert(0, container);

            var amendment = new DuplicateComponentAmendment(new[] { 0, 0 });

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void TheParentShouldContainTwoComponents()
        {
            this.parent.Components.Should().HaveCount(2);
        }

        [Test]
        public void TheSecondComponentShouldBeAContainer()
        {
            this.parent.Components.Second().Should().BeOfType<Container>();
        }

        [Test]
        public void TheContainerShouldHaveOneProperty()
        {
            var container = (Container)this.parent.Components.Second();
            container.Properties.Should().HaveCount(1);
        }

        [Test]
        public void TheContainerPropertyShouldHaveTheCorrectName()
        {
            var container = (Container)this.parent.Components.Second();
            var property = container.Properties.Single();
            property.Name.Should().Be("container property");
        }

        [Test]
        public void TheContainerPropertyShouldHaveTheCorrectType()
        {
            var container = (Container)this.parent.Components.Second();
            var property = container.Properties.Single();
            property.Type.Should().Be("container property type");
        }

        [Test]
        public void TheContainerPropertyShouldHaveAFixedValue()
        {
            var container = (Container)this.parent.Components.Second();
            var property = container.Properties.Single();
            property.Value.Should().BeOfType<FixedPropertyValue>();
        }

        [Test]
        public void TheContainerPropertyValueShouldHaveTheCorrectValue()
        {
            var container = (Container)this.parent.Components.Second();
            var property = container.Properties.Single();
            var value = (FixedPropertyValue)property.Value;
            value.Value.Should().Be("container property value");
        }

        [Test]
        public void TheSecondComponentShouldContainerOneComponent()
        {
            var container = (Container)this.parent.Components.Second();
            container.Components.Should().HaveCount(1);
        }

        [Test]
        public void TheSecondComponentsChildShouldBeAnAtom()
        {
            var container = (Container)this.parent.Components.Second();
            container.Components.Single().Should().BeOfType<Atom>();
        }

        [Test]
        public void TheAtomShouldHaveOneProperty()
        {
            var container = (Container)this.parent.Components.Second();
            var atom = (Atom)container.Components.Single();
            atom.Properties.Should().HaveCount(1);
        }

        [Test]
        public void TheAtomPropertyShouldHaveTheCorrectName()
        {
            var container = (Container)this.parent.Components.Second();
            var atom = (Atom)container.Components.Single();
            var property = atom.Properties.Single();
            property.Name.Should().Be("atom property");
        }

        [Test]
        public void TheAtomPropertyShouldHaveTheCorrectType()
        {
            var container = (Container)this.parent.Components.Second();
            var atom = (Atom)container.Components.Single();
            var property = atom.Properties.Single();
            property.Type.Should().Be("atom property type");
        }

        [Test]
        public void TheAtomPropertyShouldHaveAFixedValue()
        {
            var container = (Container)this.parent.Components.Second();
            var atom = (Atom)container.Components.Single();
            var property = atom.Properties.Single();
            property.Value.Should().BeOfType<FixedPropertyValue>();
        }

        [Test]
        public void TheAtomPropertyValueShouldHaveTheCorrecyValue()
        {
            var container = (Container)this.parent.Components.Second();
            var atom = (Atom)container.Components.Single();
            var property = atom.Properties.Single();
            var value = (FixedPropertyValue)property.Value;
            value.Value.Should().Be("atom property value");
        }
    }
}