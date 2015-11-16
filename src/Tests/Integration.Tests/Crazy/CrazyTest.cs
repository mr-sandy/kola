//namespace Integration.Tests.Crazy
//{
//    using FluentAssertions;

//    using global::Nancy;
//    using global::Nancy.Responses;
//    using global::Nancy.Testing;
//    using global::Nancy.ViewEngines.Razor;

//    using NUnit.Framework;

//    public class CrazyTest
//    {
//        private Browser browser;
//        private BrowserResponse response;

//        [SetUp]
//        public void SetUp()
//        {
//            var bootstrapper = new ConfigurableBootstrapper(
//                with =>
//                    {
//                        with.Dependency<CrazyResourceBuilder>();
//                        with.Dependency<CrazyService>();
//                        with.Dependency<CrazyProcessor>();
//                        with.Module<CrazyModule>();
//                        with.ViewEngine<RazorViewEngine>();
//                    });

//            //KolaConfigurationRegistry.Register(new KolaConfiguration(new MultiRenderer(this.HandlerFactory), null));
//            this.browser = new Browser(bootstrapper);
//            this.response = this.browser.Get("/crazy", with => with.Header("Accept", "application/json"));
//        }

//        [Test]
//        public void StatusCodeTest()
//        {
//            this.response.StatusCode.Should().Be(HttpStatusCode.OK);
//        }

//        [Test]
//        public void ContentTest1()
//        {
//            this.response.Body.DeserializeJson<CrazyResource>().Should().NotBeNull();
//        }

//        [Test]
//        public void ContentTest2()
//        {
//            this.response.Body.DeserializeJson<CrazyResource>().Name.Should().Be("badger!");
//        }
//    }
//}