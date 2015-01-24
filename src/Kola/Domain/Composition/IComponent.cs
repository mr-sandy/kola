namespace Kola.Domain.Composition
{
    public interface IComponent
    {
        void Accept(IComponentVisitor visitor);

        T Accept<T>(IComponentVisitor<T> visitor);

        T Accept<T, TContext>(IComponentVisitor<T, TContext> visitor, TContext context);

        T Accept<T, TContext1, TContext2>(IComponentVisitor<T, TContext1, TContext2> visitor, TContext1 context1, TContext2 context2);

        IComponent Clone();
    }
}