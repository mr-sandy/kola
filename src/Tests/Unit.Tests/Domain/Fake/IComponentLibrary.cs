namespace Unit.Tests.Domain.Fake
{
    public interface IComponentLibrary
    {
        IComponentSpecification Lookup(string componentName);
    }
}