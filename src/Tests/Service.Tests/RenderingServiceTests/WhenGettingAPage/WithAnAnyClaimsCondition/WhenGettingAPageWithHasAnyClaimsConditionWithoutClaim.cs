namespace Service.Tests.RenderingServiceTests.WhenGettingAPage.WithAnAnyClaimsCondition
{
    using System.Security.Claims;

    using FluentAssertions;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPageWithHasAnyClaimsConditionWithoutClaim : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.User.Stub(u => u.Claims).Return(new[] { new Claim("unwanted claim", string.Empty) });

            this.Result = this.RenderingService.GetPage(this.Path, null, this.User, false);
        }

        [Test]
        public void ShouldReturnForbidden()
        {
            this.Result.Should().BeOfType<ForbiddenResult<PageInstance>>();
        }
    }
}