namespace Persistence.Tests.ContentFinderTests
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Config;
    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class ContextBase
    {
        protected ContentFinder ContentFinder;
        protected IFileSystemHelper FileSystemHelper;
        protected IDynamicSourceProvider DynamicSourceProvider;
        protected IConfigurationRepository ConfigurationRepository;
        protected IEnumerable<ContentDirectory> Result;

        [SetUp]
        public void SetUpBase()
        {
            this.FileSystemHelper = MockRepository.GenerateStub<IFileSystemHelper>();
            this.DynamicSourceProvider = MockRepository.GenerateStub<IDynamicSourceProvider>();
            this.ConfigurationRepository = MockRepository.GenerateMock<IConfigurationRepository>();

            this.ConfigurationRepository.Stub(r => r.Get(Arg<string>.Is.Anything))
                .Return(new Configuration());

            this.ContentFinder = new ContentFinder(this.FileSystemHelper, this.DynamicSourceProvider, this.ConfigurationRepository);
        }
    }
}