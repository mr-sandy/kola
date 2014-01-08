namespace Unit.Tests.Templates
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Amendments;
    using Kola.Nancy.Modules;

    using NUnit.Framework;

    public class WhenApplyingAnAddComponentAmendmentToTheRoot : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.Template = new Template(templatePath);

            var amendment = new AddComponentAmendment("componentType", Enumerable.Empty<int>(), 0);
            this.Template.AddAmendment(amendment);

            this.Template.ApplyAmendments(new ComponentFactory());
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
