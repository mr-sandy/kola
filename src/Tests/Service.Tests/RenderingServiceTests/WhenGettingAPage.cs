namespace Service.Tests.RenderingServiceTests
{
    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;
    using Kola.Persistence;
    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPage : ContextBase
    {
        private IResult<PageInstance> result;

        [SetUp]
        public void SetUp()
        {
            var path = new[] { "path1, path2 " };
            var template = new Template(path);
            this.ContentRepository.Stub(r => r.FindContent(path)).Return(new [] { new FindContentResult(template, null) });
            this.result = this.RenderingService.GetPage(path, false, null);
        }

        [Test]
        public void Test()
        {
            this.result.Should().BeOfType<SuccessResult<PageInstance>>();
        }
    }
}
