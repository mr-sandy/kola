namespace Persistence.Tests.ContentFinderTests
{
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Composition;

    using NUnit.Framework;

    using Rhino.Mocks;

    public class WhenSeekingTheRootTemplate : ContextBase
    {

        [SetUp]
        public void SetUp()
        {
            this.FileSystemHelper.Stub(f => f.FileExists(@"\root\Template.xml")).Return(true);
            this.SerializationHelper.Stub(f => f.Deserialize<Template>(@"\root\Template.xml")).Return(new Template(Enumerable.Empty<string>()));

            this.Result = this.ContentFinder.Find(Enumerable.Empty<string>());
        }

        [Test]
        public void TheTemplateShouldBeReturned()
        {
            this.Result.Should().BeOfType<Template>();
        }
    }
}
