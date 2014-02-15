namespace Kola.Domain.Composition
{
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public interface IComponent
    {
        void Accept(IComponentVisitor visitor);

        IComponentInstance Build(IBuildContext buildContext);
    }
}