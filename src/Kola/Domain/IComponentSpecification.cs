namespace Kola.Domain
{
    public interface IComponentSpecification
    {
        string Name { get; }

        IComponent Create();
    }
}