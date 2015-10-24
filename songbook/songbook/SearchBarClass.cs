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
        struct ArtistOrSong
        {
            public string Name;
            public byte Difference;
        }
        public SearchBar(TextBox searchControl, ListBox resultSearchControl)
        {

        }

        public void SearchAction(string StringToSearch)
        {
            ObservableCollection<ArtistOrSong> tmpCollection = new ObservableCollection<ArtistOrSong>();
            /*function of search*/
            //every Searched element add to tmpCollection          


            resultSearchControl.ItemsSource = tmpCollection;
        }
    }
}
