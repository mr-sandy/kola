namespace Kola.Domain.Specifications
{
    public interface IComponentSpecificationVisitor<out T>
    {
        T Visit(ContainerSpecification containerSpecification);

        T Visit(AtomSpecification containerSpecification);

        T Visit(WidgetSpecification containerSpecification);
    }
}