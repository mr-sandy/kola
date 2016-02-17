namespace Kola.Domain.Instances.Config.Authorisation
{
    using System.Security.Claims;

    public interface ICondition
    {
        bool Test(ClaimsPrincipal user);

        T Accept<T>(IConditionVisitor<T> visitor);
    }
}