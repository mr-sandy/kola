namespace Unit.Tests.Domain.Templates.Amendments.UpdateParameters
{
    using Kola.Domain;

    using NUnit.Framework;

    public class WhenApplyingAnUpdateParametersAmendmentForASingleParameter
    {
        [SetUp]
        public void EstablishContext()
        {
            var component = new Atom("atom1");
            var template = new Template(new[] { "path" }, components: new[] { component });
        }

        [Test]
        public void TheParameterShouldHaveTheUpdatedValue()
        {
        }
    }
}
