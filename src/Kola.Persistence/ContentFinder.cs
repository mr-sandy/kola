namespace Kola.Persistence
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Kola.Domain.DynamicSources;
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Config;

    public class ContentFinder : IContentFinder
    {
        private readonly IFileSystemHelper fileSystemHelper;
        private readonly IDynamicSourceProvider dynamicSourceProvider;
        private readonly IConfigurationRepository configurationRepository;

        private readonly string templatesDirectory = "Templates";


        public ContentFinder(IFileSystemHelper fileSystemHelper, IDynamicSourceProvider dynamicSourceProvider, IConfigurationRepository configurationRepository)
        {
            this.fileSystemHelper = fileSystemHelper;
            this.dynamicSourceProvider = dynamicSourceProvider;
            this.configurationRepository = configurationRepository;
        }

        public IEnumerable<ContentDirectory> FindContentDirectories(IEnumerable<string> path)
        {
            return this.Find(path, this.templatesDirectory, new Configuration());
        }

        private IEnumerable<ContentDirectory> Find(IEnumerable<string> path, string pathSoFar, IConfiguration configuration)
        {
            var pathItems = path as string[] ?? path.ToArray();

            var additionalConfiguration = this.configurationRepository.Get(pathSoFar);
            var updatedConfiguration = configuration.Merge(additionalConfiguration);

            if (!pathItems.Any())
            {
                return new[] { new ContentDirectory(pathSoFar, updatedConfiguration) };
            }

            var staticResults = this.FindStatic(pathItems, pathSoFar, updatedConfiguration);
            var dynamicResults = this.FindDynamic(pathItems, pathSoFar, updatedConfiguration);

            return staticResults.Concat(dynamicResults);
        }

        private IEnumerable<ContentDirectory> FindStatic(string[] path, string pathSoFar, IConfiguration configuration)
        {
            var staticPath = Path.Combine(pathSoFar, path.First());

            return this.fileSystemHelper.DirectoryExists(staticPath)
                ? this.Find(path.Skip(1), staticPath, configuration)
                : Enumerable.Empty<ContentDirectory>();
        }

        private IEnumerable<ContentDirectory> FindDynamic(string[] path, string pathSoFar, IConfiguration configuration)
        {
            var dynamicChildren = this.fileSystemHelper.FindChildDirectories(pathSoFar, "-*-") ?? Enumerable.Empty<string>();

            return dynamicChildren.SelectMany(sourceName =>
                {
                    var source = this.dynamicSourceProvider.Get(sourceName);

                    var lookup = source?.Lookup(path.First(), configuration.ContextItems);

                    return lookup != null
                        ? this.Find(path.Skip(1), Path.Combine(pathSoFar, sourceName), configuration.Merge(lookup.ContextItems))
                        : Enumerable.Empty<ContentDirectory>();
                });
        }
    }
}