namespace Kola.Domain.Composition
{
    using System;

    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Config;

    public class Property
    {
        public Property(string name, string type, IPropertyValue value)
        {
            this.Name = name;
            this.Type = type;
            this.Value = value;
        }

        public string Name { get; }

        public string Type { get; }

        public IPropertyValue Value { get; set; }

        public PropertyInstance Build(IBuildData buildData)
        {
            return new PropertyInstance(this.Name, this.Value?.Resolve(buildData));
        }

        public Property Clone()
        {
            return new Property(this.Name, this.Type, this.Value?.Clone());
        }
    }
}