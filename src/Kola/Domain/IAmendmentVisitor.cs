namespace Kola.Domain
{
    using Kola.Domain.Amendments;

    public interface IAmendmentVisitor
    {
        void Visit(AddComponentAmendment amendment);

        void Visit(MoveComponentAmendment amendment);

        void Visit(RemoveComponentAmendment amendment);
    }
}