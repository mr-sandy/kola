namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

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

            return context1.Union(context2);
        }
    }
}