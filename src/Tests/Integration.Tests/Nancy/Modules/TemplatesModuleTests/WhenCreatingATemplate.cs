namespace Integration.Tests.Nancy.Modules.TemplatesModuleTests
{
    using FluentAssertions;

    using global::Nancy;

    using Kola.Domain.Composition;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenCreatingATemplate : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var templatePath = @"test/path";

            this.Response = this.Browser.Put((string)$"/_kola/templates/{templatePath}",
                with => with.Header("Accept", "application/json"));
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldReturnALocationHeader()
        {
            this.Response.Headers["location"].Should().Be("/test/path");
        }

        [Test]
        public void ShouldAddTemplateToRepository()
        {
            this.ContentRepository.AssertWasCalled(r => r.Add(Arg<Template>.Is.Anything));
        }

        [Test]
        public void ShouldAddTemplateWithCorrectPath()
        {
            var args = this.ContentRepository.GetArgumentsForCallsMadeOn(r => r.Add(Arg<Template>.Is.Anything));
            var template = (Template)args[0][0];
            template.Path.Should().BeEquivalentTo(new[] { "test", "path" });
        }

    }
}
