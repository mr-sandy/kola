namespace Persistence.Tests.ContentFinderTests
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class ContextBase
    {
        protected ContentFinder ContentFinder;
        protected IFileSystemHelper FileSystemHelper;
        protected IDynamicSourceProvider DynamicSourceProvider;
        protected IEnumerable<ContentDirectory> Result;

        [SetUp]
        public void SetUpBase()
        {
            this.FileSystemHelper = MockRepository.GenerateStub<IFileSystemHelper>();
            this.DynamicSourceProvider = MockRepository.GenerateStub<IDynamicSourceProvider>();

            this.ContentFinder = new ContentFinder(this.FileSystemHelper, this.DynamicSourceProvider);
        }
    }
}