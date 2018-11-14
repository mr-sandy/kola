namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Kola.Domain.Composition;
    using Kola.Domain.DynamicSources;
    using Kola.Domain.Extensions;
    using Kola.Domain.Instances.Config;

    public class ContentLister : IContentLister
    {
        private readonly IContentRepository contentRepository;
        private readonly IPathInstanceBuilder pathInstanceBuilder;

        public ContentLister(IContentRepository contentRepository, IPathInstanceBuilder pathInstanceBuilder)
        {
            this.contentRepository = contentRepository;
            this.pathInstanceBuilder = pathInstanceBuilder;
        }

        public IEnumerable<string> FindAllPaths()
        {
            var templatePaths = this.contentRepository.GetAllTemplatePaths();

            var contentPaths =  templatePaths.SelectMany(path => this.pathInstanceBuilder.Build(path, false));

            return contentPaths;
        }
    }
}