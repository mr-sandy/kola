namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Config;

    public class PathInstanceBuilder : IPathInstanceBuilder
    {
        private readonly IDynamicSourceProvider dynamicSourceProvider;

        public PathInstanceBuilder(IDynamicSourceProvider dynamicSourceProvider)
        {
            this.dynamicSourceProvider = dynamicSourceProvider;
        }

        public IEnumerable<string> Build(IEnumerable<string> path, bool preview)
        {
            var pathArray = path as string[] ?? path.ToArray();

            return pathArray.Any() 
                ? this.Find(pathArray, string.Empty, null, preview).ToArray() 
                : new[] { preview ?  "/?preview=y" : "/" };
        }

        private IEnumerable<string> Find(IEnumerable<string> path, string pathSoFar, IEnumerable<IContextItem> context, bool preview)
        {
            var pathItems = path as string[] ?? path.ToArray();

            if (!pathItems.Any())
            {
                yield return preview 
                    ? pathSoFar + "?preview=y" 
                    : pathSoFar;
            }
            else
            {
                var first = pathItems.First();

                var childResults = this.IsDynamic(first)
                                       ? this.FindDynamic(pathItems, pathSoFar, context, preview)
                                       : this.FindStatic(pathItems, pathSoFar, context, preview);

                foreach (var childResult in childResults)
                {
                    yield return childResult;
                }
            }
        }

        private IEnumerable<string> FindDynamic(IEnumerable<string> path, string pathSoFar, IEnumerable<IContextItem> context, bool preview)
        {
            var pathItems = path as string[] ?? path.ToArray();

            var sourceName = pathItems.First();
            var provider = this.dynamicSourceProvider.Get(sourceName);

            if (provider == null)
            {
                yield break;
            }

            foreach (var item in provider.GetAllItems(context))
            {
                foreach (var previewUrl in this.Find(pathItems.Skip(1), $"{pathSoFar}/{item.Value}", context.Merge(item.ContextItems), preview))
                {
                    yield return previewUrl;
                }
            }
        }

        private IEnumerable<string> FindStatic(IEnumerable<string> path, string pathSoFar, IEnumerable<IContextItem> context, bool preview)
        {
            var pathItems = path as string[] ?? path.ToArray();

            return this.Find(pathItems.Skip(1), $"{pathSoFar}/{pathItems.First()}", context, preview);
        }

        private bool IsDynamic(string element)
        {
            return element.StartsWith("-") && element.EndsWith("-");
        }
    }
}