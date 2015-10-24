using System;
using System.Collections.Generic;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace songbook
{
    public sealed partial class SongTextControl : UserControl
    {
        public SongTextControl()
        {
            this.InitializeComponent();
            for (int i = 0; i < 14; i++)
            {
                this.GridComponent.Children.Add(new Button
                {
                    Content = "12345",
                    //Margin = new Thickness(138, i * 20, 0, 0),
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left
                });
            }

        }
        //HorizontalAlignment="Left" Margin="138,128,0,0" VerticalAlignment="Top"
        private List<Control> addedControls = new List<Control>();

        public void AddLine(string mainLine, string extraString = null)
        {
            this.GridComponent.Children.Add(new Button
            {
                Content = "12345",
                Margin = new Thickness(138, 128, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            });
        }
    }
}
