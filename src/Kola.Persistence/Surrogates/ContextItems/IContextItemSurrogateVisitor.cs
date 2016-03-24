namespace Kola.Persistence.Surrogates.ContextItems
{
    public interface IContextItemSurrogateVisitor<out T>
    {
        T Visit(FixedContextItemSurrogate contextItem);

        T Visit(RandomContextItemSurrogate contextItem);
    }
}