using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace tEditor
{
    /// <summary>
    /// Interaction logic for pCreate.xaml
    /// </summary>
    public partial class pCreate : Window
    {
        public static pCreate pcreate;

        public pCreate()
        {
            InitializeComponent();
            string test = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileTb.Text = test;
            pcreate = this;
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            //file path concatenation with user input
            string filePath = fileTb.Text;
            filePath += "\\";
            filePath += slnName.Text;
            filePath += "\\";
            System.IO.Directory.CreateDirectory(filePath);
            filePath += appName.Text;
            filePath += ".cpp";
            //if hello world radio button is checked when create button is pushed add in hello world text template
            if (hwRb.IsChecked == true)
                setAvaHw(filePath);
            else if (eclassRb.IsChecked == true)
                setAvaCl(filePath);
            else if (emptyRb.IsChecked == true)
                MainWindow.mainWindow.setAva(appName.Text + "cpp", "", filePath);
            //close this window and show the main window with updates.
            MyStaticValues.myStaticFile = filePath;
            this.Close();
            App.Current.MainWindow.Visibility = Visibility.Visible;
        }
        //sets main textbox with class functionality +HW
        private void setAvaCl(string path)
        {
            string hw = "#include <cstdio>nl" +
                         "#include <string>nl" +
                         "#include <cstdlib>nl" +
                         "#include <iostream>nl" +
                         "class enterClassName nl{" +
                         "nl" +
                         "tb std::string example; nl" +
                         "tb int example2; nl" +
                         "tb enterClassName *next; nl" +
                         "};nl nl nl" +
                         "int main(int argc, char *argv[])nl" +
                         "{nl" +
                         "tb std::cout<<\"Hello World\"<<std::endl;nl" +
                         "nl nl tb return 0;nl" +
                         "}nl";
            string hWF = hw.Replace("nl", "\n");
            hWF = hWF.Replace("tb", "\t");

            MainWindow.mainWindow.setAva(appName.Text + ".cpp", hWF, path);


        }
        //call a function from the main class to add text to the avalon tb
        private void setAvaHw(string path)
        {
            string hw = "#include <cstdio>nl" +
                         "#include <string>nl" +
                         "#include <cstdlib>nl" +
                         "#include <iostream>nl" +
                         "int main(int argc, char *argv[])nl" +
                         "{nl" +
                         "tb std::cout<<\"Hello World\"<<std::endl;nl" +
                         "nl nl tb return 0;nl" +
                         "}nl";
            string hWF = hw.Replace("nl", "\n");
            hWF = hWF.Replace("tb", "\t");

            MainWindow.mainWindow.setAva(appName.Text + ".cpp", hWF, path);


        }


        //if other radio button is checked the program fills in to the path of the app exe
        private void otherRb_Checked(object sender, RoutedEventArgs e)
        {

            //this will be used to save files 
            /*System.Windows.Forms.SaveFileDialog SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
             SaveFileDialog1.InitialDirectory = System.Environment.CurrentDirectory;
             SaveFileDialog1.ShowDialog();*/
            //sets folder of the app location to the textbox othertb
        }

        //this function disables and enables the create button 
        private void slnName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(slnName.Text))
                CreateBtn.IsEnabled = false;
            else if (!string.IsNullOrWhiteSpace(slnName.Text) && (!string.IsNullOrWhiteSpace(appName.Text)))
            {
                if (emptyRb.IsChecked == true || hwRb.IsChecked == true || eclassRb.IsChecked == true)
                    CreateBtn.IsEnabled = true;
            }
        }
        //this function disables and enables the create button 
        private void appName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(appName.Text))
                CreateBtn.IsEnabled = false;
            else if (!string.IsNullOrWhiteSpace(slnName.Text) && (!string.IsNullOrWhiteSpace(appName.Text)))
            {
                if (emptyRb.IsChecked == true || hwRb.IsChecked == true || eclassRb.IsChecked == true)
                    CreateBtn.IsEnabled = true;
            }
            slnName.Text = appName.Text;
        }

        //sets mainwin back to visible
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.MainWindow.Visibility = Visibility.Visible;
        }
        //opens a directory browser every time other is clicked 
        private void Browsebtn_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new System.Windows.Forms.FolderBrowserDialog
            {
                SelectedPath = System.Environment.CurrentDirectory
            };
            folderBrowser.ShowDialog();

            //sets textbox to the user selected path
            fileTb.Text = folderBrowser.SelectedPath;
            //sets caret to the end of the textbox
            fileTb.CaretIndex = fileTb.GetLineLength(0);
            //simulates the user clicking the textbox
            fileTb.Focus();
        }

        private void Dtopbtn_Click(object sender, RoutedEventArgs e)
        {
            //sets the file location back to desktop if the user changes it
            string test = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileTb.Text = test;
        }
        //set called from main window
        public void set(string theme)
        {
            if (theme == "dark")
            {
                Uri uri = new Uri("Themes/MetroDark/MetroDark.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
                Uri uri2 = new Uri("Themes/MetroDark/MetroDark.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);
                var brush = new SolidColorBrush(Color.FromArgb(255, (byte)45, (byte)45, (byte)48));
                ThemeDictionary.MergedDictionaries.Clear();
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri2 });

                Grid.Background = brush;
            }
            else
            {
                Uri uri = new Uri("Themes/Metro/Metro.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
                Uri uri2 = new Uri("Themes/Metro/Metro.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);

                ThemeDictionary.MergedDictionaries.Clear();
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri2 });

                Grid.Background = Brushes.White;
            }

        }
        //light button click sets theme to light
        private void Light_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Themes/Metro/Metro.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
            Uri uri2 = new Uri("Themes/Metro/Metro.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);

            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri2 });

            Grid.Background = Brushes.White;
            MainWindow.mainWindow.setTheme("light");

        }
        //button click sets theme to dark
        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Themes/MetroDark/MetroDark.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
            Uri uri2 = new Uri("Themes/MetroDark/MetroDark.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);
            var brush = new SolidColorBrush(Color.FromArgb(255, (byte)45, (byte)45, (byte)48));
            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri2 });

            Grid.Background = brush;
            MainWindow.mainWindow.setTheme("dark");

        }
    }
}
