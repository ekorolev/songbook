using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace songbook
{
    public static class AppStates
    {
        private static Stack<AppState> States { get; set; }

        static AppStates()
        {
            States = new Stack<AppState>();
        }        
        public static void SaveState(SongTextControl songTextControl, ListBox listArtistsControl)
        {
            var state = new AppState
            {
                ListArtistsControlItems = new ObservableCollection<MusicItem>(),
            };

            state.ListArtistsControlVisible = listArtistsControl.Visibility;
            state.SongTextControlVisible = songTextControl.Visibility;
            state.SongTextControlStack = songTextControl.GetStackPanel();

            foreach (MusicItem item in (ObservableCollection<MusicItem>)listArtistsControl.ItemsSource)
            {
                state.ListArtistsControlItems.Add(item);
            }
            States.Push(state);
        }
        public static void RestoreState( SongTextControl songTextControl, ListBox listArtistsControl)
        {
            AppState state;
            try
            {
                 state = States.Pop();                 
            }
            catch
            {
                return;
            }
            listArtistsControl.Visibility = state.ListArtistsControlVisible;
            songTextControl.Visibility = state.SongTextControlVisible;
            songTextControl.SetStackPanel(state.SongTextControlStack);
            ((ObservableCollection<MusicItem>)listArtistsControl.ItemsSource).Clear();
            foreach (MusicItem item in state.ListArtistsControlItems)
            {
                ((ObservableCollection<MusicItem>)listArtistsControl.ItemsSource).Add(item);
            }
        }
    }

    public class AppState
    {
        public Visibility ListArtistsControlVisible { get; set; }
        public Visibility SongTextControlVisible { get; set; }
        public ObservableCollection<MusicItem> ListArtistsControlItems { get; set; }
        public StackPanel SongTextControlStack { get; set; }
        public void SaveState(SongTextControl songTextControl, ListBox listArtistsControl)
        {
            var state = new AppState
            {
                ListArtistsControlItems = new ObservableCollection<MusicItem>(),
            };

            state.ListArtistsControlVisible = listArtistsControl.Visibility;
            state.SongTextControlVisible = songTextControl.Visibility;
            state.SongTextControlStack = songTextControl.GetStackPanel();

            foreach (MusicItem item in (ObservableCollection<MusicItem>)listArtistsControl.ItemsSource)
            {
                state.ListArtistsControlItems.Add(item);
            }           
        }
        public void RestoreState(AppState state, SongTextControl songTextControl, ListBox listArtistsControl)
        {
            listArtistsControl.Visibility = state.ListArtistsControlVisible;
            songTextControl.Visibility = state.SongTextControlVisible;
            songTextControl.SetStackPanel(state.SongTextControlStack);
            ((ObservableCollection<MusicItem>)listArtistsControl.ItemsSource).Clear();
            foreach (MusicItem item in state.ListArtistsControlItems)
            {
                ((ObservableCollection<MusicItem>)listArtistsControl.ItemsSource).Add(item);
            }
        }
    }
}
