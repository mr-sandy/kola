namespace Kola.Persistence.Surrogates.Amendments
{
    public interface IAmendmentSurrogateVisitor
    {
        void Visit(AddComponentAmendmentSurrogate amendment);

        void Visit(MoveComponentAmendmentSurrogate amendment);

        void Visit(RemoveComponentAmendmentSurrogate amendment);
    }
}