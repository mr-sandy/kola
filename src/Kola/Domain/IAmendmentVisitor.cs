namespace Kola.Domain
{
    public interface IAmendmentVisitor
    {
        void Visit(AddComponentAmendment amendment);

        void Visit(MoveComponentAmendment amendment);

        void Visit(DeleteComponentAmendment amendment);
    }
}