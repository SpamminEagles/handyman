using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HandyMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer timer = new Timer();
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            Scripts.LLproc.FunctionToCallOne = SetTestTextBox;

            Scripts.Ticker.StartTicking();
        }

        ~MainWindow()
        {
            timer.Enabled = false;
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



        private void quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuTestTextBox_Loaded(object sender, RoutedEventArgs e)
        {            
            timer.Interval = 50;
            timer.AutoReset = true;
            timer.Elapsed += UpdateTestBox;
            timer.Enabled = true;
        }

        private void UpdateTestBox(object sender, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke(delegate () 
                                 {
                                     ((TextBlock)FindName("MenuTestTextBox")).Text = ((Key)Scripts.LLproc.LatestPressedKey).ToString();
                                     /*string lul = VkKeyScan('a').ToString();
                                     lul += " " + VkKeyScan('b').ToString();
                                     lul += " " + VkKeyScan('c').ToString();
                                     lul += " " + VkKeyScan('ő').ToString();

                                     ((TextBlock)FindName("MenuTestTextBox")).Text = lul;*/
                                 });
            }
            catch { }
        }

        
    }
}
