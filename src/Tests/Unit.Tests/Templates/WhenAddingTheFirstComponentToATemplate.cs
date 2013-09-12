namespace Unit.Tests.Templates
{
    using System.Linq;

    using Kola.Domain;

    using NUnit.Framework;

    using AssertionExtensions = FluentAssertions.AssertionExtensions;

    public class WhenAddingTheFirstComponentToATemplate : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.template = new Template(templatePath);

            var newComponent = new Component("component1");
            template.AddComponent(newComponent);
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            AssertionExtensions.Should((int)this.template.Components.Count()).Be(1);
        }
    }
}