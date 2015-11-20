namespace Persistence.Tests.ContentFinderTests
{
    using System.Linq;

    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenSeekingAStaticPath : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.FileSystemHelper.Stub(f => f.DirectoryExists(@"\root\directory1")).Return(true);
            this.FileSystemHelper.Stub(f => f.DirectoryExists(@"\root\directory1\directory2")).Return(true);

            this.Result = this.ContentFinder.FindContentDirectories(new[] { "directory1", "directory2" });
        }

        [Test]
        public void OnlyOnePathShouldBeReturned()
        {
            this.Result.Should().HaveCount(1);
        }

        [Test]
        public void TheDirectoryPathShouldBeReturned()
        {
            this.Result.Single().Path.Should().Be(@"\root\directory1\directory2");
        }
    }
}