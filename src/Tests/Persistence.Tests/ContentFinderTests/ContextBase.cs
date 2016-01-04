namespace Persistence.Tests.ContentFinderTests
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Context;
    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class ContextBase
    {
        protected ContentFinder ContentFinder;
        protected IFileSystemHelper FileSystemHelper;
        protected IDynamicSourceProvider DynamicSourceProvider;
        protected IContextRepository ContextSettingsRepository;
        protected IEnumerable<ContentDirectory> Result;

        [SetUp]
        public void SetUpBase()
        {
            this.FileSystemHelper = MockRepository.GenerateStub<IFileSystemHelper>();
            this.DynamicSourceProvider = MockRepository.GenerateStub<IDynamicSourceProvider>();
            this.ContextSettingsRepository = MockRepository.GenerateMock<IContextRepository>();

            this.ContextSettingsRepository.Stub(r => r.Get(Arg<string>.Is.Anything))
                .Return(new Context());

            this.ContentFinder = new ContentFinder(this.FileSystemHelper, this.DynamicSourceProvider, this.ContextSettingsRepository);
        }
    }
}