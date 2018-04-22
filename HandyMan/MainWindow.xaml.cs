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
namespace HandyMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Scripts.LLproc.FunctionToCallOne = SetTestTextBox;

            
        }

        public void SetTestTextBox(string param)
        {
            ((TextBox)FindName("MenuTestTextBox")).Text = param;
            /*DebugPopup DBP = new DebugPopup();
            DBP.Show();*/
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MB_Dictionary_Click(object sender, RoutedEventArgs e)
        {
            Uri src = new Uri("Frames/Dictionary.xaml", UriKind.Relative);
            Frame.Source = src;
        }

        private void MB_Notebook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartStopProc_Click(object sender, RoutedEventArgs e)
        {
            if (!Scripts.LLproc.HookSet)
            {
                Scripts.LLproc.FunctionToCallOne = SetTestTextBox;
                Scripts.LLproc.StartHook();
                ((Button)sender).Content = "StopHook";
            }else
            {
                Scripts.LLproc.StopHook();
                ((Button)sender).Content = "StartHook";
            }
        }
    }
}
