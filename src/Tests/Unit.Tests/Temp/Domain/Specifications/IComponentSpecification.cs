namespace Unit.Tests.Temp.Domain.Specifications
{
    using Unit.Tests.Temp.Domain.Templates;

    public interface IComponentSpecification<out T>
        where T : IComponentTemplate
    {
        T Create();
    }
}