namespace Kola.Persistence.DomainBuilding
{
    using System;

    using Kola.Domain.Composition.PropertyValues;
    using Kola.Persistence.Surrogates.PropertyValues;

    internal class DomainBuildingPropertyValueVisitor : IPropertyValueSurrogateVisitor<IPropertyValue>
    {
        public IPropertyValue Visit(FixedPropertyValueSurrogate surrogate)
        {
            return new FixedPropertyValue(surrogate.Value);
        }

        public IPropertyValue Visit(InheritedPropertyValueSurrogate surrogate)
        {
            return new InheritedPropertyValue(surrogate.Key);
        }

        public IPropertyValue Visit(MultilingualPropertyValueSurrogate surrogate)
        {
            throw new NotImplementedException();
        }
    }
}