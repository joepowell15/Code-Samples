using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //this is needed so we can access the main window and its functions from other classes
        public static MainWindow mainWindow;

        public MainWindow()
        {
            //immediately hides the main window and only shows the creation screen
            InitializeComponent();
            lineC.Text += "1" +"\n";
            this.Visibility = Visibility.Hidden;
            new pCreate().Show();
            
            //this is needed so we can access the main window and its functions from other classes
            mainWindow = this;
        }
        //this function add in hello world c++ code
        
        public int SetTb()
        {
            string hW = "#include <cstdio>nl" +
                       "#include <string>nl" +
                       "#include <cstdlib>nl" +
                       "#include <iostream>nl" +
                       "int main(int argc, char *argv[])nl" +
                       "{nl" +
                       "tb std::cout<<\"Hello World\"<<std::endl;nl" +
                       "nl nl tb return 0;nl" +
                       "}nl";
            string hWF = hW.Replace("nl","\n");
            hWF = hWF.Replace("tb", "\t");
            mainTb.Text = hWF;

            return 0;
        }

        private void ThemeChng_Click(object sender, RoutedEventArgs e)
        {
           
            
            //if light theme found set to dark
            if (ThemeDictionary.MergedDictionaries[0].Source.ToString().Equals("Themes/Metro/Metro.MSControls.Core.Implicit.xaml"))
            {


                Uri uri3 = new Uri("Themes/MetroDark/MetroDark.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
                Uri uri4 = new Uri("Themes/MetroDark/MetroDark.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);
                ThemeDictionary.MergedDictionaries.Clear();
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri3 });
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri4 });
                var brush = new SolidColorBrush(Color.FromArgb(255, (byte)45, (byte)45, (byte)48));
                var brush2=new SolidColorBrush(Color.FromArgb(255, (byte)104, (byte)104, (byte)119));
                Grid.Background = brush;
                menu.Foreground = Brushes.White;
                Tlbar.Background = brush2;
                menu.Background = brush;
                Tray.Background = brush;

            }
            //else set to light theme
            else
            {
                Uri uri = new Uri("Themes/Metro/Metro.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
                Uri uri2 = new Uri("Themes/Metro/Metro.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);
                ThemeDictionary.MergedDictionaries.Clear();
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri2 });
                var brush = new SolidColorBrush(Color.FromArgb(255, (byte)45, (byte)45, (byte)48));
                Tray.Background = Brushes.White;
                Grid.Background = brush;
                Grid.Background = Brushes.White;
                menu.Foreground = brush;
                menu.Background = Brushes.White;
                Tlbar.Background = Brushes.White;
            }
            
        }

        private void mainTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (lineC.LineCount != mainTb.LineCount)
            {
                while (lineC.LineCount < mainTb.LineCount)
                {
                    lineC.Text += lineC.LineCount + "\n";

                }
            }
        }

     


        private void newFile_Click(object sender, RoutedEventArgs e)
        {
            new pCreate().Show();
        }
    }
         
}
