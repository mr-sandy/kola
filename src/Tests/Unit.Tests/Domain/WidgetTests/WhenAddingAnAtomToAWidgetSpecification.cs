namespace Unit.Tests.Domain.WidgetTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Specifications;
    using Kola.Domain.Composition;

    using NUnit.Framework;

    public class WhenAddingAnAtomToAWidgetSpecification
    {
        private WidgetSpecification widgetSpecification;

        [SetUp]
        public void EstablishContext()
        {
            this.widgetSpecification = new WidgetSpecification("widget name");
            this.widgetSpecification.AddComponent(new Atom("atom name", Enumerable.Empty<Parameter>()), 0);
        }

        [Test]
        public void TheSpecificataionShouldContainOneAtom()
        {
            this.widgetSpecification.Components.Single().Should().BeOfType<Atom>();
        }
    }
}