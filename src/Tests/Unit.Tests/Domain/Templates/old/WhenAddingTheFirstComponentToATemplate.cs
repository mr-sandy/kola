namespace Unit.Tests.Domain.Templates
{
    using System.Linq;

    using Kola.Domain;

    using NUnit.Framework;

    using AssertionExtensions = FluentAssertions.AssertionExtensions;

    public class WhenAddingTheFirstComponentToATemplate
    {
        private Template template;

        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.template = new Template(templatePath);

            var newComponent = new SimpleComponent("component1");
            this.template.AddComponent(newComponent);
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            AssertionExtensions.Should((int)this.template.Components.Count()).Be(1);
        }
    }
}