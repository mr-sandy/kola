namespace Unit.Tests.Domain.ParameterTests
{
    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Composition;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenSettingAFixedValueForAParameter
    {
        [SetUp]
        public void EstablishContext()
        {
            var parameter = new Parameter(string.Empty, string.Empty);
        }

        [Test]
        public void TheTemplateShouldHaveOneAmendment()
        {
        }
    }
}