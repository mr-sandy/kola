namespace Kola.Domain.DynamicSources
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Context;

    public class DynamicItem
    {
        public DynamicItem(string value, IEnumerable<IContextItem> context = null)
        {
            this.Value = value;
            this.Context = context;
        }

        public string Value { get; }

        public IEnumerable<IContextItem> Context { get; }
    }
}