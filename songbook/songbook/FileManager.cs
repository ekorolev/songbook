using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.Storage;

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

        private static async void InitializeSongs()
        {
            ResourceLoader rl = new ResourceLoader();
            var t = rl.GetString("TestString");
            //string s = AppResources.NameOfResource
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes("1234567");

            StorageFolder local = ApplicationData.Current.LocalFolder;
            var dataFolder = await local.CreateFolderAsync("DataFolder", CreationCollisionOption.OpenIfExists);

            var assembly = typeof(FileManager).GetTypeInfo().Assembly;

            // Use this help aid to figure out what the actual manifest resource name is.
            string[] resources = assembly.GetManifestResourceNames();

            // Once you figure out the name, pass it in as the argument here.
            Stream stream = assembly.GetManifestResourceStream("1.XML");
            while (stream.CanRead)
            {
                var t1 = 1;
            }

            var file = await dataFolder.CreateFileAsync("DataFile.txt", CreationCollisionOption.ReplaceExisting);

            using (var s = await file.OpenStreamForWriteAsync())
            {
                s.Write(fileBytes, 0, fileBytes.Length);
            }
        }
    }
}
