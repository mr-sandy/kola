//namespace Integration.Tests.Nancy.Modules.TemplatesModuleSpecs
//{
//    using FluentAssertions;
//    using Kola.Domain;
//    using global::Nancy;
//    using NUnit.Framework;
//    using Rhino.Mocks;

//    public class WhenRetrievingATemplate : ContextBase
//    {
//        private string templatePath = @"test/path";

//        [SetUp]
//        public void EstablishContext()
//        {

//            this.Response = this.Browser.Get(string.Format("/_kola/templates/{0}", templatePath));
//        }

//        [Test]
//        public void ShouldReturnOk()
//        {
//            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
//        }

//        [Test]
//        public void ShouldLookupTemplateToRepository()
//        {
//            this.TemplateRepository.AssertWasCalled(r => r.Get(this.templatePath.Split(new[] { '/' })));
//        }

//        [Test]
//        public void ShouldAddTemplateWithCorrectPath()
//        {
//            var args = this.TemplateRepository.GetArgumentsForCallsMadeOn(r => r.Add(Arg<Template>.Is.Anything));
//            var template = (Template)args[0][0];
//            template.Path.Should().BeEquivalentTo(new[] { "test", "path" });
//        }
//    }
//}
