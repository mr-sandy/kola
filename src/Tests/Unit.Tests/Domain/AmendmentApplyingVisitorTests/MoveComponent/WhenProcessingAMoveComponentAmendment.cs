namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.MoveComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;

    using NUnit.Framework;

    public class WhenProcessingAMoveComponentAmendment : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            this.Template.Insert(0, new Atom("first", null));
            this.Template.Insert(1, new Atom("second", null));

            var amendment = new MoveComponentAmendment(new[] { 0 }, new[] { 1 });

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void TheTemplatesFirstAtomShouldBecomeItsSecond()
        {
            this.Template.Components.Second().As<Atom>().Name.Should().Be("first");
        }

        [Test]
        public void TheTemplatesSecondAtomShouldBecomeItsFirst()
        {
            this.Template.Components.First().As<Atom>().Name.Should().Be("second");
        }
    }
}