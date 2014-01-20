namespace Kola.Domain.Instances
{
    public interface IComponentInstance
    {
        string Name { get; }

        T Accept<T>(IComponentInstanceVisitor<T> visitor);
    }
}