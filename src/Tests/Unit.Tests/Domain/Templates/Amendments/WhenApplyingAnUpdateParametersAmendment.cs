namespace Unit.Tests.Domain.Templates.Amendments
{
    using System.Linq;

    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Unit.Tests.Domain.Fake;
    using Unit.Tests.Domain.Fake.Amendments;

    public class WhenApplyingAnUpdateParametersAmendmentForASingleParameter
    {
        [SetUp]
        public void EstablishContext()
        {
            var component = new Atom();
            var template = new Template(components: new[] { component });
        }

        [Test]
        public void TheParameterShouldHaveTheUpdatedValue()
        {
        }
    }
}