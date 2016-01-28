namespace Sample.Plugin
{
    using System.Security.Cryptography.X509Certificates;

    using Kola.Configuration.Plugins;
    using Kola.Domain.Rendering;

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
        }

        public override void ConfigureRequestFactory(IObjectFactory factory)
        {
            factory.Register<IMusicService>(new CachingMusicService(new MusicService())); 
        }

        public override void ConfigureApplicationFactory(IObjectFactory factory)
        {
            factory.Register<IMusicService>(new CachingMusicService(new MusicService()));
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
