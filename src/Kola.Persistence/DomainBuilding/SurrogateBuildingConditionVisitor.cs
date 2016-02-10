namespace Kola.Persistence.DomainBuilding
{
    using Kola.Domain.Instances.Config.Authorisation;
    using Kola.Persistence.Surrogates.Conditions;

    internal class DomainBuildingConditionVisitor : IConditionSurrogateVisitor<ICondition>
    {
        public ICondition Visit(IsAuthenticatedConditionSurrogate condition)
        {
            return new IsAuthenticatedCondition();
        }

        public ICondition Visit(HasClaimConditionSurrogate condition)
        {
            return new HasClaimCondition(condition.Claim);
        }

        public ICondition Visit(HasAllClaimsConditionSurrogate condition)
        {
            return new HasAllClaimsCondition(condition.Claims);
        }

        public ICondition Visit(HasAnyClaimsConditionSurrogate condition)
        {
            return new HasAnyClaimsCondition(condition.Claims);
        }
    }
}