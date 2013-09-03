namespace Integration.Tests.Nancy.Modules.TemplatesModuleSpecs
{
    using FluentAssertions;
    using Kola.Domain;
    using global::Nancy;
    using NUnit.Framework;
    using Rhino.Mocks;

    public class WhenCreatingATemplate : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var templatePath = @"test/path";

            this.Response = this.Browser.Put(string.Format("/_kola/templates/{0}", templatePath));
        }

        [Test]
        public void ShouldReturnCreated()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void ShouldAddTemplateToRepository()
        {
            this.TemplateRepository.AssertWasCalled(r => r.Add(Arg<Template>.Is.Anything));
        }

        [Test]
        public void ShouldAddTemplateWithCorrectPath()
        {
            var args = this.TemplateRepository.GetArgumentsForCallsMadeOn(r => r.Add(Arg<Template>.Is.Anything));
            var template = (Template)args[0][0];
            template.Path.Should().BeEquivalentTo(new[] { "test", "path" });
        }
    }
}
