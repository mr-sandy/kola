namespace Kola.Persistence.SurrogateBuilding
{
    using System.Linq;

    using Kola.Domain.Composition.PropertyValues;
    using Kola.Persistence.Surrogates.PropertyValues;

    internal class SurrogateBuildingPropertyValueVisitor : IPropertyValueVisitor<PropertyValueSurrogate>
    {
        public PropertyValueSurrogate Visit(FixedPropertyValue fixedPropertyValue)
        {
            return new FixedPropertyValueSurrogate
            {
                Value = fixedPropertyValue.Value
            };
        }

        public PropertyValueSurrogate Visit(InheritedPropertyValue inheritedPropertyValue)
        {
            return new InheritedPropertyValueSurrogate
            {
                Key = inheritedPropertyValue.Key
            };
        }

        public PropertyValueSurrogate Visit(VariablePropertyValue variablePropertyValue)
        {
            return new VariablePropertyValueSurrogate
            {
                ContextName = variablePropertyValue.ContextName,
                Variants = variablePropertyValue.Variants.Select(v => new PropertyVariantSurrogate
                                                                     {
                                                                         ContextValue = v.ContentValue,
                                                                         Value = v.Value.Accept(this),
                                                                         IsDefault = v.IsDefault
                }).ToArray()
            };
        }
    }
}