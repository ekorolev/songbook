using System;
using System.Collections.Generic;
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
    class SearchBarClass
    {
        ListBox ResultSearchControl;
        TextBox SearchControl;
        public SearchBarClass(TextBox search, ListBox result);
        struct ArtistOrSong
        {
            public string Name;
            public byte Difference;
        }
        public SearchBarClass(TextBox SearchControl, ListBox ResultSearchControl)
        {
            ResultSearchControl = result;
            SearchControl = search;
        }

        public void SearchAction(string StringToSearch)
        {
            ResultSearchControl.ItemsSource = null;
            /* function of search*/
            //every Searched element add to Collection<string>

        }
    }
}
