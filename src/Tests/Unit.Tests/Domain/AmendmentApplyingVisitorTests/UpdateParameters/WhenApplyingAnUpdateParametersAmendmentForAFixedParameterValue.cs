namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.UpdateParameters
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Composition.ParameterValues;

    using NUnit.Framework;

    public class WhenApplyingAnUpdateParametersAmendmentForAFixedParameterValue : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            this.Template.AddComponent(
                new Atom("existing", new[] { new Parameter("parameter name", "parameter type"), }), 0);

            var amendment = new UpdateParameterAmendment("parameter name", "updated value", new[] { 0 });

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void TheParameterShouldBeOfTheCorrectType()
        {
            this.Template.Components.First().As<Atom>().Parameters.Single().Value.Should().BeOfType<FixedParameterValue>();
        }

        [Test]
        public void TheParameterShouldHaveTheCorrectValue()
        {
            var value = (FixedParameterValue)this.Template.Components.First().As<Atom>().Parameters.Single().Value;

            value.Value.Should().Be("updated value");
        }
    }
}