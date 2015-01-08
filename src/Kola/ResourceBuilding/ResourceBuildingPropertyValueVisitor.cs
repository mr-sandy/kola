namespace Kola.ResourceBuilding
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
            throw new NotImplementedException();
        }

        public PropertyValueResource Visit(MultilingualPropertyValue multilingualPropertyValue)
        {
            throw new NotImplementedException();
        }
    }
}