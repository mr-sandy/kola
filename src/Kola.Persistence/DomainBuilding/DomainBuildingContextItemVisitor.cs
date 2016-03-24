namespace Kola.Persistence.DomainBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Instances.Config;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates.ContextItems;

    internal class DomainBuildingContextItemVisitor : IContextItemSurrogateVisitor<IEnumerable<IContextItem>>
    {
        public IEnumerable<IContextItem> Visit(FixedContextItemSurrogate contextItem)
        {
            return new[] { new ContextItem(contextItem.Name, contextItem.Value) };

        }

        public IEnumerable<IContextItem> Visit(RandomContextItemSurrogate contextItem)
        {
            return contextItem.ContextItemGroups.Any() 
                ? contextItem.ContextItemGroups.Random().ContextItems.Select(i => new ContextItem(i.Name, i.Value)) 
                : Enumerable.Empty<IContextItem>();
        }
    }
}