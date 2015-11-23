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

        public SourceLookupResponse Lookup(string value, IEnumerable<IContextItem> context)
        {
            var candidates = this.musicService.FindArtists(a => a.Name.Urlify() == value).ToArray();

            return candidates.Any() 
                ? new SourceLookupResponse(true, new[] { new ContextItem("artist-id", candidates.First().Id) }) 
                : new SourceLookupResponse(false);
        }
    }
}