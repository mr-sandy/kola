namespace Unit.Tests.Domain.WidgetTests
{
    using System.Linq;

    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    using NUnit.Framework;

    public class WhenCreatingAWidgetSpecification
    {
        private Template template;

        [SetUp]
        public void EstablishContext()
        {
            var widgetSpecification = new WidgetSpecification("widget name");
            widgetSpecification.AddComponent(new Atom("atom name", Enumerable.Empty<Parameter>()), 0);
        }

        [Test]
        public void TheTemplateShouldHaveOneAmendment()
        {
        }
    }
}