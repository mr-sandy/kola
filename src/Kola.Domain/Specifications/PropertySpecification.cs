namespace Kola.Domain.Specifications
{
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;

    public class PropertySpecification
    {
        public PropertySpecification(string name, string type, string defaultValue)
        {
            this.Name = name;
            this.Type = type;
            this.DefaultValue = defaultValue;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public string DefaultValue { get; private set; }

        public Property Create()
        {
            var value = !string.IsNullOrEmpty(this.DefaultValue) 
                ? new FixedPropertyValue(this.DefaultValue)
                : null;

            return new Property(this.Name, this.Type, value);
        }
    }
}