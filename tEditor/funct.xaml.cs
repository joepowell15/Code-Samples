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
        public static funct functWin;
        public funct()
        {
            
            InitializeComponent();
            set();
            functWin = this;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          
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

        private void LstFocus(object sender, RoutedEventArgs e)
        {
            if (valid(fn.Text) == -1)
                error.Text = "Name is not alphanumeric";
            else if (valid(fn.Text) == -2)
                error.Text = "First character is Digit";
            else
                error.Text = "";

            if (valid(pn1.Text) == -1)
                error2.Text = "Name is not alphanumeric";
            else if (valid(pn1.Text) == -2)
                error2.Text = "First character is Digit";
            else
                error2.Text = "";


            if (valid(pn2.Text) == -1)
                error3.Text = "Name is not alphanumeric";
            else if (valid(pn2.Text) == -2)
                error3.Text = "First character is Digit";
            else
                error3.Text = "";

            if (valid(pn2.Text)==0 && valid(pn1.Text)==0 && valid(fn.Text)==0)
            {
                create.IsEnabled = true;

            }
            else
	        {
                create.IsEnabled = false;
            
            }
            
        }
        private int valid(string text)
        {
            if (text.Length == 0)
                return -1;
            if (!(text.All(x => char.IsLetterOrDigit(x) || x=='_')))
            {
                
                return -1;
            }
            else if (Char.IsDigit(text.ElementAt(0)))
            {

                return -2;
            }
            else
            {
                
                return 0;
            }
           
        }
        public void setTheme(string theme)
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
    }
}
