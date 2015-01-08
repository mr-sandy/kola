namespace Kola.Domain.Specifications
{
    using Kola.Domain.Composition;
    using Kola.Domain.Composition.PropertyValues;

    public class PropertySpecification
    {
        public PropertySpecification(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public Property Create()
        {
            var value = new FixedPropertyValue(string.Empty);

            return new Property(this.Name, this.Type, value);
        }
    }
}