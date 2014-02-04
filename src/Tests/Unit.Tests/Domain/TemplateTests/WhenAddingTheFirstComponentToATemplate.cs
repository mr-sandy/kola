namespace Unit.Tests.Domain.TemplateTests
{
    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Templates;

    using NUnit.Framework;

    public class WhenAddingTheFirstComponentToATemplate
    {
        private PageTemplate template;

        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.template = new PageTemplate(templatePath);

            var newComponent = new AtomTemplate("component1", null);
            this.template.AddComponent(newComponent, 0);
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            this.template.Components.Should().HaveCount(1);
        }
    }
}