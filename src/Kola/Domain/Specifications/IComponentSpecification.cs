namespace Kola.Domain.Specifications
{
    using Kola.Domain.Templates;

    public interface IComponentSpecification<out T> 
        where T : IComponentTemplate
    {
        string Name { get; }

        T Create();
    }
}