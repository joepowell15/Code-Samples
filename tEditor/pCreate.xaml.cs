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
        public pCreate()
        {
            InitializeComponent();
            string test = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileTb.Text = test;
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
            filePath += ".c++";
            System.IO.File.Create(filePath);
            //if hello world radio button is checked when create button is pushed add in hello world text template
            if (hwRb.IsChecked == true)
                AddHw();
            //close this window and show the main window with updates.
            this.Close();
            App.Current.MainWindow.Visibility = Visibility.Visible;
        }
       //call a function from the main class to add text to the mainTb
        private void AddHw()
        {

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
            else if(!string.IsNullOrWhiteSpace(slnName.Text) && (!string.IsNullOrWhiteSpace(appName.Text)))
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
                if(emptyRb.IsChecked==true || hwRb.IsChecked==true || eclassRb.IsChecked==true)
                CreateBtn.IsEnabled = true;
            }
        }

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
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Themes/Metro/Metro.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
            Uri uri2 = new Uri("Themes/Metro/Metro.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);

            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri2 });

            Grid.Background = Brushes.White;
        }

        private void Dark_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Themes/MetroDark/MetroDark.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
            Uri uri2 = new Uri("Themes/MetroDark/MetroDark.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);
            var brush = new SolidColorBrush(Color.FromArgb(255, (byte)45, (byte)45, (byte)48));
            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri2 });

            Grid.Background = brush;
        }
    }
}
