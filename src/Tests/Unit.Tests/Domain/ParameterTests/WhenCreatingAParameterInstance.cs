namespace Unit.Tests.Domain.ParameterTests
{
    using FluentAssertions;

    using Kola.Domain;

    using NUnit.Framework;

    public class WhenCreatingAParameterInstance
    {
        private ParameterInstance parameterInstance;

        [SetUp]
        public void EstablishContext()
        {
            var parameter = new Parameter();

            this.parameterInstance = parameter.CreateInstance();
        }

        [Test]
        public void TheParameterInstanceShouldNotBeNull()
        {
            this.parameterInstance.Should().NotBeNull();
        }

        [Test]
        public void TheParameterInstanceShouldHaveTheCorrectName()
        {
            this.parameterInstance.Name.Should().Be("parameter name");
        }

        [Test]
        public void TheParameterInstanceShouldHaveTheCorrectValue()
        {
            this.parameterInstance.Value.Should().Be("parameter value");
        }
    }
}