namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Context;

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

        public IEnumerable<ContentDirectory> FindContentDirectories(IEnumerable<string> path)
        {
            return this.Find(path, this.root, Enumerable.Empty<IContextItem>());
        }

        private IEnumerable<ContentDirectory> Find(IEnumerable<string> path, string pathSoFar, IEnumerable<IContextItem> contextItems)
        {
            var pathArray = path as string[] ?? path.ToArray();

            if (!pathArray.Any())
            {
                yield return new ContentDirectory(pathSoFar, contextItems);
            }
            else
            {
                foreach (var candidate in this.GetCandidates(pathSoFar, pathArray.First(), contextItems))
                {
                    foreach (var p in this.Find(pathArray.Skip(1), candidate.Path, candidate.ContextItems))
                    {
                        yield return p;
                    }
                }
            }
        }

        private IEnumerable<ContentDirectory> GetCandidates(string pathSoFar, string element, IEnumerable<IContextItem> context)
        {
            var staticPath = Path.Combine(pathSoFar, element);

            if (this.fileSystemHelper.DirectoryExists(staticPath))
            {
                yield return new ContentDirectory(staticPath, null);
            }

            //Find any dynamic options 
            foreach (var dynamicChild in this.FindDynamicChildren(pathSoFar))
            {
                var source = this.dynamicSourceProvider.Get(dynamicChild);

                var lookup = source?.Lookup(element, context);

                if (lookup != null && lookup.Found)
                {
                    yield return new ContentDirectory(Path.Combine(pathSoFar, dynamicChild), context.Merge(lookup.ContextItems));
                }
            }
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
        SourceLookupResponse Lookup(string value, IEnumerable<IContextItem> context);
    }

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

    public class ContentDirectory
    {
        public ContentDirectory(string path, IEnumerable<IContextItem> contextItems)
        {
            this.Path = path;
            this.ContextItems = contextItems;
        }

        public string Path { get; }

        public IEnumerable<IContextItem> ContextItems { get; }
    }
}