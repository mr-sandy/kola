namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Kola.Domain.Composition;

    public class ContentFinder
    {
        private readonly IFileSystemHelper fileSystemHelper;
        private readonly IDynamicSourceProvider dynamicSourceProvider;

        private readonly string root;

        public ContentFinder(IFileSystemHelper fileSystemHelper, IDynamicSourceProvider dynamicSourceProvider, string root)
        {
            this.fileSystemHelper = fileSystemHelper;
            this.dynamicSourceProvider = dynamicSourceProvider;
            this.root = root;
        }

        public IEnumerable<string> FindContentDirectories(IEnumerable<string> path)
        {
            return this.Find(path, this.root);
        }

        private IEnumerable<string> Find(IEnumerable<string> path, string pathSoFar)
        {
            var pathArray = path as string[] ?? path.ToArray();

            if (!pathArray.Any())
            {
                yield return pathSoFar;
            }
            else
            {
                foreach (var candidatePath in this.GetCandidatePaths(pathSoFar, pathArray.First()))
                {
                    foreach (var p in this.Find(pathArray.Skip(1), candidatePath))
                    {
                        yield return p;
                    }
                }
            }
        }

        private IEnumerable<string> GetCandidatePaths(string pathSoFar, string element)
        {
            var staticPath = Path.Combine(pathSoFar, element);

            if (this.fileSystemHelper.DirectoryExists(staticPath))
            {
                yield return staticPath;
            }

            //Find any dynamic options 
            foreach (var dynamicChild in this.FindDynamicChildren(pathSoFar))
            {
                if (this.CheckDynamicSource(dynamicChild, element))
                {
                    yield return Path.Combine(pathSoFar, dynamicChild);
                }
            }
        }

        private bool CheckDynamicSource(string sourceName, string value)
        {
            var source = this.dynamicSourceProvider.Get(sourceName);

            return source != null && source.AcceptsValue(value);
        }

        private IEnumerable<string> FindDynamicChildren(string pathSoFar)
        {
            return this.fileSystemHelper.FindChildDirectories(pathSoFar, "-*-") ?? Enumerable.Empty<string>();
        }
    }

    public interface IDynamicSourceProvider
    {
        IDynamicSource Get(string sourceName);
    }

    public interface IDynamicSource
    {
        bool AcceptsValue(string value);
    }

}