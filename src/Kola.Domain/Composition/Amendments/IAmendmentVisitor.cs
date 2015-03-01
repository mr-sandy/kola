namespace Kola.Domain.Composition.Amendments
{
    public interface IAmendmentVisitor
    {
        void Visit(AddComponentAmendment amendment);

        void Visit(MoveComponentAmendment amendment);

        void Visit(RemoveComponentAmendment amendment);

        void Visit(DuplicateComponentAmendment amendment);

        void Visit(SetPropertyFixedAmendment amendment);

        void Visit(SetPropertyInheritedAmendment amendment);

        void Visit(SetPropertyMultilingualAmendment amendment);
    }

    public interface IAmendmentVisitor<out T>
    {
        T Visit(AddComponentAmendment amendment);

        T Visit(MoveComponentAmendment amendment);

        T Visit(RemoveComponentAmendment amendment);

        T Visit(DuplicateComponentAmendment amendment);

        T Visit(SetPropertyFixedAmendment amendment);

        T Visit(SetPropertyInheritedAmendment amendment);

        T Visit(SetPropertyMultilingualAmendment amendment);
    }

    public interface IAmendmentVisitor<out T, in TContext>
    {
        T Visit(AddComponentAmendment amendment, TContext context);

        T Visit(MoveComponentAmendment amendment, TContext context);

        T Visit(RemoveComponentAmendment amendment, TContext context);

        T Visit(DuplicateComponentAmendment amendment, TContext context);

        T Visit(SetPropertyFixedAmendment amendment, TContext context);

        T Visit(SetPropertyInheritedAmendment amendment, TContext context);

        T Visit(SetPropertyMultilingualAmendment amendment, TContext context);
    }
}