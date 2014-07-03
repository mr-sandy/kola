namespace Kola.Domain.Instances
{
    public interface IComponentInstanceVisitor<out T, in TContext>
    {
        T Visit(AtomInstance component, TContext context);

        T Visit(ContainerInstance component, TContext context);

        T Visit(WidgetInstance component, TContext context);

        T Visit(AreaInstance component, TContext context);

        T Visit(PlaceholderInstance component, TContext context);
    }
}