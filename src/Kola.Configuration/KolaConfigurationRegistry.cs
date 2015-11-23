namespace Kola.Configuration
{
    public class KolaConfigurationRegistry : IKolaConfigurationRegistry
    {
        public static KolaConfiguration Instance { get; private set; }

        public KolaConfiguration KolaConfiguration => Instance;

        public static void Register(KolaConfiguration kolaConfiguration)
        {
            Instance = kolaConfiguration;
        }
    }
}