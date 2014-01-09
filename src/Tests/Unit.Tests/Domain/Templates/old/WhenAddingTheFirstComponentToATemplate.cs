namespace Unit.Tests.Domain.Templates.old
{
    using FluentAssertions;

    using Kola.Domain;

    using NUnit.Framework;

    public class WhenAddingTheFirstComponentToATemplate
    {
        private Template template;

        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.template = new Template(templatePath);

            var newComponent = new Atom("component1");
            this.template.AddComponent(newComponent, 0);
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            this.template.Components.Should().HaveCount(1);
        }
    }
}