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
        protected IContextSettingsRepository ContextSettingsRepository;
        protected IEnumerable<ContentDirectory> Result;

        [SetUp]
        public void SetUpBase()
        {
            this.FileSystemHelper = MockRepository.GenerateStub<IFileSystemHelper>();
            this.DynamicSourceProvider = MockRepository.GenerateStub<IDynamicSourceProvider>();
            this.ContextSettingsRepository = MockRepository.GenerateMock<IContextSettingsRepository>();

            this.ContextSettingsRepository.Stub(r => r.Get(Arg<IEnumerable<string>>.Is.Anything))
                .Return(new ContextItem[] { });

            this.ContentFinder = new ContentFinder(this.FileSystemHelper, this.DynamicSourceProvider, this.ContextSettingsRepository);
        }
    }
}