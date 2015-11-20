namespace Kola.Domain.DynamicSources
{
    using System.Collections.Generic;

    using Kola.Domain.Instances.Context;

    public class SourceLookupResponse
    {
        public SourceLookupResponse(bool found, IEnumerable<IContextItem> contextItems = null)
        {
            this.Found = found;
            this.ContextItems = contextItems;
        }

        public bool Found { get; }

        public IEnumerable<IContextItem> ContextItems { get; }
    }
}