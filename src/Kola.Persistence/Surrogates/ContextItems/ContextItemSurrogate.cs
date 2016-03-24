namespace Kola.Persistence.Surrogates.ContextItems
{
    public abstract class ContextItemSurrogate
    {
        public abstract T Accept<T>(IContextItemSurrogateVisitor<T> visitor);
    }
}