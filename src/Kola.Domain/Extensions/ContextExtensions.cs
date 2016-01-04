namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.Instances.Context;

    public static class ContextExtensions
    {
        public static IContext Merge(this IContext oldContext, IContext newContext)
        {
            return new Context
            {
                ContextItems = oldContext.ContextItems.Merge(newContext.ContextItems)
            };
        }

        public static IContext Merge(this IContext oldContext, IEnumerable<IContextItem> newContextItems)
        {
            return new Context
            {
                ContextItems = oldContext.ContextItems.Merge(newContextItems)
            };
        }
    }
}