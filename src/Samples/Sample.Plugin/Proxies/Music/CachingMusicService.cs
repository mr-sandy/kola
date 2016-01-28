namespace Sample.Plugin.Proxies.Music
{
    using System;
    using System.Collections.Generic;

    public class CachingMusicService : IMusicService
    {
        private readonly IMusicService inner;
        private readonly Dictionary<string, Artist> artistCache = new Dictionary<string, Artist>();

        private readonly Guid instance;

        public CachingMusicService(IMusicService inner)
        {
            this.inner = inner;
            this.instance = Guid.NewGuid();
        }

        public Artist GetArtist(string artistId)
        {
            if (!this.artistCache.ContainsKey(artistId))
            {
                this.artistCache.Add(artistId, this.inner.GetArtist(artistId));    
            }
            return this.artistCache[artistId];
        }

        public Album GetAlbum(string albumId)
        {
            return this.inner.GetAlbum(albumId);
        }

        public IEnumerable<Artist> FindArtists(Func<Artist, bool> predicate)
        {
            return this.inner.FindArtists(predicate);
        }

        public IEnumerable<Album> FindAlbums(Func<Album, bool> predicate)
        {
            return this.inner.FindAlbums(predicate);
        }
    }
}