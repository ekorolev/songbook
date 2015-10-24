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
    class SearchBar
    {
        private TextBox searchControl;
        private ListBox resultSearchControl;

        public class ArtistOrSong
        {
            public string Name;
            public byte Difference;
            public ArtistOrSong(string _name, byte _difference)
            {
                Name = _name;
                Difference = _difference;
            }
            public override string ToString()
            {
                return Name;
            }

        }
        public SearchBar(TextBox searchControl, ListBox resultSearchControl)
        {
            this.searchControl = searchControl;
            this.resultSearchControl = resultSearchControl;
            searchControl.TextChanged += searchControl_TextChanged;
        }

        private void searchControl_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchAction(((TextBox)sender).Text);
        }

        public void SearchAction(string StringToSearch)
        {
            ObservableCollection<ArtistOrSong> tmpCollection = new ObservableCollection<ArtistOrSong>();
            List<Song> songs = FileManager.Songs.ToList();
            var songquery = from song in songs where(song.Name.Contains(StringToSearch)) select song;
            foreach (Song song in songquery)
                tmpCollection.Add(new ArtistOrSong(song.Name, (byte)1));
             
            resultSearchControl.Visibility = Visibility.Visible;
            resultSearchControl.ItemsSource = tmpCollection;
        }
    }
}
