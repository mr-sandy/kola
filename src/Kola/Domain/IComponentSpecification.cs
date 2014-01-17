namespace Kola.Domain
{
    public interface IComponentSpecification<out T> where T : IComponent
    {
        string Name { get; }

        T Create();
    }
}