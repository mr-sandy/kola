namespace Sample.Plugin.Proxies.Music
{
    using System;
    using System.Collections.Generic;

    public class CachingMusicService : IMusicService
    {
        private readonly IMusicService inner;

        public CachingMusicService(IMusicService inner)
        {
            this.inner = inner;
        }

        public Artist GetArtist(string artistId)
        {
            return this.inner.GetArtist(artistId);
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