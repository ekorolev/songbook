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
        public const string NameTableAtists = "Atists";

        private SQLiteConnection connectionToDB;
        public FileManagerSQLite(string dbname)
        {
            this.connectionToDB = new SQLiteConnection(dbname);
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
        public List<MusicItem> GetAtists()
        {
            List<MusicItem> atists = new List<MusicItem>();
            string sqlreq = "SELECT * FROM " + NameTableAtists + ";";
            using (var statement = connectionToDB.Prepare(sqlreq))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    atists.Add(new Artist((string)statement[1]));
                }
            }
            return atists;
        }
        public MusicItem getSong(int id)
        {
            Song song = null;
            string sqlreq = "SELECT * FROM" + NameTableSongs + "WHERE ID =?";
            using (var statement = connectionToDB.Prepare(sqlreq))
            {
                statement.Bind(1, id);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    song = new Song((string)statement[1]);
                }
            }
            checkFound(song);
            return song;
        }
        public MusicItem getArtist(int id)
        {
            Artist artist = null;
            string sqlreq = "SELECT * FROM" + NameTableAtists + "WHERE ID =?";
            using (var statement = connectionToDB.Prepare(sqlreq))
            {
                statement.Bind(1, id);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    artist = new Artist((string)statement[1]);
                }
            }
            checkFound(artist);
            return artist;
        }       
        private void checkFound(MusicItem musicItem)
        {
            if (musicItem == null) throw new Exception("Can not find music item in sqlBase.");
        }
    }
}
