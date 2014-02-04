namespace Kola.Domain.Templates
{
    using Kola.Domain.Instances;
 
    public interface IComponentTemplate
    {
        void Accept(IComponentTemplateVisitor visitor);

        IComponentInstance Build(IBuildContext buildContext);
    }
}