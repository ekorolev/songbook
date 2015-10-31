using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using System.Collections.ObjectModel;
namespace songbook
{
    class FileManagerSQLite
    {
        public const string NameTableSongs = "Songs";
        public const string NameTableAuthors = "Authors";

        private SQLiteConnection connectionToDB;
        public FileManagerSQLite(string dbname)
        {
            this.connectionToDB = new SQLiteConnection(dbname);
            CreateSongsTable();
            CreateArtistsTable();
        }
        private void CreateSongsTable()
        {
            string sqlreq = "CREATE TABLE " + NameTableSongs +
                                @" (    Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
                                        Name VARCHAR(100),
                                        Author VARCHAR(100),
                                        PathToText VARCHAR(100)
                                        );";
            using (var statement = connectionToDB.Prepare(sqlreq))
            {
                statement.Step();
            }
        }
        private void CreateArtistsTable()
        {
            string sqlreq = "CREATE TABLE" + NameTableAuthors +
                                @"      (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
                                        Name VARCHAR(100)
                                        );";
            using (var statement = connectionToDB.Prepare(sqlreq))
            {
                statement.Step();
            }
        }
        public List<MusicItem> GetSongs()
        {
            List<MusicItem> songs = new List<MusicItem>();
            string sqlreq = "SELECT * FROM " + NameTableSongs + ";";
            using (var statement = connectionToDB.Prepare(sqlreq))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    songs.Add(new Song((string)statement[1]));
                }
            }
            return songs;
        }
        public List<MusicItem> GetAuthors()
        {
            List<MusicItem> authors = new List<MusicItem>();
            string sqlreq = "SELECT * FROM " + NameTableAuthors + ";";
            using (var statement = connectionToDB.Prepare(sqlreq))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    authors.Add(new Artist((string)statement[1]));
                }
            }
            return authors;
        }
    }
}
