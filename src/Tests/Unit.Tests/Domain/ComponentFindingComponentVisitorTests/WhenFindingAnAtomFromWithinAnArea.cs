namespace Unit.Tests.Domain.ComponentFindingComponentVisitorTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;

    using NUnit.Framework;

    public class WhenFindingAnAtomFromWithinAnArea
    {
        private IComponent found;

        [SetUp]
        public void EstablishContext()
        {
            var components = new IComponent[]
                {
                    new Atom("atom 0"), 
                    new Container("container 1", components: new[] { new Atom("atom 1.0") }),
                    new Widget("widget 2", areas: new[] { new Area("area 1", new[] { new Atom("atom 2.0.0") }), })
                };

            var template = new Template(Enumerable.Empty<string>(), components);

            var visitor = new ComponentFindingComponentVisitor();

            this.found = visitor.Find(template, new[] { 2, 0, 0 });
        }

        [Test]
        public void TheCollectionShouldBeFound()
        {
            this.found.As<Atom>().Name.Should().Be("atom 2.0.0");
        }
    }
}