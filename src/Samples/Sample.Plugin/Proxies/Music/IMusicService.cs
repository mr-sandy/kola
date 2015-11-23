namespace Sample.Plugin.Proxies.Music
{
    using System;
    using System.Collections.Generic;

    public interface IMusicService
    {
        Artist GetArtist(string artistId);

        Album GetAlbum(string albumId);

        IEnumerable<Artist> FindArtists(Func<Artist, bool> predicate);

        IEnumerable<Album> FindAlbums(Func<Album, bool> predicate);
    }
}