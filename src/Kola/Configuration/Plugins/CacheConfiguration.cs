
namespace Kola.Configuration.Plugins
{
    public class CacheConfiguration
    {
        public CacheConfiguration PerUser
        {
            get { return this; }
        }

        public CacheConfiguration For(int seconds)
        {
            return this;
        }
    }
}