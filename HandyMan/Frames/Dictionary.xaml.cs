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

using Handyman.Frames.Dictionary.Lib;

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
        RussianConjugation conjugation = RussianConjugation.Regular1;

        //UI elements
        StackPanel ForeignLan;
        StackPanel MotherLan;

        void Setup()
        {
            //Set up POS Radio Buttons
            PartsOfSpeech[0] =  (RadioButton)FindName("RBPOSNoun");
            PartsOfSpeech[1] = (RadioButton)FindName("RBPOSVerb");
            PartsOfSpeech[2] = (RadioButton)FindName("RBPOSAdjective");

            ForeignLan = (StackPanel)FindName("ForLanListSearch");
            MotherLan = (StackPanel)FindName("MothLanListSearch");

            
        }

        private void GenerateLists(StackPanel target, string[] words)
        {
            target.Children.Clear();
            for (int i = 0; i < words.Length; i++)
            {
                target.Children.Add(Lib.GetListElement(words[i]));
            }
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
            switch (ChosenPOS)
            {
                case TPartsOfSpeech.Noun:
                    RussianNoun noun = new RussianNoun();
                    noun.Word = ((TextBox)FindName("AWNTextBox")).Text;
                    noun.Plural = ((TextBox)FindName("NounPluralName")).Text;
                    noun.Meanings = Lib.SplitMeanings(((TextBox)FindName("MeaningNoun")).Text);

                    ClearBoxes("AWNTextBox", "NounPluralName", "MeaningNoun");
                    Database.RussianDictionary.AddNoun(noun);
                    break;
                case TPartsOfSpeech.Adjective:
                    RussianAdjective adjective = new RussianAdjective();
                    adjective.Word = ((TextBox)FindName("AWATextBox")).Text;
                    adjective.Masculine = ((TextBox)FindName("MasculineTB")).Text;
                    adjective.Feminine = ((TextBox)FindName("FeminineTB")).Text;
                    adjective.Neuter = ((TextBox)FindName("NeuterTB")).Text;
                    adjective.Meanings = Lib.SplitMeanings(((TextBox)FindName("MeaningAdjective")).Text);

                    ClearBoxes("AWATextBox", "MasculineTB", "FeminineTB", "NeuterTB", "MeaningAdjective");
                    Database.RussianDictionary.AddAdjective(adjective);
                    break;
                case TPartsOfSpeech.Verb:
                    RussianVerb verb = new RussianVerb();
                    verb.Continous.Word = ((TextBox)FindName("AWVTextBoxCon")).Text;
                    verb.Continous.Conjugation = conjugation;
                    switch (verb.Continous.Conjugation)
                    {
                        case RussianConjugation.Regular1:
                            verb.Continous.S1 = "Regular I";
                            verb.Continous.S2 = "Regular I";
                            verb.Continous.P3 = "Regular I";
                            break;
                        case RussianConjugation.Regular2:
                            verb.Continous.S1 = "Regular II";
                            verb.Continous.S2 = "Regular II";
                            verb.Continous.P3 = "Regular II";
                            break;

                        default:
                            verb.Continous.S1 = ((TextBox)FindName("ConConS1")).Text;
                            verb.Continous.S2 = ((TextBox)FindName("ConConS2")).Text;
                            verb.Continous.P3 = ((TextBox)FindName("ConConP3")).Text;
                            break;
                    }
                    verb.Perfect.Word = ((TextBox)FindName("AWVTextBoxPer")).Text;
                    verb.Perfect.S1 = ((TextBox)FindName("PerConS1")).Text;
                    verb.Perfect.S2 = ((TextBox)FindName("PerConS2")).Text;
                    verb.Perfect.P3 = ((TextBox)FindName("PerConP3")).Text;
                    verb.Meanings = Lib.SplitMeanings(((TextBox)FindName("MeaningVerb")).Text);

                    ClearBoxes("AWVTextBoxCon", "ConConS1", "ConConS2", "ConConP3", "PerConS2", "PerConS1", "PerConP3", "MeaningVerb", "AWVTextBoxPer");
                    UncheckCon();
                    Database.RussianDictionary.AddVerb(verb);
                    break;
            }
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

        private void Con_Checked(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Name)
            {
                case "RBConReg1":
                    conjugation = RussianConjugation.Regular1;
                    break;
                case "RBConReg2":
                    conjugation = RussianConjugation.Regular2;
                    break;
                case "RBConIrreg":
                    conjugation = RussianConjugation.Irregular;
                    break;
            }
        }

        private void UncheckCon ()
        {
            ((RadioButton)FindName("RBConReg1")).IsChecked = false;
            ((RadioButton)FindName("RBConReg2")).IsChecked = false;
            ((RadioButton)FindName("RBConIrreg")).IsChecked = false;
        }

        private void ClearBoxes(params string[] name)
        {
            foreach (string i in name)
            {
                ((TextBox)FindName(i)).Text = "";
            }
        }

        private void DicStartSearchForeign_Click(object sender, RoutedEventArgs e)
        {
            Lib.ResultsRA = Database.RussianDictionary.FindAdjectives(((TextBox)FindName("DicSearchForeign")).Text);
            Lib.ResultsRN = Database.RussianDictionary.FindNouns(((TextBox)FindName("DicSearchForeign")).Text);
            Lib.ResultsRV = Database.RussianDictionary.FindVerbs(((TextBox)FindName("DicSearchForeign")).Text);

            GenerateLists(
                ForeignLan,
                Lib.GetListWordsRussia());
            GenerateLists(
                MotherLan,
                Lib.GetListWordsRussianMeaning());
        }
    }
}
