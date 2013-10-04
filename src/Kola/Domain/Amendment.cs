namespace Kola.Domain
{
    public abstract class Amendment
    {
        public abstract void Accept(IAmendmentVisitor visitor);
    }
}