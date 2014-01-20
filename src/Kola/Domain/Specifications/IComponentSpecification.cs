namespace Kola.Domain.Specifications
{
    using Kola.Domain.Templates;

    public interface IComponentSpecification<out T> where T : IComponent
    {
        string Name { get; }

        T Create();
    }
}