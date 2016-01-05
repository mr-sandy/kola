namespace Persistence.Tests.ContentFinderTests.FakeSources
{
    using System;
    using System.Collections.Generic;

    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Config;

    internal class TestSource : IDynamicSource
    {
        public Func<string, IEnumerable<IContextItem>, DynamicItem> Func { get; set; }

        public string Name { get; set; }

        public DynamicItem Lookup(string value, IEnumerable<IContextItem> context)
        {
            return this.Func(value, context);
        }

        public IEnumerable<DynamicItem> GetAllItems(IEnumerable<IContextItem> context)
        {
            throw new NotImplementedException();
        }
    }
}
