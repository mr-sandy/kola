namespace Unit.Tests.Domain.PropertyTests
{
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;

    using NUnit.Framework;

    public class WhenSettingAFixedValueForAProperty
    {
        [SetUp]
        public void EstablishContext()
        {
            var property = new Property(string.Empty, string.Empty, new FixedPropertyValue("value"));
        }

        [Test]
        public void TheTemplateShouldHaveOneAmendment()
        {
        }
    }
}