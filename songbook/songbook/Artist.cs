using System.Collections.Generic;
using System.Linq;

namespace songbook
{
    public class Artist : MusicItem
    {
        public static List<Artist> Artists = new List<Artist>();
        public readonly string Name;
        public readonly string PathToIcon;
        public string ScreenName
        {
            get
            {
                return Name;
            }
        }
        public string IconPath
        {
            get
            {
                return PathToIcon;
            }
        }
        private Artist(string name, Song firstSong)
        {
            PathToIcon = "Assets/artist.png";
            Name = name;
            Artists.Add(this);
        }
        public Artist(string name) //for bd constructor
        {
            PathToIcon = "Assets/artist.png";
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
            Artist result;
            if (Artists.Exists(a => a.Name == name))
            {
                result = Artists.First(a => a.Name == name);
            }
            else
            {
                result = new Artist(name, song);
            }
            result.SongsOfArtist.Add(song);
            return result;
        }
    }
}
