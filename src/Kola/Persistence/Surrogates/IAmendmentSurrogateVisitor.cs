namespace Kola.Persistence.Surrogates
{
    public interface IAmendmentSurrogateVisitor
    {
        void Visit(AddComponentAmendmentSurrogate amendment);

        void Visit(MoveComponentAmendmentSurrogate amendment);

        void Visit(RemoveComponentAmendmentSurrogate amendment);
    }
}