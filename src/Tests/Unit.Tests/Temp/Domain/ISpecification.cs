namespace Unit.Tests.Temp.Domain
{
    public interface ISpecification<out T>
        where T : ITemplate
    {
        T Create();
    }
}