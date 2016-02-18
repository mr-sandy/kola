namespace Service.Tests.RenderingServiceTests.WhenGettingAPage.WithAnIsAuthenticatedCondition
{
    using System;
    using System.Security.Claims;
    using System.Security.Principal;

    using Kola.Domain.Composition;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;
    using Kola.Domain.Instances.Config.Authorisation;
    using Kola.Persistence;
    using Kola.Service.Services.Results;

    using NUnit.Framework;

    using Rhino.Mocks;

    public abstract class ContextBase : Service.Tests.RenderingServiceTests.WhenGettingAPage.ContextBase
    {
        protected IResult<PageInstance> Result { get; set; }

        protected ClaimsPrincipal User { get; set; }

        protected IIdentity UserIdentity { get; set; }

        protected string[] Path{ get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Path = new[] { "path1, path2 " };

            var template = new Template(this.Path);
            var config = new Configuration(null, new[] { new IsAuthenticatedCondition() });

            this.UserIdentity = Rhino.Mocks.MockRepository.GenerateMock<IIdentity>();

            this.User = Rhino.Mocks.MockRepository.GenerateMock<ClaimsPrincipal>();
            this.User.Stub(u => u.Identity).Return(this.UserIdentity);

            this.ContentRepository.Stub(r => r.FindContent(this.Path)).Return(new[] { new FindContentResult(template, config) });
        }
    }
}
