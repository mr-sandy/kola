namespace Persistence.Tests.ContentFinderTests
{
    using System.Linq;

    using FluentAssertions;

    using NUnit.Framework;

    public class WhenSeekingTheRootPath : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Result = this.ContentFinder.FindContentDirectories(Enumerable.Empty<string>());
        }

        [Test]
        public void OnlyOnePathShouldBeReturned()
        {
            this.Result.Should().HaveCount(1);
        }

        [Test]
        public void TheRootPathShouldBeReturned()
        {
            this.Result.Single().Path.Should().Be(@"Templates");
        }
    }
}
