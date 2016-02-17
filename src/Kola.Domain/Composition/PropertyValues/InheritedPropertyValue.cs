namespace Kola.Domain.Composition.PropertyValues
{
    using System;
    using System.Linq;

    using Kola.Domain.Instances.Config;

    public class InheritedPropertyValue : IPropertyValue
    {
        public InheritedPropertyValue(string key)
        {
            this.Key = key;
        }

        public string Key { get; set; }

        public string Resolve(IBuildData buildData)
        {
            foreach (var contextSet in buildData.ContextSets)
            {
                var item = contextSet.Items.FirstOrDefault(i => i.Name.Equals(this.Key));

                if (item != null)
                {
                    return item.Value;
                }
            }

            return string.Empty;
        }

        public T Accept<T>(IPropertyValueVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public IPropertyValue Clone()
        {
            return new InheritedPropertyValue(this.Key);
        }
    }
}