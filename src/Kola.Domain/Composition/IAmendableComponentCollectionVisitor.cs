namespace Kola.Domain.Composition
{
    using Kola.Domain.Specifications;

    public interface IAmendableComponentCollectionVisitor<out T>
    {
        T Visit(WidgetSpecification widgetSpecification);

        T Visit(Template template);
    }
}