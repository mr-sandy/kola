namespace Sample.Plugin
{
    using Kola.Configuration.Plugins;
    using Kola.Domain.Rendering;

    using Sample.Plugin.ContextProviders;
    using Sample.Plugin.Proxies.Countries;
    using Sample.Plugin.Proxies.Music;
    using Sample.Plugin.Renderers;
    using Sample.Plugin.Sources;

    public class Configuration : PluginConfiguration
    {
        public Configuration()
            : base("Sample")
        {
            this.Configure.ViewLocation("Sample.Plugin.Views");

            this.ConfigureAtoms();

            this.ConfigureContainers();

            this.ConfigureSources();

            this.Configure.ContextProvider<CountryProvider>();
        }

        public override void ConfigureContainer(IContainer container)
        {
            var accessToken = container.Resolve<string>("access_token");
            container.Register<IMusicService>(new CachingMusicService(new MusicService(accessToken)));
            container.Register<ICountriesService, CountriesService>();
        }

        private void ConfigureAtoms()
        {
            this.Configure.Atom("artist")
                .WithCategory("music")
                .WithRenderer<ArtistRenderer>()
                .WithProperty("artist-id", "text");

            this.Configure.Atom("artist-image")
                .WithCategory("music")
                .WithRenderer<ArtistRenderer>()
                .WithProperty("artist-id", "text");

            this.Configure.Atom("album")
                .WithCategory("music")
                .WithRenderer<AlbumRenderer>()
                .WithProperty("album-id", "text");

            this.Configure.Atom("album-art")
                .WithCategory("music")
                .WithRenderer<AlbumRenderer>()
                .WithProperty("album-id", "text");
        }

        private void ConfigureContainers()
        {
            this.Configure.Container("div")
                .WithCategory("core")
                .WithView("Div")
                .WithProperty("classes", "text");
        }

        private void ConfigureSources()
        {
            this.Configure.Source<AlbumNameSource>();
            this.Configure.Source<ArtistNameSource>();
        }
    }
}
