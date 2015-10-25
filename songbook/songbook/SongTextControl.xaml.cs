using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
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
        AccordDialog accordDialog = new AccordDialog();

        public SongTextControl()
        {
            this.InitializeComponent();
        }
        public void AddLine(string mainLine, string extraString = null)
        {
            if (extraString != null)
            {
                var stack = new StackPanel() { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Stretch};
                foreach (var elem in SplitLine(extraString))
                {
                    if (elem[0] == ' ')
                    {
                        stack.Children.Add(new HyperlinkButton()
                        {
                            Content = new string('_', elem.Length),
                            FontSize = 18,
                            Opacity = 0
                        });
                    }
                    else
                    {
                        var hl = new HyperlinkButton()
                        {
                            Content = elem,
                            FontSize = 18,
                            Background = new SolidColorBrush(Colors.Green)
                        };
                        hl.Click += Hl_Click;
                        stack.Children.Add(hl);
                    }
                }
                Panel.Children.Add(stack);
            }
            Panel.Children.Add(new TextBlock()
            {
                Text = mainLine,
                FontSize = 18,
                HorizontalAlignment = HorizontalAlignment.Stretch
            });
        }

        private void Hl_Click(object sender, RoutedEventArgs e)
        {
            var hl = (HyperlinkButton) sender;
            var accordText = (string)hl.Content;
            accordDialog.SetAccord(hl.Content.ToString());
            accordDialog.ShowAsync();
        }

        public void ClearText()
        {
            Panel.Children.Clear();
        }

        private List<string> SplitLine(string line)
        {
            List<string> result = new List<string>();
            StringBuilder newPart = new StringBuilder();
            foreach (char c in line)
            {
                if (newPart.Length == 0)
                {
                    newPart.Append(c);
                }
                else if (c == ' ')
                {
                    if (newPart[0] == ' ')
                    {
                        newPart.Append(c);
                    }
                    else
                    {
                        result.Add(newPart.ToString());
                        newPart = new StringBuilder(c.ToString());
                    }
                }
                else
                {
                    if (newPart[0] == ' ')
                    {
                        result.Add(newPart.ToString());
                        newPart = new StringBuilder(c.ToString());
                    }
                    else
                    {
                        newPart.Append(c);
                    }
                }
            }
            result.Add(newPart.ToString());
            return result;
        }
    }
}
