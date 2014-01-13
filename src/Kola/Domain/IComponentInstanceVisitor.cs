namespace Kola.Domain
{
    public interface IComponentInstanceVisitor<out T>
    {
        T Visit(AtomInstance atomInstance);

        T Visit(ContainerInstance containerInstance);

        T Visit(WidgetInstance widgetInstance);
    }
}