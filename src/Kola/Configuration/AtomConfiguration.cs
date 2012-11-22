
namespace Kola.Configuration
{
    internal class AtomConfiguration : ComponentConfiguration
    {
        public AtomConfiguration(string atomName)
        {
            this.AtomName = atomName;
        }

        public string AtomName { get; private set; }

        public CacheType CacheType { get; set; }

        public int CacheDuration { get; set; }
    }
}
