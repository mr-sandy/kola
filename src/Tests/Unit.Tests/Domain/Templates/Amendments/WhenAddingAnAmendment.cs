namespace Unit.Tests.Domain.Templates.Amendments
{
    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    using Unit.Tests.Domain.Fake;

    public class WhenAddingAnAmendment
    {
        private Template template;

        [SetUp]
        public void EstablishContext()
        {
            this.template = new Template();

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