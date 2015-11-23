namespace Kola.Persistence
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Kola.Domain.DynamicSources;
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Context;

    public class ContentFinder : IContentFinder
    {
        private readonly IFileSystemHelper fileSystemHelper;
        private readonly IDynamicSourceProvider dynamicSourceProvider;

        private readonly string templatesDirectory = "Templates";


        public ContentFinder(IFileSystemHelper fileSystemHelper, IDynamicSourceProvider dynamicSourceProvider)
        {
            this.fileSystemHelper = fileSystemHelper;
            this.dynamicSourceProvider = dynamicSourceProvider;
        }

        public IEnumerable<ContentDirectory> FindContentDirectories(IEnumerable<string> path)
        {
            return this.Find(path, this.templatesDirectory, Enumerable.Empty<IContextItem>());
        }

        private IEnumerable<ContentDirectory> Find(IEnumerable<string> path, string pathSoFar, IEnumerable<IContextItem> context)
        {
            var pathItems = path as string[] ?? path.ToArray();
            var contextItems = context as IContextItem[] ?? context.ToArray();

            if (!pathItems.Any())
            {
                return new[] { new ContentDirectory(pathSoFar, contextItems) };
            }

            var staticResults = this.FindStatic(pathItems, pathSoFar, contextItems);
            var dynamicResults = this.FindDynamic(pathItems, pathSoFar, contextItems);

            return staticResults.Concat(dynamicResults);
        }

        private IEnumerable<ContentDirectory> FindStatic(string[] path, string pathSoFar, IEnumerable<IContextItem> context)
        {
            var staticPath = Path.Combine(pathSoFar, path.First());

            return this.fileSystemHelper.DirectoryExists(staticPath)
                ? this.Find(path.Skip(1), staticPath, context)
                : Enumerable.Empty<ContentDirectory>();
        }

        private IEnumerable<ContentDirectory> FindDynamic(string[] path, string pathSoFar, IContextItem[] context)
        {
            var dynamicChildren = this.fileSystemHelper.FindChildDirectories(pathSoFar, "-*-") ?? Enumerable.Empty<string>();

            return dynamicChildren.SelectMany(sourceName =>
                {
                    var source = this.dynamicSourceProvider.Get(sourceName);

                    var lookup = source?.Lookup(path.First(), context);

                    return lookup != null
                        ? this.Find(path.Skip(1), Path.Combine(pathSoFar, sourceName), context.Merge(lookup.Context))
                        : Enumerable.Empty<ContentDirectory>();
                });
        }
    }
}