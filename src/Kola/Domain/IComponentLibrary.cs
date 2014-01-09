namespace Kola.Domain
{
    public interface IComponentLibrary
    {
        IComponentSpecification Lookup(string componentName);
    }
}