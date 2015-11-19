namespace Kola.Persistence
{
    using System.Collections.Generic;
    using System.Configuration;

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

        private readonly FileSystemHelper fileSystemHelper;

        private readonly string templatesDirectory;

        public ContentRepository(SerializationHelper serializationHelper, FileSystemHelper fileSystemHelper)
            : this(serializationHelper, fileSystemHelper, rootDirectory: ConfigurationManager.AppSettings["ContentRoot"])
        {
        }

        public ContentRepository(
            SerializationHelper serializationHelper,
            FileSystemHelper fileSystemHelper,
            string rootDirectory)
        {
            this.serializationHelper = serializationHelper;
            this.fileSystemHelper = fileSystemHelper;
            this.templatesDirectory = fileSystemHelper.CombinePaths(new[] { rootDirectory, "Templates" });

        }

        public void Add(IContent content)
        {
            var template = content as Template;
            if (template != null)
            {
                var surrogate = new TemplateSurrogateBuilder().Build(template);
                var directoryPath = this.fileSystemHelper.CombinePaths(
                    this.templatesDirectory,
                    template.Path.ToFileSystemPath());

                if (!this.fileSystemHelper.DirectoryExists(directoryPath))
                {
                    this.fileSystemHelper.CreateDirectory(directoryPath);
                }

                var path = this.fileSystemHelper.CombinePaths(directoryPath, TemplateFileName);
                this.serializationHelper.Serialize<TemplateSurrogate>(surrogate, path);
            }
        }

        public Template GetTemplate(IEnumerable<string> path)
        {
            var templatePath = this.fileSystemHelper.CombinePaths(
                this.templatesDirectory,
                path.ToFileSystemPath(),
                TemplateFileName);

            if (!this.fileSystemHelper.FileExists(templatePath))
            {
                return null;
            }

            var surrogate = this.serializationHelper.Deserialize<TemplateSurrogate>(templatePath);
            return new TemplateDomainBuilder(path).Build(surrogate);
        }

        public Redirect GetRedirect(IEnumerable<string> path)
        {
            var redirectPath = this.fileSystemHelper.CombinePaths(
                this.templatesDirectory,
                path.ToFileSystemPath(),
                RedirectFileName);

            if (!this.fileSystemHelper.FileExists(redirectPath))
            {
                return null;
            }

            var surrogate = this.serializationHelper.Deserialize<RedirectSurrogate>(redirectPath);
            return new RedirectDomainBuilder().Build(surrogate);
        }

        public IContent Get(IEnumerable<string> path)
        {
            return (IContent)this.GetRedirect(path) ?? (IContent)this.GetTemplate(path);
        }

        public void Update(IContent content)
        {
            var template = content as Template;
            if (template != null)
            {
                var surrogate = new TemplateSurrogateBuilder().Build(template);
                var path = this.fileSystemHelper.CombinePaths(
                    this.templatesDirectory,
                    template.Path.ToFileSystemPath(),
                    TemplateFileName);
                this.serializationHelper.Serialize<TemplateSurrogate>(surrogate, path);
            }
        }
    }
}