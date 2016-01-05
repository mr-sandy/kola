namespace Kola.Persistence
{
    using System.IO;
    using System.Linq;

    using Kola.Domain.Instances.Config;
    using Kola.Persistence.Surrogates;

    public class ConfigurationRepository : IConfigurationRepository
    {
        private const string ConfigurationFileName = "Config.xml";

        private readonly IFileSystemHelper fileSystemHelper;
        private readonly ISerializationHelper serializationHelper;

        public ConfigurationRepository(IFileSystemHelper fileSystemHelper, ISerializationHelper serializationHelper)
        {
            this.fileSystemHelper = fileSystemHelper;
            this.serializationHelper = serializationHelper;
        }

        public IConfiguration Get(string path)
        {
            var filePath = Path.Combine(path, ConfigurationFileName);

            if (this.fileSystemHelper.FileExists(filePath))
            {
                var surrogate = this.serializationHelper.Deserialize<ConfigurationSurrogate>(filePath);
                return new Configuration
                           {
                               ContextItems = surrogate.ContextItems.Select(i => new ContextItem(i.Name, i.Value)).ToArray()
                           };
            }

            return new Configuration();
        }
    }
}