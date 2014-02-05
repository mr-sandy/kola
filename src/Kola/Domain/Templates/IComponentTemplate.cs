namespace Kola.Domain.Templates
{
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Building;

    public interface IComponentTemplate
    {
        void Accept(IComponentTemplateVisitor visitor);

        IComponentInstance Build(IBuildContext buildContext);
    }
}