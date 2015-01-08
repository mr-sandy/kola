namespace Kola.Domain.Composition.PropertyValues
{
    using Kola.Domain.Instances.Building;

    public class FixedPropertyValue : IPropertyValue
    {
        public FixedPropertyValue(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public string Resolve(IBuildContext buildContext)
        {
            return this.Value;
        }

        public T Accept<T>(IPropertyValueVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}