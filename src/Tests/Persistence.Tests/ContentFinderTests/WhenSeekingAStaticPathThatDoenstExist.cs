namespace Persistence.Tests.ContentFinderTests
{
    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenSeekingAStaticPathThatDoenstExist : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.FileSystemHelper.Stub(f => f.DirectoryExists(@"\root\directory1")).Return(true);
            this.FileSystemHelper.Stub(f => f.DirectoryExists(@"\root\directory1\directory2")).Return(false);

            this.Result = this.ContentFinder.FindContentDirectories(new[] { "directory1", "directory2" });
        }

        [Test]
        public void NoPathsShouldBeReturned()
        {
            this.Result.Should().HaveCount(0);
        }
    }
}