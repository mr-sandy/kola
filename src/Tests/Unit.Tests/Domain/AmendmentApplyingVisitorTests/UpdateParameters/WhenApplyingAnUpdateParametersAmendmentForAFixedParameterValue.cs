namespace Unit.Tests.Domain.AmendmentApplyingVisitorTests.UpdateParameters
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.Amendments;
    using Kola.Domain.Templates.ParameterValues;

    using NUnit.Framework;

    public class WhenApplyingAnUpdateParametersAmendmentForAFixedParameterValue : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            this.Template.AddComponent(
                new AtomTemplate("existing", new[] { new ParameterTemplate("parameter name", "parameter type"), }), 0);

            var amendment = new UpdateParameterAmendment("parameter name", "updated value", new[] { 0 });

            this.Visitor.Visit(amendment);
        }

        [Test]
        public void TheParameterShouldBeOfTheCorrectType()
        {
            this.Template.Components.First().As<AtomTemplate>().Parameters.Single().Value.Should().BeOfType<FixedParameterValue>();
        }

        [Test]
        public void TheParameterShouldHaveTheCorrectValue()
        {
            var value = (FixedParameterValue)this.Template.Components.First().As<AtomTemplate>().Parameters.Single().Value;

            value.Value.Should().Be("updated value");
        }
    }
}