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

    public interface IAmendmentVisitor<out T>
    {
        T Visit(AddComponentAmendment amendment);

        T Visit(MoveComponentAmendment amendment);

        T Visit(RemoveComponentAmendment amendment);

        T Visit(SetParameterFixedAmendment amendment);

        T Visit(SetParameterInheritedAmendment amendment);

        T Visit(SetParameterMultilingualAmendment amendment);
    }
}