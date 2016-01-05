namespace Sample.Plugin.Sources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Kola.Domain.DynamicSources;
    using Kola.Domain.Instances.Config;

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

        public DynamicItem Lookup(string value, IEnumerable<IContextItem> context)
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
                        return new DynamicItem(value, new[] { new ContextItem("album-id", firstMatch.Id) });
                    }
                }
                else
                {
                    var album = candidates.First();
                    return new DynamicItem(value, new[] { new ContextItem("album-id", album.Id) });
                }
            }

            return null;
        }

        public IEnumerable<DynamicItem> GetAllItems(IEnumerable<IContextItem> context)
        {
            var artistIdContext = context.FirstOrDefault(c => c.Name == "artist-id");

            return artistIdContext == null 
                ? this.musicService.FindAlbums(a => true).Select(this.BuildItem) 
                : this.musicService.FindAlbums(a => a.ArtistId == artistIdContext.Value).Select(this.BuildItem);
        }

        private DynamicItem BuildItem(Album album)
        {
            return new DynamicItem(album.Name.Urlify(), new[] { new ContextItem("album-id", album.Id) });
        }
    }
}
