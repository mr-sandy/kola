namespace Sample.Plugin.Renderers
{
    using System.Linq;

    using Kola.Domain.Instances;
    using Kola.Domain.Rendering;

    using Sample.Plugin.Proxies.Music;

    public class AlbumRenderer : IRenderer<AtomInstance>
    {
        private readonly IMusicService musicService;

        public AlbumRenderer(IMusicService musicService)
        {
            this.musicService = musicService;
        }

        public IResult Render(AtomInstance component)
        {
            var albumIdProperty = component.Properties.SingleOrDefault(p => p.Name == "album-id");

            if (albumIdProperty == null)
            {
                return new Result(h => "");
            }

            var album = this.musicService.GetAlbum(albumIdProperty.Value);

            switch (component.Name)
            {
                case "album-art":
                    return new Result(h => h.RenderPartial("AlbumArt", album));

                default:
                    return new Result(h => h.RenderPartial("Album", album));
            }
        }
    }
}