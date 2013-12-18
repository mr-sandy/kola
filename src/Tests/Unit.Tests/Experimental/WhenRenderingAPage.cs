namespace Unit.Tests.Experimental
{
    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenRenderingAPage
    {
        private IResponse result;

        [SetUp]
        public void EstablishContext()
        {
            var page = MockRepository.GenerateStub<IPage>();

            var renderer = new KolaRenderer();

            this.result = renderer.Render(page);
        }

        [Test]
        public void ShouldReturnSomething()
        {
            this.result.ToHtml().Should().NotBeNullOrEmpty();
        }

        [Test]
        public void ShouldReturnHtml()
        {
            this.result.ToHtml().Should().Contain("<html");
        }
    }
}
