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
            this.Template = new Template(templatePath);

            var newComponent = new SimpleComponent("component1");
            this.Template.AddComponent(newComponent);
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            AssertionExtensions.Should((int)this.Template.Components.Count()).Be(1);
        }
    }
}