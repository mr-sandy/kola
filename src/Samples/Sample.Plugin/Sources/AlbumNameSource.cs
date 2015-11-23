namespace Sample.Plugin.Sources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Context;

    using Sample.Plugin.Extensions;
    using Sample.Plugin.Proxies.Music;

    public class AlbumNameSource : IDynamicSource
    {
        private readonly IMusicService musicService;

        public AlbumNameSource(IMusicService musicService)
        {
            this.musicService = musicService;
        }

        public string Name => "-album-name-";

        public SourceLookupResponse Lookup(string value, IEnumerable<IContextItem> context)
        {
            var candidates = this.musicService.FindAlbums(a => a.Name.Urlify() == value).ToArray();

            if (candidates.Any())
            {
                var artistIdContext = context.FirstOrDefault(c => c.Name == "artist-id");

                if (artistIdContext != null)
                {
                    var firstMatch = candidates.FirstOrDefault(a => a.ArtistId == artistIdContext.Value);

                    if (firstMatch != null)
                    {
                        return new SourceLookupResponse(true, new[] { new ContextItem("album-id", firstMatch.Id) });
                    }
                }
                else
                {
                    return new SourceLookupResponse(true, new[] { new ContextItem("album-id", candidates.First().Id) });
                }
            }

            return new SourceLookupResponse(false);
        }
    }
}
