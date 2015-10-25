﻿using System;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace songbook
{   
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SearchBar searchBarPanel;
        public MainPage()
        {
            
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            FileManager.Songs.ToList();
            FileManager.Artists.ToList();            
            this.NavigationCacheMode = NavigationCacheMode.Required;
            SearchBar SearchBar = new SearchBar(SearchControl, ResultSearchControl);
            SongWindow songWindow = new SongWindow(SongTextControl, SearchBar);
            MusicItemsViewer musicItemsViewer = new MusicItemsViewer(ListArtistsControl, SongTextControl, SearchBar);
            searchBarPanel = SearchBar;
            HardwareButtons.BackPressed += back_Click;            
         }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
        //private void ResultSearchControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
           
        //}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           SongTextControl.Width = ResultSearchControl.Width = SearchControl.Width = Window.Current.Bounds.Width;
        }
        private void back_Click(object sender, BackPressedEventArgs e)
        {
            
            if (searchBarPanel.conditionOfResultSearchControl == (byte)0)
            {
                //exit or check do u want to exit
                e.Handled = true;
            }
            if (searchBarPanel.conditionOfResultSearchControl == (byte)1)
            {
                ResultSearchControl.ItemsSource = new ObservableCollection<MusicItem>();
                ResultSearchControl.Visibility = Visibility.Collapsed;
                searchBarPanel.conditionOfResultSearchControl = (byte)0;
                e.Handled = true;
            }
            if (searchBarPanel.conditionOfResultSearchControl == (byte)2)
            {
                searchBarPanel.conditionOfResultSearchControl = (byte)1;
                searchBarPanel.SearchAction(searchBarPanel.previousStringToSearch);
                e.Handled = true;
            }
            
        }
    }
}
