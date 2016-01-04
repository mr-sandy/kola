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
        private readonly IContextRepository contextRepository;

        private readonly string templatesDirectory = "Templates";


        public ContentFinder(IFileSystemHelper fileSystemHelper, IDynamicSourceProvider dynamicSourceProvider, IContextRepository contextSettingsRepository)
        {
            this.fileSystemHelper = fileSystemHelper;
            this.dynamicSourceProvider = dynamicSourceProvider;
            this.contextRepository = contextSettingsRepository;
        }

        public IEnumerable<ContentDirectory> FindContentDirectories(IEnumerable<string> path)
        {
            return this.Find(path, this.templatesDirectory, new Context());
        }

        private IEnumerable<ContentDirectory> Find(IEnumerable<string> path, string pathSoFar, IContext context)
        {
            var pathItems = path as string[] ?? path.ToArray();

            var contextFromFile = this.contextRepository.Get(pathSoFar);
            var newContext = context.Merge(contextFromFile);

            if (!pathItems.Any())
            {
                return new[] { new ContentDirectory(pathSoFar, newContext) };
            }

            var staticResults = this.FindStatic(pathItems, pathSoFar, newContext);
            var dynamicResults = this.FindDynamic(pathItems, pathSoFar, newContext);

            return staticResults.Concat(dynamicResults);
        }

        private IEnumerable<ContentDirectory> FindStatic(string[] path, string pathSoFar, IContext context)
        {
            var staticPath = Path.Combine(pathSoFar, path.First());

            return this.fileSystemHelper.DirectoryExists(staticPath)
                ? this.Find(path.Skip(1), staticPath, context)
                : Enumerable.Empty<ContentDirectory>();
        }

        private IEnumerable<ContentDirectory> FindDynamic(string[] path, string pathSoFar, IContext context)
        {
            var dynamicChildren = this.fileSystemHelper.FindChildDirectories(pathSoFar, "-*-") ?? Enumerable.Empty<string>();

            return dynamicChildren.SelectMany(sourceName =>
                {
                    var source = this.dynamicSourceProvider.Get(sourceName);

                    var lookup = source?.Lookup(path.First(), context.ContextItems);

                    return lookup != null
                        ? this.Find(path.Skip(1), Path.Combine(pathSoFar, sourceName), context.Merge(lookup.ContextItems))
                        : Enumerable.Empty<ContentDirectory>();
                });
        }
    }
}