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
    /// Interaction logic for RussianAdjectivePopup.xaml
    /// </summary>
    public partial class RussianAdjectivePopup : Window
    {
        RussianAdjective adjective;

        public RussianAdjectivePopup(RussianAdjective adjectiveParam)
        {
            InitializeComponent();

            adjective = adjectiveParam;
        }

        private void Title_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = adjective.Word != "" ? adjective.Word : "N/A";
        }

        private void Mascuine_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = adjective.Masculine != "" ? adjective.Masculine : "N/A";
        }

        private void Feminine_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = adjective.Feminine != "" ? adjective.Feminine : "N/A";
        }

        private void Neuter_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = adjective.Neuter != "" ? adjective.Neuter : "N/A";
        }

        private void Meanings_Loaded(object sender, RoutedEventArgs e)
        {
            ((Label)sender).Content = adjective.Meanings.Length != 0 ? Database.RussianDictionary.CreateMeaningString(adjective.Meanings) : "N/A";
        }

        private void RemoveEntry_Click(object sender, RoutedEventArgs e)
        {
            Database.RussianDictionary.RemoveAdjective(adjective);
        }
    }
}
