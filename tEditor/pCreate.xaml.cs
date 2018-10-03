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

            string filePath = fileTb.Text;
            filePath += "\\";
            filePath += slnName.Text;
            filePath += "\\";
            System.IO.Directory.CreateDirectory(filePath);
            MessageBox.Show(filePath);
            filePath += appName.Text;
            filePath += ".c++";
            MessageBox.Show(filePath);
            System.IO.File.Create(filePath);
        }

        private void otherRb_Checked(object sender, RoutedEventArgs e)
        {
            //sets folder of the app location to the textbox othertb
            string test = System.Environment.CurrentDirectory;
            fileTb.Text = test;
        }

        private void dtopRb_Checked(object sender, RoutedEventArgs e)
        {
            string test = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileTb.Text = test;

        }

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
    }
}
