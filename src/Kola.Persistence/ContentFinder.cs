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
        private readonly ISerializationHelper serializationHelper;

        private const string TemplateFilename = "Template.xml";

        private readonly string root;

        public ContentFinder(IFileSystemHelper fileSystemHelper, ISerializationHelper serializationHelper, string root)
        {
            this.fileSystemHelper = fileSystemHelper;
            this.serializationHelper = serializationHelper;
            this.root = root;
        }

        public IContent Find(IEnumerable<string> path)
        {
            return this.FindContent(path, this.root);
        }

        private IContent FindContent(IEnumerable<string> contentPath, string fileSystemPath)
        {
            if (contentPath.Any())
            {
                throw new NotImplementedException();
            }

            var templatePath = this.CombinePaths(fileSystemPath, TemplateFilename);

            if (this.fileSystemHelper.FileExists(templatePath))
            {
                return this.serializationHelper.Deserialize<Template>(templatePath);
            }

            return null;
        }

        private string CombinePaths(params string [] paths)
        {
            return Path.Combine(paths.ToArray());
        }
    }
}