namespace Kola.Domain.Instances.Config.Authorisation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;

    public class HasAllClaimsCondition : ICondition
    {
        public HasAllClaimsCondition(IEnumerable<string> claims)
        {
            this.Claims = claims;
        }

        public IEnumerable<string> Claims { get; }

        public bool Test(ClaimsPrincipal user)
        {
            return user?.Claims != null && this.Claims.All(c => user.Claims.Any(u => u.Type == c));
        }

        public T Accept<T>(IConditionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}