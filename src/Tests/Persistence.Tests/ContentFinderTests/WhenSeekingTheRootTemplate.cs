namespace Persistence.Tests.ContentFinderTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;

    using NUnit.Framework;

    using Rhino.Mocks;

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
            this.Result.Single().Should().Be(@"\root");
        }
    }
}
