namespace Unit.Tests.Domain.ParameterTests
{
    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Composition.ParameterValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    using NUnit.Framework;

    public class WhenCreatingAnInstanceOfAParameterWithAMultilingualVariableParameterValue
    {
        private ParameterInstance parameterInstance;

        [SetUp]
        public void EstablishContext()
        {
            var parameter = new Parameter(
                "parameter name",
                "parameter type",
                new MultilingualParameterValue(
                    new[]
                        {
                            new MultilingualVariant("en", "English"), 
                            new MultilingualVariant("fr", "Français")
                        }));

            var context = new Context { LanguageCode = "fr" };

            this.parameterInstance = parameter.Build(new BuildContext { Contexts = new[] { context } });
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