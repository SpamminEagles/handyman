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

using HandyMan.Types;

namespace HandyMan.Popups
{
    /// <summary>
    /// Interaction logic for RussianVerbPopup.xaml
    /// </summary>
    public partial class RussianVerbPopup : Window
    {
        RussianVerb verb;

        public RussianVerbPopup(RussianVerb verbParam)
        {
            InitializeComponent();

            verb = verbParam;
        }

        private void TitleContinous_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = verb.Continous.Word != "" ? verb.Continous.Word + " (Continous)" : "N/A";
        }

        private void s1_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = verb.Continous.S1 != "" ? verb.Continous.S1 : "N/A";
        }

        private void s2_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = verb.Continous.S2 != "" ? verb.Continous.S2 : "N/A";
        }

        private void p3_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = verb.Continous.P3 != "" ? verb.Continous.P3 : "N/A";
        }

        private void TitlePerfect_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = verb.Perfect.Word != "" ? verb.Perfect.Word + " (Perfect)" : "N/A";
        }

        private void s1_Copy_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = verb.Perfect.S1 != "" ? verb.Perfect.S1 : "N/A";
        }

        private void s2p_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = verb.Perfect.S2 != "" ? verb.Perfect.S2 : "N/A";
        }

        private void p3p_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = verb.Perfect.P3 != "" ? verb.Perfect.P3 : "N/A";
        }

        private void meanings_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = verb.Meanings.Length != 0 ? Database.RussianDictionary.CreateMeaningString(verb.Meanings) : "N/A";
        }
    }
}
