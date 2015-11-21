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

    internal class ContentRepository : IContentRepository
    {
        private const string TemplateFileName = "Template.xml";
        private const string RedirectFileName = "Redirect.xml";

        private readonly SerializationHelper serializationHelper;

        private readonly IFileSystemHelper fileSystemHelper;

        private readonly string templatesDirectory;

        public ContentRepository(SerializationHelper serializationHelper, IFileSystemHelper fileSystemHelper)
            : this(serializationHelper, fileSystemHelper, rootDirectory: ConfigurationManager.AppSettings["ContentRoot"])
        {
        }

        public ContentRepository(
            SerializationHelper serializationHelper,
            IFileSystemHelper fileSystemHelper,
            string rootDirectory)
        {
            this.serializationHelper = serializationHelper;
            this.fileSystemHelper = fileSystemHelper;
            this.templatesDirectory = Path.Combine(rootDirectory, "Templates");

        }

        public void Add(IContent content)
        {
            var template = content as Template;
            if (template != null)
            {
                var surrogate = new TemplateSurrogateBuilder().Build(template);
                var directoryPath = Path.Combine(
                    this.templatesDirectory,
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
            var templatePath = Path.Combine(this.templatesDirectory, pathItems.ToFileSystemPath(), TemplateFileName);

            if (!this.fileSystemHelper.FileExists(templatePath))
            {
                return null;
            }

            var surrogate = this.serializationHelper.Deserialize<TemplateSurrogate>(templatePath);
            return new TemplateDomainBuilder(pathItems).Build(surrogate);
        }

        public IEnumerable<IContent> FindContents(IEnumerable<string> path)
        {
            var pathItems = path as string[] ?? path.ToArray();

            var directoryPath = Path.Combine(this.templatesDirectory, pathItems.ToFileSystemPath());
            var redirectPath = Path.Combine(directoryPath, RedirectFileName);
            var templatePath = Path.Combine(directoryPath, TemplateFileName);

            if (this.fileSystemHelper.FileExists(redirectPath))
            {
                var surrogate = this.serializationHelper.Deserialize<RedirectSurrogate>(redirectPath);
                yield return new RedirectDomainBuilder().Build(surrogate);
            }

            if (this.fileSystemHelper.FileExists(templatePath))
            {
                var surrogate = this.serializationHelper.Deserialize<TemplateSurrogate>(templatePath);
                yield return new TemplateDomainBuilder(pathItems).Build(surrogate);
            }
        }

        public void Update(IContent content)
        {
            var template = content as Template;
            if (template != null)
            {
                var surrogate = new TemplateSurrogateBuilder().Build(template);
                var path = Path.Combine(
                    this.templatesDirectory,
                    template.Path.ToFileSystemPath(),
                    TemplateFileName);
                this.serializationHelper.Serialize<TemplateSurrogate>(surrogate, path);
            }
        }
    }
}