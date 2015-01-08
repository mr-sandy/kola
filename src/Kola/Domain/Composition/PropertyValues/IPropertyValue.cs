namespace Kola.Domain.Composition.PropertyValues
{
    using Kola.Domain.Instances.Building;

    public interface IPropertyValue
    {
        string Resolve(IBuildContext buildContext);

        T Accept<T>(IPropertyValueVisitor<T> visitor);
    }
}