using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;

namespace songbook
{
    static class FileManager
    {
        private static List<Song> songs;
        public static IEnumerable<Song> Songs
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
