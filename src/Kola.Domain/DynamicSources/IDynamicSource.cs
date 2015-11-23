namespace Kola.Domain.DynamicSources
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Context;

    public interface IDynamicSource
    {
        string Name { get; }

        SourceLookupResponse Lookup(string value, IEnumerable<IContextItem> context);
    }
}