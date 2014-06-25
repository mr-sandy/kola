namespace Kola.Persistence.Surrogates
{
    public interface IComponentSurrogateVisitor<out T>
    {
        T Visit(ContainerSurrogate surrogate);

        T Visit(AtomSurrogate surrogate);

        T Visit(WidgetSurrogate surrogate);

        T Visit(PlaceholderSurrogate surrogate);
    }
}