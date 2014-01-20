namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.MoveComponent
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.Amendments;

    using NUnit.Framework;

    public class WhenProcessingAMoveComponentAmendment : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            this.Template.AddComponent(new Atom("first", null), 0);
            this.Template.AddComponent(new Atom("second", null), 1);

            var amendment = new MoveComponentAmendment(new[] { 0 }, new[] { 1 });

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void TheTemplatesFirstAtomShouldBecomeItsSecond()
        {
            this.Template.Components.Second().Name.Should().Be("first");
        }

        [Test]
        public void TheTemplatesSecondAtomShouldBecomeItsFirst()
        {
            this.Template.Components.First().Name.Should().Be("second");
        }
    }
}