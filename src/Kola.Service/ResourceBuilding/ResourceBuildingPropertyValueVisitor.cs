namespace Kola.Service.ResourceBuilding
{
    using System;

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

        public PropertyValueResource Visit(MultilingualPropertyValue multilingualPropertyValue)
        {
            throw new NotImplementedException();
        }
    }
}