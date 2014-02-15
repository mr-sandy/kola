namespace Kola.Domain.Composition
{
    public interface IComponentVisitor
    {
        void Visit(Atom atom);

        void Visit(Container container);

        void Visit(Widget widget);

        void Visit(Placeholder placeholder);
    }
}