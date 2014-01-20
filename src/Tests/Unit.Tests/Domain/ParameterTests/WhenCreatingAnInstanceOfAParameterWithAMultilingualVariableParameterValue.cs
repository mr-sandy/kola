namespace Unit.Tests.Domain.ParameterTests
{
    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Instances;
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.ParameterValues;

    using NUnit.Framework;

    public class WhenCreatingAnInstanceOfAParameterWithAMultilingualVariableParameterValue
    {
        private ParameterInstance parameterInstance;

        [SetUp]
        public void EstablishContext()
        {
            var parameter = new Parameter("parameter name")
                {
                    Value =
                        new MultilingualParameterValue(
                        new[]
                            {
                                new MultilingualVariant("en", "English"), 
                                new MultilingualVariant("fr", "Français")
                            })
                };

            var context = new Context { LanguageCode = "fr" };

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
            this.parameterInstance.Value.Should().Be("Français");
        }
    }
}