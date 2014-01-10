namespace Kola.Domain
{
    public interface IComponentVisitor
    {
        void Visit(Atom atom);

        void Visit(Container container);

        void Visit(Widget widget);
    }
}