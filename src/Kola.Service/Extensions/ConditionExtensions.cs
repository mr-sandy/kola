namespace Kola.Service.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    using Kola.Domain.Instances.Config.Authorisation;

    public static class ConditionExtensions
    {
        public static bool SatisfiedBy(this IEnumerable<ICondition> conditions, ClaimsPrincipal user)
        {
            return conditions == null || !conditions.Any() || conditions.All(a => a.Test(user));

        }

    }
}