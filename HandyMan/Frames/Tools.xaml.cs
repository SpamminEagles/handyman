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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandyMan.Frames
{
    /// <summary>
    /// Interaction logic for Tools.xaml
    /// </summary>
    public partial class Tools : Page
    {
        public Tools()
        {
            InitializeComponent();
        }

        private void LatToCyrRBOn_Checked(object sender, RoutedEventArgs e)
        {
            Scripts.Central.LCInternal = true;
        }

        private void LatToCyrRBOff_Checked(object sender, RoutedEventArgs e)
        {
            Scripts.Central.LCInternal = false;
        }
    }
}
