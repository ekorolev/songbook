using System.Collections.Generic;
using System.Linq;

namespace songbook
{
    public class Artist : MusicItem
    {
        public static List<Artist> Artists = new List<Artist>();
        public readonly string Name;
        public string ScreenName { get{
            return Name;
        }
        }
        private Artist(string name, Song firstSong)
        {
            Name = name;
            Artists.Add(this);
        }

        public List<Song> SongsOfArtist = new List<Song>();
        public override string ToString()
        {
            return ScreenName;
        }
        public static Artist GetOrAddArtist(string name, Song song)
        {
            if (Artists.Exists(a => a.Name == name))
            {
                return Artists.First(a => a.Name == name);
            }
            var result = new Artist(name, song);
            result.SongsOfArtist.Add(song);
            return result;
        }
    }
}
