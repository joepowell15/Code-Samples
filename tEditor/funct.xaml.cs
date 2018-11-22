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
    /// Interaction logic for funct.xaml
    /// </summary>
    public partial class funct : Window
    {
        public funct()
        {
            
            InitializeComponent();
            set();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var text = (TextBox)sender;
            if (!(text.Text.All(x => char.IsLetterOrDigit(x) || char.IsWhiteSpace(x))))
            {
                error.Text = "Incorrect Function Format";
            }
            else if (Char.IsDigit(text.Text[0]))
            {

                error.Text = "Incorrect Function Format";
            }
            else
            {
                error.Text = "";
            }
        }

        private void set()
        {
            string set = rt.Text.ToLower();
                if(!(String.IsNullOrEmpty(fn.Text)))
                {
                set += " " + fn.Text + " (";                    
                 
                }

            set+=pt1.Text.ToLower()+ " ";
            set += pn1.Text+ ", " + pt2.Text.ToLower()+" "+pn2.Text+")";
            func.Text = set;
        }


     

        private void textbChanged(object sender, TextChangedEventArgs e)
        {

            var text = (TextBox)sender;
            if (!text.IsLoaded)
                return;
            else
                set();
        }

        private void DropDownClosed(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            if (!combo.IsLoaded)
                return;
            else
                set();

        }
    }
}
