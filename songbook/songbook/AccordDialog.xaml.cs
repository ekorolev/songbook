using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace songbook
{
    public sealed partial class AccordDialog : ContentDialog
    {
        private Dictionary<string, string> pathsOfAccords = new Dictionary<string, string>()
        {
            {"A","ms-appx:///Assets/A.gif"},
            {"A7","ms-appx:///Assets/A7.gif"},
            {"AM","ms-appx:///Assets/Am.gif"},
            {"C","ms-appx:///Assets/C.gif"},
            {"C7","ms-appx:///Assets/C7.gif"},
            {"CM","ms-appx:///Assets/Cm.gif"},
            {"CWM","ms-appx:///Assets/Cwm.gif"},
            {"D","ms-appx:///Assets/D.gif"},
            {"DM","ms-appx:///Assets/Dm.gif"},
            {"E","ms-appx:///Assets/E.gif"},
            {"E7","ms-appx:///Assets/E7.gif"},
            {"EM","ms-appx:///Assets/Em.gif"},
            {"F","ms-appx:///Assets/F.gif"},
            {"FM","ms-appx:///Assets/Fm.gif"},
            {"FW","ms-appx:///Assets/Fw.gif"},
            {"FWM","ms-appx:///Assets/Fwm.gif"},
            {"G","ms-appx:///Assets/G.gif"},
            {"G7","ms-appx:///Assets/G7.gif"},
            {"GM","ms-appx:///Assets/Gm.gif"},
            {"HM","ms-appx:///Assets/Hm.gif"}
        };
        public AccordDialog()
        {
            this.InitializeComponent();
        }

        public void SetAccord(string accord)
        {
            dialog.Title = accord;
            if (pathsOfAccords.ContainsKey(accord.ToUpper()))
            {
                AccordImage.Source =
                    new BitmapImage(new Uri(pathsOfAccords[accord.ToUpper()], UriKind.RelativeOrAbsolute));
            }
            else
            {
                AccordImage.Source =
                    new BitmapImage(new Uri("ms-appx:///Assets/dunno.jpg", UriKind.RelativeOrAbsolute));
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
