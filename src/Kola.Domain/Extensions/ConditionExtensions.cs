namespace Kola.Domain.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances.Config;
    using Kola.Domain.Instances.Config.Authorisation;

    public static class ConditionExtensions
    {
        public static IEnumerable<ICondition> Merge(this IEnumerable<ICondition> oldConditions, IEnumerable<ICondition> newConditions)
        {
            if (oldConditions == null && newConditions == null)
            {
                return Enumerable.Empty<ICondition>();
            }

            if (oldConditions == null)
            {
                return newConditions;
            }

            if (newConditions == null)
            {
                return oldConditions;
            }

            return newConditions.Union(oldConditions);
        }
    }
}