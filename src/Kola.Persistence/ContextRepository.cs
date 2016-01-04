namespace Kola.Persistence
{
    using System.IO;
    using System.Linq;

    using Kola.Domain.Instances.Context;
    using Kola.Persistence.Surrogates;

    public class ContextRepository : IContextRepository
    {
        private const string ContextSettingsFileName = "Context.xml";
        private const string TemplatesDirectory = "Templates";

        private readonly IFileSystemHelper fileSystemHelper;
        private readonly ISerializationHelper serializationHelper;

        public ContextRepository(IFileSystemHelper fileSystemHelper, ISerializationHelper serializationHelper)
        {
            this.fileSystemHelper = fileSystemHelper;
            this.serializationHelper = serializationHelper;
        }

        public IContext Get(string path)
        {
            var filePath = Path.Combine(path, ContextSettingsFileName);

            if (this.fileSystemHelper.FileExists(filePath))
            {
                var surrogate = this.serializationHelper.Deserialize<ContextSettingsSurrogate>(filePath);
                return new Context
                           {
                               ContextItems = surrogate.ContextItems.Select(i => new ContextItem(i.Name, i.Value)).ToArray()
                           };
            }

            return new Context();
        }
    }
}