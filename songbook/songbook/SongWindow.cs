using Windows.UI.Xaml.Controls;

namespace songbook
{
    class SongWindow
    {
        private SearchBar searchBar;
        private TextBox textControl;
        public SongWindow(TextBox textControl, SearchBar searchBar)
        {
            this.textControl = textControl;
            this.searchBar = searchBar;
        }

        private void ShowSong(Song song)
        {
            textControl.Text = song.Text;
        }
    }
}
