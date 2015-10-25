using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace songbook
{
    public class ArtistOrSong
    {
        public string Name;
        public byte Difference;
        public Song sourceSong;
        public ArtistOrSong(string _name, byte _difference, Song _sourceSong)
        {
            Name = _name;
            Difference = _difference;
            sourceSong = _sourceSong;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class SearchBar
    {

        private TextBox searchControl;
        private ListBox resultSearchControl;
        private SongTextControl songTextControl;
        private ListBox listArtistsControl;
        public delegate void SelectionChangedEventHandler(Song song);       
        public event SelectionChangedEventHandler SelectionChanged;

        public delegate void ArtistSelectionChangedEventHandler(Artist artist);
        public event ArtistSelectionChangedEventHandler ArtistChanged;

        public SearchBar(TextBox searchControl, ListBox resultSearchControl, SongTextControl songTextControl, ListBox listArtistsControl)
        {
            this.searchControl = searchControl;
            this.resultSearchControl = resultSearchControl;
            this.songTextControl = songTextControl;
            this.listArtistsControl = listArtistsControl;
            searchControl.TextChanged += searchControl_TextChanged;
            resultSearchControl.SelectionChanged += ResultSearchControl_SelectionChanged;
        }
        private void ResultSearchControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((MusicItem)((ListBox)sender).SelectedItem);
            if (selectedItem == null)
            {
                return;
            }
            AppStates.SaveState(songTextControl, listArtistsControl);
            if (selectedItem is Song)
            {               
                SelectionChanged((Song)selectedItem);
                resultSearchControl.Visibility = Visibility.Collapsed;                
            }
            
            if (selectedItem is Artist)
            {               
                resultSearchControl.Visibility = Visibility.Collapsed;   
                ArtistChanged((Artist)selectedItem);                
            }
            
        }
        private void searchControl_TextChanged(object sender, TextChangedEventArgs e)
        {            
            SearchAction(((TextBox)sender).Text);
        }

        public void SearchAction(string StringToSearch)
        {
            if (StringToSearch.Length == 0)
            {
                resultSearchControl.Visibility = Visibility.Collapsed;
                return;
            }
            ObservableCollection<MusicItem> tmpCollection = new ObservableCollection<MusicItem>();
            List<Song> songs = FileManager.Songs.ToList();
            List<Artist> artists = FileManager.Artists.ToList();
            List<MusicItem> musicItems = new List<MusicItem>();
            foreach (var artist in artists)
            {
                musicItems.Add(artist);
            }
            foreach (var song in songs)
            {
                musicItems.Add(song);
            }
            var musicItemquery = from musicItem in musicItems where (musicItem.ScreenName.Contains(StringToSearch)) select musicItem;
            foreach (MusicItem musicItem in musicItemquery)
                tmpCollection.Add(musicItem);

            resultSearchControl.Visibility = Visibility.Visible;
            resultSearchControl.ItemsSource = tmpCollection;
        }
    }
}
