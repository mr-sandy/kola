namespace Service.Tests.RenderingServiceTests.WhenGettingAPage.WithAnIsAuthenticatedCondition
{
    using FluentAssertions;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPageWithIsAuthenticatedConditionWithoutAuthentication : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Result = this.RenderingService.GetPage(this.Path, null, null, false);
        }

        [Test]
        public void ShouldReturnUnauthorised()
        {
            this.Result.Should().BeOfType<UnauthorisedResult<PageInstance>>();
        }
    }
}