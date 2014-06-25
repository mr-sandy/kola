namespace Kola.Domain.Composition
{
    public interface IComponentVisitor
    {
        void Visit(Atom atom);

        void Visit(Container container);

        void Visit(Widget widget);

        void Visit(Placeholder placeholder);
    }

    public interface IComponentVisitor<out T, in TContext>
    {
        T Visit(Atom atom, TContext context);

        T Visit(Container container, TContext context);

        T Visit(Widget widget, TContext context);

        T Visit(Placeholder placeholder, TContext context);
    }
}