namespace Kola.Domain.Templates.Amendments
{
    public interface IAmendmentVisitor
    {
        void Visit(AddComponentAmendment amendment);

        void Visit(MoveComponentAmendment amendment);

        void Visit(RemoveComponentAmendment amendment);

        void Visit(UpdateParameterAmendment amendment);
    }
}