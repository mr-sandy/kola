using FluentAssertions;
using Kola.Domain.Extensions;
using NUnit.Framework;

namespace Unit.Tests.Extensions.EnumerableExtensions.Compensate
{
    public class OldCompenstateTests
    {
        [Test]
        public void ShouldReturnCommonElements1()
        {
            var source = new[] { 0, 1, 2 };
            var target = new[] { 1, 2, 3 };
            target.Compensate(source).Should().BeEquivalentTo(new[] { 1, 2, 3 });
        }

        //[Test]
        //public void ShouldReturnCommonElements2()
        //{
        //    var source = new[] { 0 };
        //    var target = new[] { 1 };
        //    target.Compensate(source).Should().BeEquivalentTo(new[] { 0 });
        //}

        [Test]
        public void ShouldReturnCommonElements3()
        {
            var source = new[] { 0 };
            var target = new[] { 1, 0 };
            target.Compensate(source).Should().BeEquivalentTo(new[] { 0, 0 });
        }

        [Test]
        public void ShouldReturnCommonElements4()
        {
            var source = new[] { 0, 0 };
            var target = new[] { 1, 0 };
            target.Compensate(source).Should().BeEquivalentTo(new[] { 1, 0 });
        }

        //[Test]
        //public void ShouldReturnCommonElements5()
        //{
        //    var source = new[] { 1, 0 };
        //    var target = new[] { 1, 1 };
        //    target.Compensate(source).Should().BeEquivalentTo(new[] { 1, 0 });
        //}

        [Test]
        public void ShouldReturnCommonElements6()
        {
            var source = new[] { 1, 6 };
            var target = new[] { 1, 1 };
            target.Compensate(source).Should().BeEquivalentTo(new[] { 1, 1 });
        }

        [Test]
        public void ShouldReturnCommonElements7()
        {
            var source = new[] { 1, 6 };
            var target = new[] { 1, 2, 3, 4, 5, 6 };
            target.Compensate(source).Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });
        }

        [Test]
        public void ShouldReturnCommonElements8()
        {
            var source = new[] { 1, 1 };
            var target = new[] { 1, 2, 3, 4, 5, 6 };
            target.Compensate(source).Should().BeEquivalentTo(new[] { 1, 1, 3, 4, 5, 6 });
        }

        [Test]
        public void ShouldReturnCommonElements9()
        {
            var source = new[] { 0 };
            var target = new[] { 1, 2, 3, 4, 5, 6 };
            target.Compensate(source).Should().BeEquivalentTo(new[] { 0, 2, 3, 4, 5, 6 });
        }

        [Test]
        public void ShouldReturnCommonElements10()
        {
            var source = new[] { 2 };
            var target = new[] { 1, 2, 3, 4, 5, 6 };
            target.Compensate(source).Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });
        }

        [Test]
        public void ShouldReturnCommonElements11()
        {
            var source = new[] { 1, 0 };
            var target = new[] { 1, 2, 3, 4, 5, 6 };
            target.Compensate(source).Should().BeEquivalentTo(new[] { 1, 1, 3, 4, 5, 6 });
        }

        [Test]
        public void ShouldReturnCommonElements12()
        {
            var source = new[] { 0, 1, 0, 0 };
            var target = new[] { 0, 1, 0, 1, 0 };
            target.Compensate(source).Should().BeEquivalentTo(new[] { 0, 1, 0, 0, 0 });
        }
    }
}