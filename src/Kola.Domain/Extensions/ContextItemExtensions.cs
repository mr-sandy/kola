namespace Kola.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;

    using Kola.Domain.Instances.Config;

    public static class ContextItemExtensions
    {
        public static IEnumerable<IContextItem> Merge(this IEnumerable<IContextItem> oldContext, IEnumerable<IContextItem> newContext)
        {
            if (oldContext == null && newContext == null)
            {
                return Enumerable.Empty<IContextItem>();
            }

            if (oldContext == null)
            {
                return newContext;
            }

            if (newContext == null)
            {
                return oldContext;
            }

            return newContext.Union(oldContext.Where(c1 => newContext.All(c2 => c1.Name != c2.Name)));
        }
    }
}