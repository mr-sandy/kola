namespace Persistence.Tests.ContentFinderTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Instances.Context;
    using Kola.Persistence;

    using NUnit.Framework;

    using Persistence.Tests.ContentFinderTests.FakeSources;

    using Rhino.Mocks;

    public class WhenSeekingADynamicPathWithConflictingElements : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var bandSource = new TestSource
            {
                Func = (name, context) => name == "the-beatles"
                                              ? new SourceLookupResponse(true, new[] { new ContextItem("band name", "The Beatles") })
                                              : new SourceLookupResponse(false)
            };

            var albumSource = new TestSource
            {
                Func = (name, context) => name == "pet-sounds" &&  context.Any(c => c.Name == "band name" && c.Value != "Beach Boys")
                                              ? new SourceLookupResponse(false)
                                              : new SourceLookupResponse(true, new[] { new ContextItem("album name", "Revolver") }) };

            this.DynamicSourceProvider.Stub(p => p.Get("-bands-")).Return(bandSource);
            this.DynamicSourceProvider.Stub(p => p.Get("-albums-")).Return(albumSource);

            this.FileSystemHelper.Stub(f => f.FindChildDirectories(@"\root", "-*-")).Return(new[] { "-bands-" });
            this.FileSystemHelper.Stub(f => f.FindChildDirectories(@"\root\-bands-", "-*-")).Return(new[] { "-albums-" });

            this.Result = this.ContentFinder.FindContentDirectories(new[] { "the-beatles", "pet-sounds" });
        }

        [Test]
        public void NoPathsShouldBeReturned()
        {
            this.Result.Should().HaveCount(0);
        }
    }
}