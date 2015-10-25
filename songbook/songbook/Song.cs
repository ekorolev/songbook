using System;
using System.Linq;

namespace songbook
{
    public class Song : MusicItem
    {
        public readonly string FullName;
        public readonly string SongName;
        public readonly Artist Artist;
        public string ScreenName
        {
            get
            { 
                return FullName;
            }
        }

        private string _text;
        public string Text
        {
            get
            {
                if (_text == null)
                {
                    _text = FileManager.GetTextOfSong(this);
                }
                return _text;
            }
        }
        public override string ToString()
        {
            return ScreenName;
        }
        public Song(string name)
        {
            if (name == null)
                name = String.Empty;
            FullName = name;
            var values = name.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
            SongName = values[1];
            Artist = Artist.GetOrAddArtist(values[0], this);
        }
    }
}
