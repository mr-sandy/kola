namespace Unit.Tests.Domain.Templates.Amendments
{
    using FluentAssertions;

    using Kola.Domain.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Kola.Domain;

    public class WhenAddingAnAmendment
    {
        private Template template;

        [SetUp]
        public void EstablishContext()
        {
            this.template = new Template(new[] { "path" });

            var amendment = MockRepository.GenerateStub<IAmendment>();

            this.template.AddAmendment(amendment);
        }

        [Test]
        public void TheTemplateShouldHaveOneAmendment()
        {
            this.template.Amendments.Should().HaveCount(1);
        }
    }
}