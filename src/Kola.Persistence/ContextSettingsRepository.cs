namespace Kola.Persistence
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Kola.Domain.Instances.Context;
    using Kola.Persistence.Extensions;
    using Kola.Persistence.Surrogates;

    public class ContextSettingsRepository : IContextSettingsRepository
    {
        private const string ContextSettingsFileName = "Context.xml";
        private const string TemplatesDirectory = "Templates";

        private readonly IFileSystemHelper fileSystemHelper;
        private readonly ISerializationHelper serializationHelper;

        public ContextSettingsRepository(IFileSystemHelper fileSystemHelper, ISerializationHelper serializationHelper)
        {
            this.fileSystemHelper = fileSystemHelper;
            this.serializationHelper = serializationHelper;
        }

        public IEnumerable<IContextItem> Get(IEnumerable<string> path)
        {
            var filePath = Path.Combine(TemplatesDirectory, path.Append(ContextSettingsFileName).ToFileSystemPath());

            if (this.fileSystemHelper.FileExists(filePath))
            {
                var surrogate = this.serializationHelper.Deserialize<ContextSettingsSurrogate>(filePath);
                return surrogate.ContextItems.Select(i => new ContextItem(i.Name, i.Value));
            }

            return Enumerable.Empty<ContextItem>();
        }
        public IEnumerable<IContextItem> Get(string path)
        {
            var filePath = Path.Combine(path, ContextSettingsFileName);

            if (this.fileSystemHelper.FileExists(filePath))
            {
                var surrogate = this.serializationHelper.Deserialize<ContextSettingsSurrogate>(filePath);
                return surrogate.ContextItems.Select(i => new ContextItem(i.Name, i.Value));
            }

            return Enumerable.Empty<ContextItem>();
        }
    }
}