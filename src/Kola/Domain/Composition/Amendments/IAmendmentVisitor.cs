namespace Kola.Domain.Composition.Amendments
{
    public interface IAmendmentVisitor
    {
        void Visit(AddComponentAmendment amendment);

        void Visit(MoveComponentAmendment amendment);

        void Visit(RemoveComponentAmendment amendment);

        void Visit(SetParameterFixedAmendment amendment);

        void Visit(SetParameterInheritedAmendment amendment);

        void Visit(SetParameterMultilingualAmendment amendment);
    }
}