namespace Kola.Configuration
{
    public class CacheConfiguration
    {
        private readonly ComponentDeclaration atomConfiguration;

        public CacheConfiguration(ComponentDeclaration atomConfiguration)
        {
            this.atomConfiguration = atomConfiguration;
        }

        public CacheConfiguration PerUser
        {
            get
            {
                return this;
            }
        }

        public CacheConfiguration For(int seconds)
        {
            return this;
        }
    }
}