//namespace Unit.Tests.Experimental
//{
//    using FluentAssertions;

//    using Kola.Experimental;

//    using NUnit.Framework;

//    using Rhino.Mocks;

//    public class WhenGettingAPage
//    {
//        private IKolaResponse result;

//        [SetUp]
//        public void EstablishContext()
//        {
//            var page = MockRepository.GenerateStub<IKolaPage>();

//            var renderer = new KolaRenderer();

//            this.result = renderer.Render(page);
//        }

//        [Test]
//        public void ShouldReturnSomething()
//        {
//            this.result.ToHtml().Should().NotBeNullOrEmpty();
//        }

//        [Test]
//        public void ShouldReturnHtml()
//        {
//            this.result.ToHtml().Should().Contain("<html");
//        }
//    }
//}
