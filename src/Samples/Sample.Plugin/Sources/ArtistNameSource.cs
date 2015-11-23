namespace Sample.Plugin.Sources
{
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Context;

    using Sample.Plugin.Extensions;
    using Sample.Plugin.Proxies.Music;

    public class ArtistNameSource : IDynamicSource
    {
        private readonly IMusicService musicService;

        public ArtistNameSource(IMusicService musicService)
        {
            this.musicService = musicService;
        }

        public string Name => "-artist-name-";

        public DynamicItem Lookup(string value, IEnumerable<IContextItem> context)
        {
            var candidates = this.musicService.FindArtists(a => a.Name.Urlify() == value).ToArray();

            return candidates.Any() 
                ? this.BuildItem(candidates.First()) 
                : null;
        }

        public IEnumerable<DynamicItem> GetAllItems(IEnumerable<IContextItem> context)
        {
            return this.musicService.FindArtists(a => true).Select(this.BuildItem);
        }

        private DynamicItem BuildItem(Artist artist)
        {
            return new DynamicItem(artist.Name.Urlify(), new [] { new ContextItem("artist-id", artist.Id) });
        }
    }
}