namespace Persistence.Tests.ContentFinderTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenSeekingADynamicPathWithComplimentaryElementa : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var bandSource = MockRepository.GenerateMock<IDynamicSource>();
            var albumSource = MockRepository.GenerateMock<IDynamicSource>();

            bandSource.Stub(s => s.AcceptsValue("the-beatles")).Return(true);
            albumSource.Stub(s => s.AcceptsValue("revolver")).Return(true);

            this.DynamicSourceProvider.Stub(p => p.Get("-bands-")).Return(bandSource);
            this.DynamicSourceProvider.Stub(p => p.Get("-albums-")).Return(albumSource);

            this.FileSystemHelper.Stub(f => f.FindChildDirectories(@"\root", "-*-")).Return(new[] { "-bands-" });
            this.FileSystemHelper.Stub(f => f.FindChildDirectories(@"\root\-bands-", "-*-")).Return(new[] { "-albums-" });

            this.Result = this.ContentFinder.FindContentDirectories(new[] { "the-beatles", "revolver" });
        }

        [Test]
        public void OnlyOnePathShouldBeReturned()
        {
            this.Result.Should().HaveCount(1);
        }

        [Test]
        public void TheDirectoryPathShouldBeReturned()
        {
            this.Result.Single().Should().Be(@"\root\-bands-\-albums-");
        }
    }
}