namespace Kola.Persistence.Surrogates
{
    public interface IComponentSurrogateVisitor
    {
        void Visit(CompositeComponentSurrogate surrogate);

        void Visit(SimpleComponentSurrogate surrogate);
    }
}