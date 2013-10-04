namespace Unit.Tests.Templates
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;

    using NUnit.Framework;

    public class WhenApplyingAnAddComponentAmendmentToTheRoot : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.Template = new Template(templatePath);

            var amendment = new AddComponentAmendment("componentType", string.Empty, 0);
            this.Template.AddAmendment(amendment);

            var processor = new AmendmentProcessingVisitor(this.Template);

            foreach (var amendment1 in this.Template.Amendments)
            {
                amendment1.Accept(processor);
            }
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            this.Template.Components.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveCorrectComponentType()
        {
            this.Template.Components.ElementAt(0).Name.Should().Be("componentType");
        }
    }
}
