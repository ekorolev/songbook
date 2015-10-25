using System.Xml.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace songbook
{
    public class SongWindow
    {
        private SearchBar searchBar;
        private SongTextControl textControl;
        private MusicItemsViewer musicItemViewer;
        public SongWindow(SongTextControl textControl, SearchBar searchBar, MusicItemsViewer musicItemViewer)
        {
            this.musicItemViewer = musicItemViewer;
            this.textControl = textControl;
            this.searchBar = searchBar;
            this.searchBar.SelectionChanged += ShowSong;
            this.musicItemViewer.MusicItemClick += ShowSong;
        }
        public void ShowSong(Song song)
        {
            textControl.ClearText();
            XDocument doc = XDocument.Parse(song.Text);
            foreach (XElement xElm in doc.Root.Descendants("string"))
            {
                var s = xElm.Value;
                string extraS = (string)xElm.Attribute("accord");
                textControl.AddLine(s, extraS);
            }
        }

    }
}
