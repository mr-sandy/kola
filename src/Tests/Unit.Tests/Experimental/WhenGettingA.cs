//namespace Unit.Tests.Experimental
//{
//    using System.Collections.Generic;
//    using System.Linq;

//    using FluentAssertions;

//    using Kola.Experimental;

//    using NUnit.Framework;

//    using Rhino.Mocks;

//    using Unit.Tests.Experimental.Stubs;

//    public class WhenGettingA
//    {
//        private IKolaResponse result;

//        [SetUp]
//        public void EstablishContext()
//        {
//            // The model
//            var innerComponent = new TestKolaComponent() { Name = "inner", Children = Enumerable.Empty<IKolaComponent>() };
//            var outerComponent = new TestKolaComponent() { Name = "outer", Children = new[] { innerComponent } };

//            // Test infrastructure
//            var viewMappings = new Dictionary<string, TestView>
//                {
//                    { "outer", new TestContainerView("<outerHtml>", "</outerHtml>") },
//                    { "inner", new TestAtomView("<innerHtml/>") }
//                };

//            var viewHelper = new TestViewHelper(viewMappings);
//            var viewEngine = new TestViewEngine(viewHelper);

//            this.result = viewEngine.Render(outerComponent);
//        }

//        [Test]
//        public void ShouldReturnAResult()
//        {
//            this.result.Should().NotBeNull();
//        }

//        [Test]
//        public void TheResultShouldYieldHtml()
//        {
//            this.result.ToHtml().Should().NotBeNullOrEmpty();
//        }

//        [Test]
//        public void TheResultShouldIncludeOuterComponentStartHtml()
//        {
//            this.result.ToHtml().Should().Contain("<outerHtml>");
//        }

//        [Test]
//        public void TheResultShouldIncludeOuterComponentEndHtml()
//        {
//            this.result.ToHtml().Should().Contain("</outerHtml>");
//        }

//        [Test]
//        public void TheResultShouldIncludeInnerComponentHtml()
//        {
//            this.result.ToHtml().Should().Contain("<innerHtml/>");
//        }
//    }
//}