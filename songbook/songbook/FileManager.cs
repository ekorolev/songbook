using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;

namespace songbook
{
    static class FileManager
    {
        private static List<Song> songs;
        public static List<Song> Songs
        {
            get
            {
                if (songs == null)
                {
                    InitializeSongs();
                }
                return songs;
            }
        }

        public static List<Artist> Artists => Artist.Artists;

        private static void InitializeSongs()
        {
            songs = new List<Song>();
            ResourceLoader resourse = new ResourceLoader();
            var songNames = resourse.GetString("AllSongs").Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var songName in songNames)
            {
                songs.Add(new Song(songName));
            }
        }
    }
}
