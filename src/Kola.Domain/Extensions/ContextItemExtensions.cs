namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;

    using Kola.Domain.Instances.Context;

    public static class ContextItemExtensions
    {
        public static IEnumerable<IContextItem> Merge(this IEnumerable<IContextItem> context1, IEnumerable<IContextItem> context2)
        {
            if (context1 == null && context2 == null)
            {
                return Enumerable.Empty<IContextItem>();
            }

            if (context1 == null)
            {
                return context2;
            }

            if (context2 == null)
            {
                return context1;
            }

            return context2.Union(context1.Where(c1 => context2.All(c2 => c1.Name != c2.Name)));
        }
    }
}