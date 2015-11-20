namespace Persistence.Tests.ContentFinderTests
{
    using System.Collections.Generic;

    using Kola.Domain.Composition;
    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class ContextBase
    {
        protected ContentFinder ContentFinder;
        protected IFileSystemHelper FileSystemHelper;
        protected IDynamicSourceProvider DynamicSourceProvider;
        protected IEnumerable<string> Result;

        [SetUp]
        public void SetUpBase()
        {
            this.FileSystemHelper = MockRepository.GenerateStub<IFileSystemHelper>();
            this.DynamicSourceProvider = MockRepository.GenerateStub<IDynamicSourceProvider>();

            this.ContentFinder = new ContentFinder(this.FileSystemHelper, this.DynamicSourceProvider, @"\root");
        }
    }
}