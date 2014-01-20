namespace Kola.Persistence.Surrogates.Amendments
{
    public abstract class AmendmentSurrogate
    {
        public abstract void Accept(IAmendmentSurrogateVisitor visitor);
    }
}