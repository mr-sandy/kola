namespace Kola.Service.ResourceBuilding
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Config;
    using Kola.Persistence;

    public class PathInstanceBuilder : IPathInstanceBuilder
    {
        private readonly IDynamicSourceProvider dynamicSourceProvider;

        public PathInstanceBuilder(IDynamicSourceProvider dynamicSourceProvider)
        {
            this.dynamicSourceProvider = dynamicSourceProvider;
        }

        public IEnumerable<string> Build(IEnumerable<string> path)
        {
            var pathArray = path as string[] ?? path.ToArray();

            return pathArray.Any() 
                ? this.Find(pathArray, string.Empty, null).ToArray() 
                : new[] { "/?preview=y" };
        }

        private IEnumerable<string> Find(IEnumerable<string> path, string pathSoFar, IEnumerable<IContextItem> context)
        {
            var pathItems = path as string[] ?? path.ToArray();

            if (!pathItems.Any())
            {
                yield return pathSoFar + "?preview=y";
            }
            else
            {
                var first = pathItems.First();

                var childResults = this.IsDynamic(first)
                                       ? this.FindDynamic(pathItems, pathSoFar, context)
                                       : this.FindStatic(pathItems, pathSoFar, context);

                foreach (var childResult in childResults)
                {
                    yield return childResult;
                }
            }
        }

        private IEnumerable<string> FindDynamic(IEnumerable<string> path, string pathSoFar, IEnumerable<IContextItem> context)
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
                foreach (var previewUrl in this.Find(pathItems.Skip(1), $"{pathSoFar}/{item.Value}", context.Merge(item.ContextItems)))
                {
                    yield return previewUrl;
                }
            }
        }

        private IEnumerable<string> FindStatic(IEnumerable<string> path, string pathSoFar, IEnumerable<IContextItem> context)
        {
            var pathItems = path as string[] ?? path.ToArray();

            return this.Find(pathItems.Skip(1), $"{pathSoFar}/{pathItems.First()}", context);
        }

        private bool IsDynamic(string element)
        {
            return element.StartsWith("-") && element.EndsWith("-");
        }
    }
}