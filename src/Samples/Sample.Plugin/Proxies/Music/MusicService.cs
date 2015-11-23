namespace Sample.Plugin.Proxies.Music
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MusicService : IMusicService
    {
        private static readonly Artist TheBeatles = new Artist { Id = "1", Name = "The Beatles" };
        private static readonly Artist TheBeachBoys = new Artist { Id = "2", Name = "The beach Boys" };

        private static readonly Album Revolver = new Album { Id = "11", Name = "Revolver", ArtistId = TheBeatles.Id };
        private static readonly Album PetSounds = new Album { Id = "12", Name = "Pet Sounds", ArtistId = TheBeachBoys.Id };

        private static readonly IEnumerable<Artist> Artists = new[] { TheBeatles, TheBeachBoys };
        private static readonly IEnumerable<Album> Albums = new[] { Revolver, PetSounds };


        public Artist GetArtist(string artistId)
        {
            return Artists.FirstOrDefault(a => a.Id == artistId);
        }

        public Album GetAlbum(string albumId)
        {
            return Albums.FirstOrDefault(a => a.Id == albumId);
        }

        public IEnumerable<Artist> FindArtists(Func<Artist, bool> predicate)
        {
            return Artists.Where(predicate);
        }

        public IEnumerable<Album> FindAlbums(Func<Album, bool> predicate)
        {
            return Albums.Where(predicate);
        }
    }
}
