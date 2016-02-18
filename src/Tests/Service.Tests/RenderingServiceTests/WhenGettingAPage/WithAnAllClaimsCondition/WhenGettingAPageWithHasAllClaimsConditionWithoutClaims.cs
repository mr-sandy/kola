namespace Service.Tests.RenderingServiceTests.WhenGettingAPage.WithAnAllClaimsCondition
{
    using System.Security.Claims;

    using FluentAssertions;

    using Kola.Domain.Instances;
    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPageWithHasAllClaimsConditionWithoutAllClaims : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.User.Stub(u => u.Claims).Return(new[] { new Claim("claim1", string.Empty) });

            this.Result = this.RenderingService.GetPage(this.Path, null, this.User, false);
        }

        [Test]
        public void ShouldReturnForbidden()
        {
            this.Result.Should().BeOfType<ForbiddenResult<PageInstance>>();
        }
    }
}