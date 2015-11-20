namespace Persistence.Tests.ContentFinderTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Context;
    using Kola.Persistence;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenSeekingADynamicPathWithMultipleCandidates : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var source1 = MockRepository.GenerateMock<IDynamicSource>();
            source1.Stub(s => s.Lookup("dynamic1", Enumerable.Empty<IContextItem>())).Return(new SourceLookupResponse(true, new[] { new ContextItem("item name 1", "item value 1") }));

            var source2 = MockRepository.GenerateMock<IDynamicSource>();
            source2.Stub(s => s.Lookup("dynamic1", Enumerable.Empty<IContextItem>())).Return(new SourceLookupResponse(true, new[] { new ContextItem("item name 2", "item value 2") }));

            this.DynamicSourceProvider.Stub(p => p.Get("-dynamic1-")).Return(source1);
            this.DynamicSourceProvider.Stub(p => p.Get("-dynamic2-")).Return(source2);

            this.FileSystemHelper.Stub(f => f.FindChildDirectories(@"\root", "-*-")).Return(new[] { "-dynamic1-", "-dynamic2-" });
            this.FileSystemHelper.Stub(f => f.DirectoryExists(@"\root\-dynamic1-\static")).Return(false);
            this.FileSystemHelper.Stub(f => f.DirectoryExists(@"\root\-dynamic2-\static")).Return(true);

            this.Result = this.ContentFinder.FindContentDirectories(new[] { "dynamic1", "static" });
        }

        [Test]
        public void OnlyOnePathShouldBeReturned()
        {
            this.Result.Should().HaveCount(1);
        }

        [Test]
        public void TheDirectoryPathShouldBeReturned()
        {
            this.Result.Single().Path.Should().Be(@"\root\-dynamic2-\static");
        }

        [Test]
        public void TheContentDirectoryShouldIncludeOneContextItem()
        {
            this.Result.Single().ContextItems.Should().HaveCount(1);
        }

        [Test]
        public void TheContextItemShouldHaveTheExpectedNameAndValue()
        {
            this.Result.Single().ContextItems.Where(i => i.Name == "item name 2" && i.Value == "item value 2").Should().HaveCount(1);
        }
    }
}