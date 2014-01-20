namespace Kola.Persistence
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain;
    using Kola.Domain.Specifications;
    using Kola.Persistence.Extensions;
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
                return surrogate.ToDomain(name);
            }

            return null;
        }

        public IEnumerable<WidgetSpecification> FindAll()
        {
            return this.fileSystemHelper
                .GetFiles(RootDirectory)
                .Select(f => this.Find(f.Replace(".xml", string.Empty)));
        }
    }
}