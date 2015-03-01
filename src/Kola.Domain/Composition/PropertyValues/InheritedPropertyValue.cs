namespace Kola.Domain.Composition.PropertyValues
{
    using System;
    using System.Linq;

    using Kola.Domain.Instances.Context;

    public class InheritedPropertyValue : IPropertyValue
    {
        public InheritedPropertyValue(string key)
        {
            this.Key = key;
        }

        public string Key { get; set; }

        public string Resolve(IBuildContext buildContext)
        {
            foreach (var contextSet in buildContext.ContextSets)
            {
                var item = contextSet.Items.Where(i => i.Name.Equals(this.Key)).FirstOrDefault();

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