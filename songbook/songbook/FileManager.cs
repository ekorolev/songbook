using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;

namespace songbook
{
    static class FileManager
    {
        private static List<Song> songs;
        private static ResourceLoader resourse = new ResourceLoader();

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

        public static List<Artist> Artists
        {
            get
            {
                return Artist.Artists;
            }
        }

        private static void InitializeSongs()
        {
            songs = new List<Song>();
            var songNames = resourse.GetString("AllSongs").Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var songName in songNames)
            {
                songs.Add(new Song(songName));
            }
        }

        public static string GetTextOfSong(Song song)
        {
            return resourse.GetString(song.FullName);
        }
    }
}
