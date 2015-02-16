namespace Kola.Persistence
{
    using System.Collections.Generic;
    using System.Configuration;

    using Kola.Domain.Composition;
    using Kola.Extensions;
    using Kola.Persistence.DomainBuilding;
    using Kola.Persistence.SurrogateBuilding;
    using Kola.Persistence.Surrogates;

    internal class TemplateRepository : ITemplateRepository
    {
        //private const string RootDirectory = @"C:\projects\kola\src\Kola\Persistence\Templates";
        private const string TemplateFileName = "Template.xml";

        private readonly SerializationHelper serializationHelper;
        private readonly FileSystemHelper fileSystemHelper;
        private readonly string rootDirectory;

        public TemplateRepository(SerializationHelper serializationHelper, FileSystemHelper fileSystemHelper)
            : this(serializationHelper, fileSystemHelper, rootDirectory: ConfigurationManager.AppSettings["ContentRoot"])
        {
        }

        public TemplateRepository(SerializationHelper serializationHelper, FileSystemHelper fileSystemHelper, string rootDirectory)
        {
            this.serializationHelper = serializationHelper;
            this.fileSystemHelper = fileSystemHelper;
            this.rootDirectory = rootDirectory;
        }

        public void Add(Template template)
        {
            var surrogate = new TemplateSurrogateBuilder().Build(template);
            var directoryPath = this.fileSystemHelper.CombinePaths(this.rootDirectory, template.Path.ToFileSystemPath());

            if (!this.fileSystemHelper.DirectoryExists(directoryPath))
            {
                this.fileSystemHelper.CreateDirectory(directoryPath);
            }

            var path = this.fileSystemHelper.CombinePaths(directoryPath, TemplateFileName);
            this.serializationHelper.Serialize<TemplateSurrogate>(surrogate, path);
        }

        public Template Get(IEnumerable<string> templatePath)
        {
            var path = this.fileSystemHelper.CombinePaths(this.rootDirectory, templatePath.ToFileSystemPath(), TemplateFileName);

            if (!this.fileSystemHelper.FileExists(path))
            {
                return null;
            }

            var surrogate = this.serializationHelper.Deserialize<TemplateSurrogate>(path);
            return new TemplateDomainBuilder(templatePath).Build(surrogate);
        }

        public void Update(Template template)
        {
            var surrogate = new TemplateSurrogateBuilder().Build(template);
            var path = this.fileSystemHelper.CombinePaths(this.rootDirectory, template.Path.ToFileSystemPath(), TemplateFileName);
            this.serializationHelper.Serialize<TemplateSurrogate>(surrogate, path);
        }
    }
}