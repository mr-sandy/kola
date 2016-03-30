namespace Kola.Domain.Composition.PropertyValues
{
    public class PropertyVariant
    {
        public PropertyVariant(string contentValue, IPropertyValue value, bool isDefault = false)
        {
            this.ContentValue = contentValue;
            this.Value = value;
            this.IsDefault = isDefault;
        }

        public string ContentValue { get; }

        public IPropertyValue Value { get; }

        public bool IsDefault { get; }

        public PropertyVariant Clone()
        {
            return new PropertyVariant(this.ContentValue, this.Value, this.IsDefault);
        }
    }
}