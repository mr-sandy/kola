namespace Persistence.Tests.ContentFinderTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenSeekingADynamicPath : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var source1 = MockRepository.GenerateMock<IDynamicSource>();
            source1.Stub(s => s.AcceptsValue("path1")).Return(true);

            var source2 = MockRepository.GenerateMock<IDynamicSource>();
            source2.Stub(s => s.AcceptsValue("path2")).Return(true);

            this.DynamicSourceProvider.Stub(p => p.Get("-dynamic1-")).Return(source1);
            this.DynamicSourceProvider.Stub(p => p.Get("-dynamic2-")).Return(source2);

            this.FileSystemHelper.Stub(f => f.FindChildDirectories(@"\root", "-*-")).Return(new[] { "-dynamic1-" });
            this.FileSystemHelper.Stub(f => f.FindChildDirectories(@"\root\-dynamic1-", "-*-")).Return(new [] { "-dynamic2-" });

            this.Result = this.ContentFinder.FindContentDirectories(new[] { "path1", "path2" });
        }

        [Test]
        public void OnlyOnePathShouldBeReturned()
        {
            this.Result.Should().HaveCount(1);
        }

        [Test]
        public void TheDirectoryPathShouldBeReturned()
        {
            this.Result.Single().Should().Be(@"\root\-dynamic1-\-dynamic2-");
        }
    }
}