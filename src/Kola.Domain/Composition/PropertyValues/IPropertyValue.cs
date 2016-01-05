namespace Kola.Domain.Composition.PropertyValues
{
    using Kola.Domain.Instances.Config;

    public interface IPropertyValue
    {
        string Resolve(IBuildSettings buildSettings);

        T Accept<T>(IPropertyValueVisitor<T> visitor);

        IPropertyValue Clone();
    }
}