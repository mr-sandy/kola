namespace Kola.Domain.DynamicSources
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Context;

    public interface IDynamicSource
    {
        SourceLookupResponse Lookup(string value, IEnumerable<IContextItem> context);
    }
}