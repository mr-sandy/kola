namespace Kola.Persistence.SurrogateBuilding
{
    using System;

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
            return new InheritedPropertyValueSurrogate();
        }

        public PropertyValueSurrogate Visit(MultilingualPropertyValue multilingualPropertyValue)
        {
            throw new NotImplementedException();
        }
    }
}