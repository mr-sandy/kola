namespace Kola.Service.ResourceBuilding
{
    using System.Linq;

    using Kola.Domain.Composition.PropertyValues;
    using Kola.Resources;

    internal class ResourceBuildingPropertyValueVisitor : IPropertyValueVisitor<PropertyValueResource>
    {
        public PropertyValueResource Visit(FixedPropertyValue fixedPropertyValue)
        {
            return new FixedPropertyValueResource
            {
                Value = fixedPropertyValue.Value
            };
        }

        public PropertyValueResource Visit(InheritedPropertyValue inheritedPropertyValue)
        {
            return new InheritedPropertyValueResource
            {
                Key = inheritedPropertyValue.Key
            };
        }

        public PropertyValueResource Visit(VariablePropertyValue variablePropertyValue)
        {
            return new VariablePropertyValueResource
            {
                ContextName = variablePropertyValue.ContextName,
                Variants = variablePropertyValue.Variants.Select(v => new PropertyVariantResource
                {
                    ContextValue = v.ContentValue,
                    Value = v.Value.Accept(this),
                    IsDefault = v.IsDefault
                })
                .ToArray()
            };
        }
    }
}