namespace Integration.Tests.Nancy.Modules.TemplatesModuleSpecs.WidgetTests
{
    using FluentAssertions;

    using Kola.Domain.Specifications;
    using Kola.Domain.Templates;

    using global::Nancy;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenCreatingAWidget : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var widgetName = "widgetName";

            this.Response = this.Browser.Put(string.Format("/_kola/widgets/{0}", widgetName));
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldAddTemplateToRepository()
        {
            this.WidgetSpecificationRepository.AssertWasCalled(r => r.Add(Arg<WidgetSpecification>.Is.Anything));
        }

        [Test]
        public void ShouldAddTemplateWithCorrectPath()
        {
            var args = this.WidgetSpecificationRepository.GetArgumentsForCallsMadeOn(r => r.Add(Arg<WidgetSpecification>.Is.Anything));
            var widgetSpecification = (WidgetSpecification)args[0][0];
            widgetSpecification.Name.Should().Be("widgetName");
        }
    }
}
