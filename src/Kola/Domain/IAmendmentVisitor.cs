namespace Kola.Domain
{
    public interface IAmendmentVisitor
    {
        void Visit(AddComponentAmendment amendment);
    }
}