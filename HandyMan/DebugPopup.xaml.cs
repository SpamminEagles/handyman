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

namespace HandyMan
{
    /// <summary>
    /// Interaction logic for DebugPopup.xaml
    /// </summary>
    public partial class DebugPopup : Window
    {
        //string TextToShow;
        public DebugPopup(string param = "DEBUG!!")
        {
            InitializeComponent();
            //TextToShow = param;
        }

        /*private void label_Loaded(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = TextToShow;
        }*/
    }
}
