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

//            template.AddComponent
        }

        [Test]
        public void ShouldHaveOneComponent()
        {
            this.template.Components.Count().Should().Be(1);
        }
    }
}
