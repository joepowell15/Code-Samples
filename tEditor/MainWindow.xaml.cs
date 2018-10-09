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
            LNumb();
            this.Visibility = Visibility.Hidden;
            new pCreate().Show();
            
            //this is needed so we can access the main window and its functions from other classes
            mainWindow = this;
        }
        //this function add in hello world c++ code
        private void LNumb()
        {
            int x = 1;
            while (x < 101)
            {
                lineC.Text += x + "\n";
                x++;
            }

        }
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
       
       
    }
         
}
