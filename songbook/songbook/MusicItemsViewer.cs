using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Phone.UI.Input;

namespace songbook
{
    public class MusicItemsViewer
    {
        private ListBox listArtistsControl;
        private SongTextControl songTextControl;
        private SearchBar searchBar;
        public delegate void MusicItemClickHandlerEvent(Song song);
        public event MusicItemClickHandlerEvent MusicItemClick;
        public MusicItemsViewer(ListBox listArtistsControl, SongTextControl songTextControl, SearchBar searchBar)
        {
            this.listArtistsControl = listArtistsControl;
            ObservableCollection<MusicItem> tmpCollection = new ObservableCollection<MusicItem>();
            List<Artist> artists = FileManager.Artists.ToList();
            List<MusicItem> musicItems = new List<MusicItem>();
            foreach (var artist in artists)
            {
                musicItems.Add(artist);
            }
            foreach (MusicItem musicItem in musicItems)
                tmpCollection.Add(musicItem);

            this.listArtistsControl.ItemsSource = tmpCollection;
            this.songTextControl = songTextControl;
            this.searchBar = searchBar;
            searchBar.SelectionChanged += SelectionChanged;
            searchBar.ArtistChanged += ArtistChanged;
            listArtistsControl.SelectionChanged += MusicItemChange;
        }
        private void SelectionChanged(Song song)
        {
            listArtistsControl.Visibility = Visibility.Collapsed;
            songTextControl.Visibility = Visibility.Visible;
        }
        private void ArtistChanged(Artist artist)
        {
            searchBar.conditionOfResultSearchControl = (byte)2;
            List<Song> listofArtistSongs = artist.SongsOfArtist;
            List<MusicItem> musicItems = new List<MusicItem>();
            foreach (var song in listofArtistSongs)
            {
                musicItems.Add(song);
            }
            ObservableCollection<MusicItem> tmpCollection = new ObservableCollection<MusicItem>();
            foreach (MusicItem musicItem in musicItems)
            {
                tmpCollection.Add(musicItem);
                listArtistsControl.Visibility = Visibility.Visible;
                songTextControl.Visibility = Visibility.Collapsed;
                listArtistsControl.ItemsSource = tmpCollection;
            }
        }
        private void MusicItemChange(object sender, SelectionChangedEventArgs e) 
        {
            var selectedItem = ((MusicItem)((ListBox)sender).SelectedItem);
            if (selectedItem == null)
            {
                return;
            }
            if (selectedItem is Song)
            {
                searchBar.conditionOfResultSearchControl = (byte)1;
                MusicItemClick((Song)selectedItem);
                songTextControl.Visibility = Visibility.Visible;
                listArtistsControl.Visibility = Visibility.Collapsed;
            }
            if(selectedItem is Artist)
            {
                ArtistChanged((Artist)selectedItem);
        }
 }
    }
}

