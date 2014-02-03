namespace Unit.Tests.Temp.Domain.Templates
{
    using Unit.Tests.Temp.Domain.Instances;

    public interface IComponentTemplate
    {
        IComponentInstance Build(IBuildContext buildContext);
    }
}
