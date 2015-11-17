namespace Unit.Tests.Extensions.EnumerableExtensions.Compensate
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Kola.Domain.Extensions;

    using NUnit.Framework;

    public class Test1
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 0, 1, 2 };
            var list2 = new[] { 1, 2, 3 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 1, 2, 3 });
        }
    }
    public class Test2
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 0 };
            var list2 = new[] { 1 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 0 });
        }
    }
    public class Test3
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 0 };
            var list2 = new[] { 1, 0 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 0, 0 });
        }
    }
    public class Test4
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 0, 0 };
            var list2 = new[] { 1, 0 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 1, 0 });
        }
    }
    public class Test5
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 1, 0 };
            var list2 = new[] { 1, 1 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 1, 0 });
        }
    }
    public class Test6
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 1, 6 };
            var list2 = new[] { 1, 1 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 1, 1 });
        }
    }
    public class Test7
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 1, 6 };
            var list2 = new[] { 1, 2, 3, 4, 5, 6 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });
        }
    }
    public class Test8
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 1, 1 };
            var list2 = new[] { 1, 2, 3, 4, 5, 6 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 1, 1, 3, 4, 5, 6 });
        }
    }
    public class Test9
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 0 };
            var list2 = new[] { 1, 2, 3, 4, 5, 6 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 0, 2, 3, 4, 5, 6 });
        }
    }
    public class Test10
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 2 };
            var list2 = new[] { 1, 2, 3, 4, 5, 6 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 1, 2, 3, 4, 5, 6 });
        }
    }
    public class Test11
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 1, 0 };
            var list2 = new[] { 1, 2, 3, 4, 5, 6 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 1, 1, 3, 4, 5, 6 });
        }
    }
    public class Test12
    {
        private IEnumerable<int> result;

        [SetUp]
        public void SetUp()
        {
            var list1 = new[] { 0, 1, 0, 0 };
            var list2 = new[] { 0, 1, 0, 1, 0 };

            this.result = list1.Compensate(list2);
        }

        [Test]
        public void ShouldReturnCommonElements()
        {
            this.result.Should().BeEquivalentTo(new[] { 0, 1, 0, 0, 0 });
        }
    }

}