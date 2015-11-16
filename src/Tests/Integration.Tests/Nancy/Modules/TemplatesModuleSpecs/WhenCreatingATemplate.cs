namespace Integration.Tests.Nancy.Modules.TemplatesModuleSpecs
{
    using FluentAssertions;

    using Kola.Domain.Composition;

    using global::Nancy;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenCreatingATemplate : ContextBase
    {
        [SetUp]
        public void EstablishContext()
        {
            var templatePath = @"test/path";

            this.Response = this.Browser.Put((string)$"/_kola/templates/{templatePath}",
                with => with.Header("Accept", "application/json"));
        }

        [Test]
        public void Test1()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Test]
        public void Test2()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        //[Test]
        //public void ShouldAddTemplateToRepository()
        //{
        //    this.ContentRepository.AssertWasCalled(r => r.Add(Arg<Template>.Is.Anything));
        //}

        //[Test]
        //public void ShouldAddTemplateWithCorrectPath()
        //{
        //    var args = this.ContentRepository.GetArgumentsForCallsMadeOn(r => r.Add(Arg<Template>.Is.Anything));
        //    var template = (Template)args[0][0];
        //    template.Path.Should().BeEquivalentTo(new[] { "test", "path" });
        //}

    }
}
