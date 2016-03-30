namespace Kola.Domain.Composition.PropertyValues
{
    public interface IPropertyValueVisitor<out T>
    {
        T Visit(FixedPropertyValue fixedPropertyValue);

        T Visit(InheritedPropertyValue inheritedPropertyValue);

        T Visit(VariablePropertyValue variablePropertyValue);
    }
}