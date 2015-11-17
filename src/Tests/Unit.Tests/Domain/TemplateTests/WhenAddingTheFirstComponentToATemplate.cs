namespace Unit.Tests.Domain.TemplateTests
{
    using FluentAssertions;

    using Kola.Domain;
    using Kola.Domain.Composition;

    using NUnit.Framework;

    public class WhenAddingTheFirstComponentToATemplate
    {
        private Template template;

        [SetUp]
        public void SetUp()
        {
            var templatePath = new[] { "test", "path" };
            this.template = new Template(templatePath);

            var newComponent = new Atom("component1", null);
            this.template.Insert(0, newComponent);
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            this.template.Components.Should().HaveCount(1);
        }
    }
}