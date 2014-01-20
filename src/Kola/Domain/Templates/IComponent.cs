namespace Kola.Domain.Templates
{
    public interface IComponent
    {
        string Name { get; }

        void Accept(IComponentVisitor visitor);
    }
}