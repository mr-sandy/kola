namespace Kola.Domain.Instances.Config.Authorisation
{
    using System.Linq;
    using System.Security.Claims;

    public class IsAuthenticatedCondition : ICondition
    {
        public bool Test(ClaimsPrincipal user)
        {
            return user != null && user.Claims.Any();
        }

        public T Accept<T>(IConditionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}