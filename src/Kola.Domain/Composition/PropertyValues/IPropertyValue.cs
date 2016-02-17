namespace Kola.Domain.Composition.PropertyValues
{
    using Kola.Domain.Instances.Config;

    public interface IPropertyValue
    {
        string Resolve(IBuildData buildData);

        T Accept<T>(IPropertyValueVisitor<T> visitor);

        IPropertyValue Clone();
    }
}