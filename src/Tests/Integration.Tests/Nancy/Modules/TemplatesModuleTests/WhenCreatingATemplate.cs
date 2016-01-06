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
            this.Response = this.Browser.Put("/_kola/templates", with =>
                {
                    with.Query("templatePath", "/test/path");
                    with.Header("Accept", "application/json");
                });
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldReturnALocationHeader()
        {
            this.Response.Headers["location"].Should().Be("/_kola/templates?templatePath=/test/path");
        }

        [Test]
        public void ShouldAddTemplateToRepository()
        {
            var args = this.ContentRepository.GetArgumentsForCallsMadeOn(r => r.Add(Arg<Template>.Is.Anything));
            var template = (Template)args[0][0];
            template.Path.Should().BeEquivalentTo("test", "path");
        }
    }
}
