namespace Kola.Nancy.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Resources;

    internal static class CompositeResourceExtensions
    {
        public static CompositeResource FindLastChild(this CompositeResource compositeResource, IEnumerable<int> path)
        {
            return (path.Count() != 0)
                       ? compositeResource.Components.ElementAt(path.First()).FindLastChild(path.Skip(1))
                       : compositeResource.Components.Last();
        }
    }
}