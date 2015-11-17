//namespace Unit.Tests.Extensions.EnumerableExtensions.Overlap
//{
//    using System.Collections.Generic;
//    using System.Linq;

//    using FluentAssertions;

//    using Kola.Service.Extensions;

//    using NUnit.Framework;

//    public class WhenFindingOverlapWithTwoeEmptyLists
//    {
//        private IEnumerable<int> result;

//        [SetUp]
//        public void SetUp()
//        {
//            var list1 = Enumerable.Empty<int>();
//            var list2 = Enumerable.Empty<int>();

//            this.result = list1.GetOverlap(list2);
//        }

//        [Test]
//        public void ShouldReturnCommonElements()
//        {
//            this.result.Should().BeEmpty();
//        }
//    }
//}