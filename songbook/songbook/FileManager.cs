using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace songbook
{
    public static class FileManager
    {
        private static List<Song> songs;
        static IEnumerable<Song> Songs
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

        private static async void InitializeSongs()
        {
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes("1234567");

            StorageFolder local = ApplicationData.Current.LocalFolder;
            var dataFolder = await local.CreateFolderAsync("DataFolder", CreationCollisionOption.OpenIfExists);

            var file = await dataFolder.CreateFileAsync("DataFile.txt", CreationCollisionOption.ReplaceExisting);

            using (var s = await file.OpenStreamForWriteAsync())
            {
                s.Write(fileBytes, 0, fileBytes.Length);
            }
        }
    }
}
