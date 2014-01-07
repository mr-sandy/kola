namespace Kola.Editing
{
    using Kola.Editing.Amendments;

    public interface IAmendmentVisitor
    {
        void Visit(AddComponentAmendment amendment);

        void Visit(MoveComponentAmendment amendment);

        void Visit(DeleteComponentAmendment amendment);
    }
}