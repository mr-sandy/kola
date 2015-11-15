namespace Service.Tests.RenderingServiceTests
{
    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;
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
            this.ContentRepository.Stub(r => r.Get(path)).Return(template);
            this.result = this.RenderingService.GetPage(path, false);
        }

        [Test]
        public void Test()
        {
            this.result.Should().BeOfType<SuccessResult<PageInstance>>();
        }
    }
}
