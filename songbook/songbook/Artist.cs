using System.Collections.Generic;
using System.Linq;

namespace songbook
{
    class Artist
    {
        public static List<Artist> Artists = new List<Artist>();

        public readonly string Name;
        private Artist(string name, Song firstSong)
        {
            Name = name;
            Artists.Add(this);
            SongsOfArtist.Add(firstSong);
        }

        public List<Song> SongsOfArtist = new List<Song>(); 

        public Artist GetOrAddArtist(string name, Song song)
        {
            if (Artists.Exists(a => a.Name == name))
            {
                return Artists.First(a => a.Name == name);
            }
            return new Artist(name, song);
        }
    }
}
