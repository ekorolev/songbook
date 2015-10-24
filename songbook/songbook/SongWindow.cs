using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
﻿using Windows.UI.Xaml.Controls;


namespace songbook
{
    public class SongWindow
    {
        private SearchBar searchBar;
        private TextBox textControl;
        public SongWindow(TextBox textControl, SearchBar searchBar)
        {
            this.textControl = textControl;
            this.searchBar = searchBar;
            this.searchBar.SelectionChanged += ShowSong; 
        }
        private void ShowSong(Song song)
        {
            textControl.Text = song.Text;
        }
       
    }
}
