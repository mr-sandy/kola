namespace Unit.Tests.Temp.Domain
{
    public interface ITemplate
    {
        IInstance Build(IBuildContext buildContext);
    }
}