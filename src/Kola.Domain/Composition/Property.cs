namespace Kola.Domain.Composition
{
    using System;

    using Kola.Domain.Composition.PropertyValues;
    using Kola.Domain.Instances;
    using Kola.Domain.Instances.Context;

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

        public PropertyInstance Build(IBuildContext buildContext)
        {
            return new PropertyInstance(this.Name, this.Value?.Resolve(buildContext));
        }

        public Property Clone()
        {
            return new Property(this.Name, this.Type, this.Value?.Clone());
        }
    }
}