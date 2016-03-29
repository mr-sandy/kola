namespace Kola.Domain.DynamicSources
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Config;

    public interface IDynamicSource
    {
        string Name { get; }

        DynamicItem Lookup(string value, IEnumerable<IContextItem> context);

        IEnumerable<DynamicItem> GetAllItems(IEnumerable<IContextItem> context);
    }
}