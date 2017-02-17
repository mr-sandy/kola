namespace Unit.Tests.Extensions.EnumerableExtensions.Compensate
{
    using FluentAssertions;

    using Kola.Domain.Extensions;

    using NUnit.Framework;

    public class CompensateTests
    {
        [Test]
        public void Test1()
        {
            var source = new[] { 0 };
            var target = new[] { 1 };

            target.Compensate(source).ShouldBeEquivalentTo(new[] { 1 });
        }

        [Test]
        public void Test2()
        {
            var source = new[] { 1 };
            var target = new[] { 0 };

            target.Compensate(source).ShouldBeEquivalentTo(new[] { 0 });
        }

        [Test]
        public void Test3()
        {
            var source = new[] { 0, 1 };
            var target = new[] { 1, 2 };

            target.Compensate(source).ShouldBeEquivalentTo(new[] { 1, 2 });
        }

        [Test]
        public void Test4()
        {
            var source = new[] { 1, 2 };
            var target = new[] { 0, 1 };

            target.Compensate(source).ShouldBeEquivalentTo(new[] { 0, 1 });
        }

        [Test]
        public void Test5()
        {
            var source = new[] { 0, 1, 0 };
            var target = new[] { 0, 0, 10 };

            target.Compensate(source).ShouldBeEquivalentTo(new[] { 0, 0, 10 });
        }

        [Test]
        public void Test6()
        {
            var source = new[] { 0, 0, 0 };
            var target = new[] { 0, 1, 10 };

            target.Compensate(source).ShouldBeEquivalentTo(new[] { 0, 1, 10 });
        }

        [Test]
        public void Test7()
        {
            var source = new[] { 1, 2, 3, 4, 5, 10 };
            var target = new[] { 1, 2, 3, 4, 5, 11, 50 };

            target.Compensate(source).ShouldBeEquivalentTo(new[] { 1, 2, 3, 4, 5, 10, 50 });
        }

        [Test]
        public void Test8()
        {
            var source = new[] { 1, 2, 3, 4, 5, 11, 50 };
            var target = new[] { 1, 2, 3, 4, 5, 10 };

            target.Compensate(source).ShouldBeEquivalentTo(new[] { 1, 2, 3, 4, 5, 10 });
        }

        [Test]
        public void Test9()
        {
            var source = new[] { 0, 0 };
            var target = new[] { 1 };

            target.Compensate(source).ShouldBeEquivalentTo(new[] { 1 });
        }

        [Test]
        public void Test10()
        {
            var source = new[] { 1 };
            var target = new[] { 0, 0 };

            target.Compensate(source).ShouldBeEquivalentTo(new[] { 0, 0 });
        }
    }
}
