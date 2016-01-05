namespace Kola.Domain.DynamicSources
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Config;

    public class DynamicItem
    {
        public DynamicItem(string value, IEnumerable<IContextItem> contextItems = null)
        {
            this.Value = value;
            this.ContextItems = contextItems;
        }

        public string Value { get; }

        public IEnumerable<IContextItem> ContextItems { get; }
    }
}