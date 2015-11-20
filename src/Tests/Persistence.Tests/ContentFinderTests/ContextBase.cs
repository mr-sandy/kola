namespace Persistence.Tests.ContentFinderTests
{
    using Kola.Domain.Composition;
    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class ContextBase
    {
        protected ContentFinder ContentFinder;
        protected IFileSystemHelper FileSystemHelper;
        protected ISerializationHelper SerializationHelper;
        protected IContent Result;

        [SetUp]
        public void SetUpBase()
        {
            this.FileSystemHelper = MockRepository.GenerateStub<IFileSystemHelper>();
            this.SerializationHelper = MockRepository.GenerateStub<ISerializationHelper>();

            this.ContentFinder = new ContentFinder(this.FileSystemHelper, this.SerializationHelper, @"\root");
        }
    }
}