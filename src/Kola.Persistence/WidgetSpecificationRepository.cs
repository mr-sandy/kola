namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Kola.Domain.Specifications;
    using Kola.Persistence.DomainBuilding;
    using Kola.Persistence.SurrogateBuilding;
    using Kola.Persistence.Surrogates;

    public class WidgetSpecificationRepository : IWidgetSpecificationRepository
    {
        private readonly ISerializationHelper serializationHelper;
        private readonly IFileSystemHelper fileSystemHelper;

        private const string WidgetsDirectory = "Widgets";

        public WidgetSpecificationRepository(ISerializationHelper serializationHelper, IFileSystemHelper fileSystemHelper)
        {
            this.serializationHelper = serializationHelper;
            this.fileSystemHelper = fileSystemHelper;
        }

        public WidgetSpecification Find(string name)
        {
            var path = Path.Combine(WidgetsDirectory, name + ".xml");

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
                .GetFiles(WidgetsDirectory)
                .Select(f => this.Find(f.Replace(".xml", string.Empty)));
        }

        public void Save(WidgetSpecification widgetSpecification)
        {
            var surrogate = new WidgetSpecificationSurrogateBuilder().Build(widgetSpecification);
            var path = Path.Combine(WidgetsDirectory, widgetSpecification.Name + ".xml");

            this.serializationHelper.Serialize<WidgetSpecificationSurrogate>(surrogate, path);
        }
    }
}