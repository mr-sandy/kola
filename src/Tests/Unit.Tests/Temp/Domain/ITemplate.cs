namespace Unit.Tests.Temp.Domain
{
    public interface ITemplate<out T>
        where T : IInstance
    {
        T Build();
    }
}