namespace Unit.Tests.Domain.ParameterTests
{
    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenSettingAFixedValueForAParameter
    {
        [SetUp]
        public void EstablishContext()
        {
            var parameter = new Parameter();
        }

        [Test]
        public void TheTemplateShouldHaveOneAmendment()
        {
        }
    }
}