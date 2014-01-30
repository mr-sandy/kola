namespace Unit.Tests.Temp.Domain
{
    public interface ISpecification<out T>
        where T : IInstance
    {
        ITemplate<T> Create();
    }
}