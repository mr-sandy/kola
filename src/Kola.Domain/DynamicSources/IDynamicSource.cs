namespace Kola.Domain.DynamicSources
{
    using System.Collections;
    using System.Collections.Generic;

    using Kola.Domain.Instances.Context;

    public interface IDynamicSource
    {
        string Name { get; }

        DynamicItem Lookup(string value, IEnumerable<IContextItem> context);

        IEnumerable<DynamicItem> GetAllItems(IEnumerable<IContextItem> context);
    }
}