namespace Integration.Tests.Nancy.Modules.WidgetModuleTests
{
    using FluentAssertions;

    using global::Nancy;
    using global::Nancy.Testing;

    using Kola.Domain.Specifications;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenCreatingAWidget : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var widgetName = "widgetName";

            this.Response = this.Browser.Put("/_kola/widgets",
                context =>
                    {
                        context.Query("name", widgetName);
                        context.Accept("application/json");
                    });
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldAddTemplateToRepository()
        {
            this.WidgetSpecificationRepository.AssertWasCalled(r => r.Save(Arg<WidgetSpecification>.Is.Anything));
        }

        [Test]
        public void ShouldAddTemplateWithCorrectPath()
        {
            var args = this.WidgetSpecificationRepository.GetArgumentsForCallsMadeOn(r => r.Save(Arg<WidgetSpecification>.Is.Anything));
            var widgetSpecification = (WidgetSpecification)args[0][0];
            widgetSpecification.Name.Should().Be("widgetName");
        }
    }
}
