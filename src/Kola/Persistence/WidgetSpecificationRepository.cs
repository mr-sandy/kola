namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.Specifications;
    using Kola.Persistence.DomainBuilders;
    using Kola.Persistence.Surrogates;

    public class WidgetSpecificationRepository : IWidgetSpecificationRepository
    {
        private const string RootDirectory = @"C:\projects\kola\src\Kola\Persistence\Widgets";

        private readonly SerializationHelper serializationHelper;
        private readonly FileSystemHelper fileSystemHelper;

        public WidgetSpecificationRepository(SerializationHelper serializationHelper, FileSystemHelper fileSystemHelper)
        {
            this.serializationHelper = serializationHelper;
            this.fileSystemHelper = fileSystemHelper;
        }

        public WidgetSpecification Find(string name)
        {
            var path = this.fileSystemHelper.CombinePaths(RootDirectory, name + ".xml");

            if (this.fileSystemHelper.FileExists(path))
            {
                var surrogate = this.serializationHelper.Deserialize<WidgetSpecificationSurrogate>(path);

                return new WidgetSpecificationDomainBuilder(name).Build(surrogate);
            }

            return null;
        }

        public IEnumerable<WidgetSpecification> FindAll()
        {
            return this.fileSystemHelper
                .GetFiles(RootDirectory)
                .Select(f => this.Find(f.Replace(".xml", string.Empty)));
        }

        public void Add(WidgetSpecification widgetSpecification)
        {
            throw new NotImplementedException();

            //var surrogate = widgetSpecification.ToSurrogate();
            //var directoryPath = this.fileSystemHelper.CombinePaths(RootDirectory, widgetSpecification.Path.ToFileSystemPath());

            //if (!this.fileSystemHelper.DirectoryExists(directoryPath))
            //{
            //    this.fileSystemHelper.CreateDirectory(directoryPath);
            //}

            //var path = this.fileSystemHelper.CombinePaths(directoryPath, TemplateFileName);
            //this.serializationHelper.Serialize<TemplateSurrogate>(surrogate, path);
        }
    }
}