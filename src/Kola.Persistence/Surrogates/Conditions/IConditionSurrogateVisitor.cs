namespace Kola.Persistence.Surrogates.Conditions
{
    public interface IConditionSurrogateVisitor<out T>
    {
        T Visit(IsAuthenticatedConditionSurrogate condition);

        T Visit(HasAllClaimsConditionSurrogate condition);

        T Visit(HasAnyClaimsConditionSurrogate condition);
    }
}