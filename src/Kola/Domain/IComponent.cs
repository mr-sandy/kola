namespace Kola.Domain
{
    public interface IComponent
    {
        string Name { get; }

        void Accept(IComponentVisitor visitor);
    }
}