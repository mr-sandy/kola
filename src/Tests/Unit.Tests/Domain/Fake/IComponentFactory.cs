namespace Unit.Tests.Domain.Fake
{
    public interface IComponentFactory
    {
        IComponent Create(string componentName);
    }
}