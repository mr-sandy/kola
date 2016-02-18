namespace Service.Tests.RenderingServiceTests.WhenGettingAPage.WithAnIsAuthenticatedCondition
{
    using FluentAssertions;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPageWithIsAuthenticatedConditionWithAuthentication : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.UserIdentity.Stub(i => i.IsAuthenticated).Return(true);

            this.Result = this.RenderingService.GetPage(this.Path, null, this.User, false);
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Result.Should().BeOfType<SuccessResult<PageInstance>>();
        }
    }
}