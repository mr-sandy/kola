namespace Unit.Tests.Domain.Templates
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Amendments;
    using Kola.Nancy.Modules;

    using NUnit.Framework;

    public class WhenApplyingAnAddComponentAmendmentToTheRoot
    {
        private Template template;

        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.template = new Template(templatePath);

            var amendment = new AddComponentAmendment("componentType", Enumerable.Empty<int>(), 0);
            this.template.AddAmendment(amendment);

            //TODO FIX THIS NEXT
            //this.template.ApplyAmendments(new ComponentFactory());
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            this.template.Components.Should().HaveCount(1);
        }

        [Test]
        public void ShouldHaveCorrectComponentType()
        {
            this.template.Components.ElementAt(0).Name.Should().Be("componentType");
        }
    }
}
