namespace Unit.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class EnumerableExtensions
    {
        public static T Second<T>(this IEnumerable<T> list)
        {
            return list.ElementAt(1);
        }

        public static T Third<T>(this IEnumerable<T> list)
        {
            return list.ElementAt(2);
        }
    }
}