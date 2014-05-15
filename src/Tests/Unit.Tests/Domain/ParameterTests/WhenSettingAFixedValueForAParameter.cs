namespace Unit.Tests.Domain.ParameterTests
{
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.ParameterValues;

    using NUnit.Framework;

    public class WhenSettingAFixedValueForAParameter
    {
        [SetUp]
        public void EstablishContext()
        {
            var parameter = new Parameter(string.Empty, string.Empty, new FixedParameterValue("value"));
        }

        [Test]
        public void TheTemplateShouldHaveOneAmendment()
        {
        }
    }
}