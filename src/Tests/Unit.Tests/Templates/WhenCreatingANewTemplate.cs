using System.Linq;
using FluentAssertions;
using Kola.Domain;
using NUnit.Framework;

namespace Unit.Tests.Templates
{
    public class WhenCreatingANewTemplate : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] {"test", "path"};
            this.template = new Template(templatePath);
        }
    }

    public class WhenAddingTheFirstComponentToATemplate : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var templatePath = new[] { "test", "path" };
            this.template = new Template(templatePath);

            var newComponent = new Atom();
            template.AddChild(0, newComponent);
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            this.template.Components.Count().Should().Be(1);
        }
    }
}
