namespace Unit.Tests.Domain.TemplateTests
{
    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Templates;
    using Kola.Domain.Templates.Amendments;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenAddingAnAmendment
    {
        private PageTemplate template;

        [SetUp]
        public void EstablishContext()
        {
            this.template = new PageTemplate(new[] { "path" });

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