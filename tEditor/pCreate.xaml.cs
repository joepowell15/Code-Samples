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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //sets folder of the app location to the textbox othertb
            otherTb.Visibility = Visibility.Visible;
           string test= AppDomain.CurrentDomain.BaseDirectory;
            otherTb.Text = test;
        }
    }
}
