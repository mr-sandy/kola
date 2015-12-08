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

        public string Name { get; }

        public string Type { get; }

        public string DefaultValue { get; }

        public Property Create(IPropertyValue value = null)
        {
            return new Property(this.Name, this.Type, value);
        }
    }
}