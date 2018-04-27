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
    /// Interaction logic for RussianNounPopup.xaml
    /// </summary>
    public partial class RussianNounPopup : Window
    {
        RussianNoun noun;

        public RussianNounPopup(RussianNoun nounParam)
        {
            InitializeComponent();
            noun = nounParam;
        }

        private void Title_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = noun.Word != "" ? noun.Word : "N/A";
        }

        private void Word_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = noun.Word != "" ? noun.Word : "N/A";
        }

        private void Plural_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = noun.Plural != "" ? noun.Plural : "N/A";
        }

        private void Manings_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = noun.Meanings.Length != 0 ? Database.RussianDictionary.CreateMeaningString(noun.Meanings) : "N/A";
        }
    }
}
