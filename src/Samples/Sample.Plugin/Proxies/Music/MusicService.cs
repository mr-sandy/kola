namespace Sample.Plugin.Proxies.Music
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MusicService : IMusicService
    {
        private static readonly Artist TheBeatles = new Artist { Id = "1", Name = "The Beatles", ImageUrl = "http://www.capitolrecords.com/files/2015/12/the-beatles.jpg" };
        private static readonly Artist TheBeachBoys = new Artist { Id = "2", Name = "The Beach Boys", ImageUrl = "http://images6.fanpop.com/image/photos/32400000/The-Beach-Boys-the-beach-boys-32469096-500-277.jpg" };

        private static readonly Album Revolver = new Album { Id = "11", Name = "Revolver", ArtistId = TheBeatles.Id, ImageUrl = "http://images2.houstonpress.com/imager/u/original/6499742/beatles_revolver_aug5.jpg" };
        private static readonly Album BeatlesForSale = new Album { Id = "12", Name = "Beatles For Sale", ArtistId = TheBeatles.Id, ImageUrl = "http://thecaptainsmemos.com/wp-content/uploads/2009/10/beatles_for_sale.jpg" };
        private static readonly Album PetSounds = new Album { Id = "13", Name = "Pet Sounds", ArtistId = TheBeachBoys.Id, ImageUrl = "http://media.bonnint.net/la/0/52/5228.jpg" };
        private static readonly Album Smile = new Album { Id = "14", Name = "Smile", ArtistId = TheBeachBoys.Id, ImageUrl = "http://www.bilborecords.be/sites/default/files/styles/large/public/Beach%20Boys%20-%20Smile%20Sessions_1.jpg?itok=jmDadcMY" };

        private static readonly IEnumerable<Artist> Artists = new[] { TheBeatles, TheBeachBoys };
        private static readonly IEnumerable<Album> Albums = new[] { Revolver, BeatlesForSale, PetSounds, Smile };

        private readonly string accessToken;

        public MusicService(string accessToken)
        {
            this.accessToken = accessToken;
        }

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
