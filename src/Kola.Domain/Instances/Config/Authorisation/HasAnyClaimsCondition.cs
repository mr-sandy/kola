namespace Kola.Domain.Instances.Config.Authorisation
{
    using System.Collections.Generic;
    using System.Linq;

    public class HasAnyClaimsCondition : ICondition
    {
        public HasAnyClaimsCondition(IEnumerable<string> claims)
        {
            this.Claims = claims;
        }

        public IEnumerable<string> Claims { get; }

        public bool Test(IUser user)
        {
            return user?.Claims != null && this.Claims.Any(c => user.Claims.Contains(c));
        }

        public T Accept<T>(IConditionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}