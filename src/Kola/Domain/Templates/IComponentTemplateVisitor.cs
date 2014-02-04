namespace Kola.Domain.Templates
{
    public interface IComponentTemplateVisitor
    {
        void Visit(AtomTemplate atom);

        void Visit(ContainerTemplate container);

        void Visit(WidgetTemplate widget);

        void Visit(PlaceholderTemplate placeholder);
    }
}