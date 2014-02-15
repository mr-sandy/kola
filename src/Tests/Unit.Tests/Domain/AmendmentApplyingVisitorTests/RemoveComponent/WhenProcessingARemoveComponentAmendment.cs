namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.RemoveComponent
{
    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;

    using NUnit.Framework;

    public class WhenProcessingARemoveComponentAmendment : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            this.Template.AddComponent(new Atom("existing", null), 0);

            var amendment = new RemoveComponentAmendment(new[] { 0 });

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void TheTemplateShouldContainNoComponents()
        {
            this.Template.Components.Should().HaveCount(0);
        }
    }
}