namespace Kola.Domain.Instances.Config.Authorisation
{
    using System.Collections.Generic;
    using System.Linq;

    public class HasAllClaimsCondition : ICondition
    {
        public HasAllClaimsCondition(IEnumerable<string> claims)
        {
            this.Claims = claims;
        }

        public IEnumerable<string> Claims { get; }

        public bool Test(IUser user)
        {
            return user?.Claims != null && this.Claims.All(c => user.Claims.Contains(c));
        }

        public T Accept<T>(IConditionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}