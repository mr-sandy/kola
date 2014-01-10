namespace Unit.Tests.Domain.TemplateTests
{
    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

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