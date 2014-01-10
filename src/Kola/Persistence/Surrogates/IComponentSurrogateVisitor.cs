namespace Kola.Persistence.Surrogates
{
    public interface IComponentSurrogateVisitor
    {
        void Visit(ContainerSurrogate surrogate);

        void Visit(AtomSurrogate surrogate);

        void Visit(WidgetSurrogate surrogate);
    }
}