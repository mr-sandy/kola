namespace Kola.Persistence.Surrogates
{
    public abstract class AmendmentSurrogate
    {
        public abstract void Accept(IAmendmentSurrogateVisitor visitor);
    }
}