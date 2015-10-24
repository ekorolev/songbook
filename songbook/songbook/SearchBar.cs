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
            sourceSong=_sourceSong;
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

        public delegate void SelectionChangedEventHandler(Song song);
        public event SelectionChangedEventHandler SelectionChanged;

        public SearchBar(TextBox searchControl, ListBox resultSearchControl)
        {
            this.searchControl = searchControl;
            this.resultSearchControl = resultSearchControl;
            searchControl.TextChanged += searchControl_TextChanged;
            resultSearchControl.SelectionChanged += ResultSearchControl_SelectionChanged;
        }
        private void ResultSearchControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SelectionChanged(((ArtistOrSong)((ListBox)sender).SelectedItem).sourceSong);
        }
        private void searchControl_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchAction(((TextBox)sender).Text);
        }

        public void SearchAction(string StringToSearch)
        {
            //if (StringToSearch.Length == 0) return;
            ObservableCollection<ArtistOrSong> tmpCollection = new ObservableCollection<ArtistOrSong>();
            List<Song> songs = FileManager.Songs.ToList();
            var songquery = from song in songs where(song.FullName.Contains(StringToSearch)) select song;
            foreach (Song song in songquery)
            tmpCollection.Add(new ArtistOrSong(song.FullName, (byte)1, song));
                      
            resultSearchControl.Visibility = Visibility.Visible;
            resultSearchControl.ItemsSource = tmpCollection;
        }
    }
}
