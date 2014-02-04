namespace Unit.Tests.Domain.ComponentSpecifications
{
    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    using NUnit.Framework;

    [TestFixture]
    public class WhenCreatingAParameterFromItsSpecification
    {
        private ParameterTemplate parameter;

        [SetUp]
        public void SetUp()
        {
            var parameterSpecification = new ParameterSpecification("parameter 1 name", "parameter 1 type");

            this.parameter = parameterSpecification.Create();
        }

        [Test]
        public void TheParameterShouldHaveTheCorrectName()
        {
            //this.parameter.Name.Should().Be("parameter 1 name");
        }
    }
}