namespace Kola.Nancy
{
    using Kola.Configuration;

    public class NancyKolaConfigurationRegistry : IKolaConfigurationRegistry
    {
        public static KolaConfiguration Instance { get; set; }

        public KolaConfiguration KolaConfiguration
        {
            get { return Instance; }
        }
    }
}