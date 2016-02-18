namespace Service.Tests.RenderingServiceTests.WhenGettingAPage.WithAnAnyClaimsCondition
{
    using System.Security.Claims;

    using FluentAssertions;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPageWithHasAnyClaimsConditionWithClaim : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.User.Stub(u => u.Claims).Return(new[] { new Claim("claim1", string.Empty) });

            this.Result = this.RenderingService.GetPage(this.Path, null, this.User, false);
        }

        [Test]
        public void ShouldReturnSuccess()
        {
            this.Result.Should().BeOfType<SuccessResult<PageInstance>>();
        }
    }
}