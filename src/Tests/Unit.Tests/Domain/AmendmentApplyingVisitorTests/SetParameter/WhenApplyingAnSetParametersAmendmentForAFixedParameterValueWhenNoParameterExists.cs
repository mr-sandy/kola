namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.SetParameter
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.Amendments;
    using Kola.Domain.Composition.ParameterValues;
    using Kola.Domain.Specifications;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenApplyingASetParametersAmendmentForAFixedParameterValueWhenNoParameterExists : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            this.Template.Insert(0, new Atom("the atom", Enumerable.Empty<Parameter>()));

            var parameterSpecification = new ParameterSpecification("parameter name", "parameter type");

            this.ComponentSpecification.Stub(s => s.Parameters).Return(new[] { parameterSpecification });

            var amendment = new SetParameterAmendment("parameter name", "updated value", new[] { 0 });

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