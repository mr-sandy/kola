namespace Kola.Domain.Instances.Config.Authorisation
{
    using System.Linq;

    public class HasClaimCondition : ICondition
    {
        public HasClaimCondition(string claim)
        {
            this.Claim = claim;
        }

        public string Claim { get; }

        public bool Test(IUser user)
        {
            return user?.Claims != null && user.Claims.Contains(this.Claim);
        }

        public T Accept<T>(IConditionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}