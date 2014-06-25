namespace Kola.Persistence.Surrogates.Amendments
{
    public abstract class AmendmentSurrogate
    {
        public abstract T Accept<T>(IAmendmentSurrogateVisitor<T> visitor);
    }
}