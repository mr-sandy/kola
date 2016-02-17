namespace Service.Tests.RenderingServiceTests
{
    using System.Security.Claims;

    using FluentAssertions;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;
    using Kola.Domain.Instances.Config.Authorisation;
    using Kola.Persistence;
    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenGettingAPageWithHasClaimConditionWithoutClaim : ContextBase
    {
        private IResult<PageInstance> result;

        [SetUp]
        public void SetUp()
        {
            var path = new[] { "path1, path2 " };
            var template = new Template(path);
            var config = new Configuration(null, new[] { new HasAllClaimsCondition(new[] { "the claim" }) });
            var user = Rhino.Mocks.MockRepository.GenerateMock<ClaimsPrincipal>();
            user.Stub(u => u.Claims).Return(new[] { new Claim("another claim", "yes") });

            this.ContentRepository.Stub(r => r.FindContent(path)).Return(new[] { new FindContentResult(template, config) });
            this.result = this.RenderingService.GetPage(path, null, user, false);
        }

        [Test]
        public void ShouldReturnUnauthorised()
        {
            this.result.Should().BeOfType<UnauthorisedResult<PageInstance>>();
        }
    }
}