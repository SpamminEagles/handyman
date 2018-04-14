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
using System.Windows.Threading;
using HandyMan;
using HandyMan.Types;

namespace HandyMan.Frames
{
    /// <summary>
    /// Interaction logic for Dictionary.xaml
    /// </summary>
    public partial class Dictionary : Page
    {

        public Dictionary()
        {
            InitializeComponent();

            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() => { Setup(); }));
        }

        //Data
        RadioButton[] PartsOfSpeech = new RadioButton[3];
        TPartsOfSpeech ChosenPOS;
        Languages ChoosenLang;

        void Setup()
        {
            //Set up POS Radio Buttons
            PartsOfSpeech[0] =  (RadioButton)FindName("RBPOSNoun");
            PartsOfSpeech[1] = (RadioButton)FindName("RBPOSVerb");
            PartsOfSpeech[2] = (RadioButton)FindName("RBPOSAdjective");
        }

        private void RBPOS_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton RBsender = (RadioButton)sender;
            
            switch (RBsender.Name)
            {
                case "RBPOSNoun":
                    ChosenPOS = TPartsOfSpeech.Noun;
                    SwitchAGrid("ANounGrid");
                    break;
                case "RBPOSVerb":
                    ChosenPOS = TPartsOfSpeech.Verb;
                    SwitchAGrid("AVerbGrid");
                    break;
                case "RBPOSAdjective":
                    ChosenPOS = TPartsOfSpeech.Adjective;
                    SwitchAGrid("AAdjectiveGrid");
                    break;
            }


        }

        private void SwitchAGrid (string SelectGrid)
        {
            ((Grid)FindName("ANounGrid")).Visibility = Visibility.Hidden;
            ((Grid)FindName("AVerbGrid")).Visibility = Visibility.Hidden;
            ((Grid)FindName("AAdjectiveGrid")).Visibility = Visibility.Hidden;

            ((Grid)FindName(SelectGrid)).Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ( ((ComboBoxItem)((ComboBox)sender).SelectedItem).Name)
            {
                case "AddRussian":
                    ChoosenLang = Languages.Russian;
                    break;
            }

            foreach (RadioButton i in PartsOfSpeech)
            {
                i.IsEnabled = true;
            }
        }

        private void SaveEntry(object sender, RoutedEventArgs e)
        {

        }

        private void EnableSave(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                ((Button)FindName("SaveEntryButton")).IsEnabled = true;
            }else
            {
                ((Button)FindName("SaveEntryButton")).IsEnabled = false;
            }
        }

        private void RBConIrreg_Checked(object sender, RoutedEventArgs e)
        {
            SetConBoxes((bool)((RadioButton)FindName("RBConIrreg")).IsChecked);
        }

        private void SetConBoxes (bool enable)
        {
            ((TextBox)FindName("ConConS1")).IsEnabled = enable;
            ((TextBox)FindName("ConConS2")).IsEnabled = enable;
            ((TextBox)FindName("ConConP3")).IsEnabled = enable;
        }
    }
}
