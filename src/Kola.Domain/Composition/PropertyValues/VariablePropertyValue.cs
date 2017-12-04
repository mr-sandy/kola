namespace Kola.Domain.Composition.PropertyValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Config;

    public class VariablePropertyValue : IPropertyValue
    {
        public VariablePropertyValue(string contextName, IEnumerable<PropertyVariant> variants)
        {
            this.ContextName = contextName;
            this.Variants = variants;
        }

        public string ContextName { get; }

        public IEnumerable<PropertyVariant> Variants { get; }

        public string Resolve(IBuildData buildData)
        {
            // find the closest context item specifying a value for the context key
            var key = this.EstablishSoughtKey(buildData);

            return this.Variants.FirstOrDefault(v => v.ContentValue.Equals(key, StringComparison.OrdinalIgnoreCase))?.Value.Resolve(buildData)
                   ?? this.Variants.FirstOrDefault(v => v.ContentValue.Split(' ').Contains(key, StringComparer.OrdinalIgnoreCase))?.Value.Resolve(buildData)
                   ?? this.Variants.FirstOrDefault(v => v.IsDefault)?.Value.Resolve(buildData)
                   ?? string.Empty;
        }

        public T Accept<T>(IPropertyValueVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public IPropertyValue Clone()
        {
            return new VariablePropertyValue(this.ContextName, this.Variants.Clone());
        }

        private string EstablishSoughtKey(IBuildData buildData)
        {
            foreach (var contextSet in buildData.ContextSets)
            {
                var key = contextSet.FirstOrDefault(i => i.Name == this.ContextName && !string.IsNullOrWhiteSpace(i.Value))?.Value;

                if (!string.IsNullOrWhiteSpace(key))
                {
                    return key;
                }
            }

            return string.Empty;
        }
    }
}