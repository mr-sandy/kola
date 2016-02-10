namespace Kola.Persistence.Surrogates.Conditions
{
    public abstract class ConditionSurrogate
    {
        public abstract T Accept<T>(IConditionSurrogateVisitor<T> visitor);
    }
}