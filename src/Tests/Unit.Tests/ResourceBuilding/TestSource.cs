namespace Unit.Tests.ResourceBuilding
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Context;

    internal class TestSource : IDynamicSource
    {
        public Func<string, IEnumerable<IContextItem>, DynamicItem> LookupFunc { get; set; }

        public Func<IEnumerable<IContextItem>, IEnumerable<DynamicItem>> GetAllItemsFunc { get; set; }

        public string Name { get; set; }

        public DynamicItem Lookup(string value, IEnumerable<IContextItem> context)
        {
            return this.LookupFunc(value, context);
        }

        public IEnumerable<DynamicItem> GetAllItems(IEnumerable<IContextItem> context)
        {
            return this.GetAllItemsFunc(context);
        }
    }
}