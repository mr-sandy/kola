namespace Unit.Tests.Domain.ParameterTests
{
    using FluentAssertions;

    using Kola.Domain;

    using NUnit.Framework;

    public class WhenCreatingAnInstanceOfAParameterWithAnInheritedParameterValue
    {
        private ParameterInstance parameterInstance;

        [SetUp]
        public void EstablishContext()
        {
            var parameter = new Parameter("parameter name")
                {
                    Value = new InheritedParameterValue("key")
                };

            var context = new Context { Items = new[] { new ContextItem("key", "result") } };

            this.parameterInstance = parameter.CreateInstance(new[] { context });
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
            this.parameterInstance.Value.Should().Be("result");
        }
    }
}