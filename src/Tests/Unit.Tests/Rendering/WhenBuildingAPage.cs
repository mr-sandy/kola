namespace Unit.Tests.Rendering
{
    using Kola.Domain;

    using NUnit.Framework;

    public class WhenBuildingAPage
    {

        [SetUp]
        public void EstablishContext()
        {
            var components = new Component[] { };

            var template = new Template(new[] { "path" }, null, components);

        }

        [Test]
        public void ShouldReturnAResult()
        {
        }

    }
}