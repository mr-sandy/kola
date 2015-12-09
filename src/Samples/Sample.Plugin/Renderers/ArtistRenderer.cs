namespace Sample.Plugin.Renderers
{
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    using Sample.Plugin.Proxies.Music;

    public class ArtistRenderer : IRenderer<AtomInstance>
    {
        private readonly IMusicService musicService;

        public ArtistRenderer(IMusicService musicService)
        {
            this.musicService = musicService;
        }

        public IResult Render(AtomInstance component)
        {
            var artistIdProperty = component.Properties.SingleOrDefault(p => p.Name == "artist-id");

            if (artistIdProperty == null)
            {
                return new Result(h => "");
            }

            var artist = this.musicService.GetArtist(artistIdProperty.Value);

            switch (component.Name)
            {
                case "artist-image":
                    return new Result(h => h.RenderPartial("ArtistImage", artist));

                default:
                    return new Result(h => h.RenderPartial("Artist", artist));
            }
        }
    }
}
