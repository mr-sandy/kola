namespace Unit.Tests.Domain.CollectionFindingComponentVisitorTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;

    using NUnit.Framework;

    public class WhenFindingATemplate
    {
        private IComponentCollection found;

        [SetUp]
        public void EstablishContext()
        {
            var components = new IComponent[]
                {
                    new Atom("atom 0"), 
                    new Container("container 1", components: new[] { new Atom("atom 1.0") }),
                    new Widget("widget 2", areas: new[] { new Area(new[] { new Atom("atom 2.0.0") }), })
                };

            var template = new Template(Enumerable.Empty<string>(), components);

            var visitor = new CollectionFindingComponentVisitor();

            this.found = visitor.Find(template, new int[] { });
        }

        [Test]
        public void TheCollectionShouldBeFound()
        {
            this.found.Should().BeOfType<Template>();
        }
    }
}