namespace Service.Tests.RenderingServiceTests.WhenGettingAPage
{
    using FluentAssertions;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhereThePageDoesntExist : ContextBase
    {
        private IResult<PageInstance> result;

        [SetUp]
        public void SetUp()
        {
            var path = new[] { "path1, path2 " };

            this.ContentRepository.Stub(r => r.FindContent(path)).Return(null);
            this.result = this.RenderingService.GetPage(path, null, null, false);
        }

        [Test]
        public void Test()
        {
            this.result.Should().BeOfType<NotFoundResult<PageInstance>>();
        }
    }
}