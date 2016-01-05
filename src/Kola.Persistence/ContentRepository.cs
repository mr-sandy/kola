namespace Kola.Persistence
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;

    using Kola.Domain.Composition;
    using Kola.Persistence.DomainBuilding;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.SurrogateBuilding;
    using Kola.Persistence.Surrogates;

    public class ContentRepository : IContentRepository
    {
        private const string TemplateFileName = "Template.xml";
        private const string RedirectFileName = "Redirect.xml";
        private const string TemplatesDirectory = "Templates";

        private readonly ISerializationHelper serializationHelper;

        private readonly IFileSystemHelper fileSystemHelper;

        private readonly IContentFinder contentFinder;


        public ContentRepository(
            ISerializationHelper serializationHelper,
            IFileSystemHelper fileSystemHelper,
            IContentFinder contentFinder)
        {
            this.serializationHelper = serializationHelper;
            this.fileSystemHelper = fileSystemHelper;
            this.contentFinder = contentFinder;
        }

        public void Add(IContent content)
        {
            var template = content as Template;
            if (template != null)
            {
                var surrogate = new TemplateSurrogateBuilder().Build(template);
                var directoryPath = Path.Combine(
                    TemplatesDirectory,
                    template.Path.ToFileSystemPath());

                if (!this.fileSystemHelper.DirectoryExists(directoryPath))
                {
                    this.fileSystemHelper.CreateDirectory(directoryPath);
                }

                var path = Path.Combine(directoryPath, TemplateFileName);
                this.serializationHelper.Serialize<TemplateSurrogate>(surrogate, path);
            }
        }

        public Template GetTemplate(IEnumerable<string> path)
        {
            var pathItems = path as string[] ?? path.ToArray();
            var templatePath = Path.Combine(TemplatesDirectory, pathItems.ToFileSystemPath(), TemplateFileName);

            if (!this.fileSystemHelper.FileExists(templatePath))
            {
                return null;
            }

            var surrogate = this.serializationHelper.Deserialize<TemplateSurrogate>(templatePath);
            return new TemplateDomainBuilder(pathItems).Build(surrogate);
        }

        public IEnumerable<FindContentResult> FindContent(IEnumerable<string> path)
        {
            var pathItems = path as string[] ?? path.ToArray();

            var directories = this.contentFinder.FindContentDirectories(pathItems);

            foreach (var directory in directories)
            {
                var redirectPath = Path.Combine(directory.Path, RedirectFileName);
                var templatePath = Path.Combine(directory.Path, TemplateFileName);

                if (this.fileSystemHelper.FileExists(redirectPath))
                {
                    var surrogate = this.serializationHelper.Deserialize<RedirectSurrogate>(redirectPath);
                    var redirect = new RedirectDomainBuilder().Build(surrogate);
                    yield return new FindContentResult(redirect, directory.Configuration);
                }

                if (this.fileSystemHelper.FileExists(templatePath))
                {
                    var surrogate = this.serializationHelper.Deserialize<TemplateSurrogate>(templatePath);
                    var template = new TemplateDomainBuilder(pathItems).Build(surrogate);
                    yield return new FindContentResult(template, directory.Configuration);
                }
            }
        }

        public void Update(IContent content)
        {
            var template = content as Template;
            if (template != null)
            {
                var surrogate = new TemplateSurrogateBuilder().Build(template);
                var path = Path.Combine(
                    TemplatesDirectory,
                    template.Path.ToFileSystemPath(),
                    TemplateFileName);
                this.serializationHelper.Serialize<TemplateSurrogate>(surrogate, path);
            }
        }
    }
}