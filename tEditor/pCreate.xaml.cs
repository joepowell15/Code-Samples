using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
        }

      
        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            //file path concatenation with user input
            string filePath = fileTb.Text;
            filePath += "\\";
            filePath += slnName.Text;
            filePath += "\\";
            System.IO.Directory.CreateDirectory(filePath);
            filePath += appName.Text;
            filePath += ".c++";
            //System.IO.File.Create(filePath);
            //if hello world radio button is checked when create button is pushed add in hello world text template
            if (hwRb.IsChecked == true)
                addHw();
            //close this window and show the main window with updates.
            this.Close();
            App.Current.MainWindow.Visibility = Visibility.Visible;
            
            

        }
       //call a function from the main class to add text to the mainTb
        private void addHw()
        {
           
            MainWindow.mainWindow.SetTb();
             

        }
       
       
        //if other radio button is checked the program fills in to the path of the app exe
        private void otherRb_Checked(object sender, RoutedEventArgs e)
        {
            //sets folder of the app location to the textbox othertb
            string test = System.Environment.CurrentDirectory;
            fileTb.Text = test;
        }
        //if desktop button is checked it fills, the program fills into the path to the desktop
        private void dtopRb_Checked(object sender, RoutedEventArgs e)
        {
            string test = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileTb.Text = test;

        }
        //this function disables and enables the create button 
        private void slnName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(slnName.Text))
                createBtn.IsEnabled = false;
            else if(!string.IsNullOrWhiteSpace(slnName.Text) && (!string.IsNullOrWhiteSpace(appName.Text)))
            {
                if (emptyRb.IsChecked == true || hwRb.IsChecked == true || eclassRb.IsChecked == true)
                    createBtn.IsEnabled = true;
            }
        }
        //this function disables and enables the create button 
        private void appName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(appName.Text))
                createBtn.IsEnabled = false;
            else if (!string.IsNullOrWhiteSpace(slnName.Text) && (!string.IsNullOrWhiteSpace(appName.Text)))
            {
                if(emptyRb.IsChecked==true || hwRb.IsChecked==true || eclassRb.IsChecked==true)
                createBtn.IsEnabled = true;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.MainWindow.Visibility = Visibility.Visible;
        }
    }
}
