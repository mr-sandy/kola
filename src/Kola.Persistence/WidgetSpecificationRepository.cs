namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;

    using Kola.Domain.Specifications;
    using Kola.Persistence.DomainBuilding;
    using Kola.Persistence.Surrogates;

    public class WidgetSpecificationRepository : IWidgetSpecificationRepository
    {
        private readonly SerializationHelper serializationHelper;
        private readonly IFileSystemHelper fileSystemHelper;

        private readonly string widgetsDirectory;

        public WidgetSpecificationRepository(SerializationHelper serializationHelper, IFileSystemHelper fileSystemHelper)
            : this(serializationHelper, fileSystemHelper, rootDirectory: ConfigurationManager.AppSettings["ContentRoot"])
        {
        }

        public WidgetSpecificationRepository(SerializationHelper serializationHelper, IFileSystemHelper fileSystemHelper, string rootDirectory)
        {
            this.serializationHelper = serializationHelper;
            this.fileSystemHelper = fileSystemHelper;
            this.widgetsDirectory = Path.Combine(rootDirectory, "Widgets");
        }

        public WidgetSpecification Find(string name)
        {
            var path = Path.Combine(this.widgetsDirectory, name + ".xml");

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
                .GetFiles(this.widgetsDirectory)
                .Select(f => this.Find(f.Replace(".xml", string.Empty)));
        }

        public void Add(WidgetSpecification widgetSpecification)
        {
            throw new NotImplementedException();

            //var surrogate = widgetSpecification.ToSurrogate();
            //var directoryPath = Path.Combine(RootDirectory, widgetSpecification.Path.ToFileSystemPath());

            //if (!this.fileSystemHelper.DirectoryExists(directoryPath))
            //{
            //    this.fileSystemHelper.CreateDirectory(directoryPath);
            //}

            //var path = Path.Combine(directoryPath, TemplateFileName);
            //this.serializationHelper.Serialize<TemplateSurrogate>(surrogate, path);
        }
    }
}