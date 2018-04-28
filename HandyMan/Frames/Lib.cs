using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HandyMan.Types;

namespace Handyman.Frames.Dictionary.Lib
{
    public static class Lib
    {
        public static RussianAdjective[] ResultsRA;
        public static RussianNoun[] ResultsRN;
        public static RussianVerb[] ResultsRV;

        public static string[] SplitMeanings(string meanings)
        {           

            //Make sure first if it contains anything
            if (meanings == "" || meanings == null)
            {
                return null;
            }
            else if(!(meanings.Contains(",") || meanings.Contains(";")))
            {
                return new string[] { meanings };
            }

            string[] ret = meanings.Split(',', ';');

            return ret;
        }        

        public static string CreateMeaningString(string[] meanings)
        {
            string ret = "";

            if (meanings.Length == 1)
            {
                return meanings[0];
            }
            else if (meanings.Length > 1)
            {
                ret = meanings[0];  //Set the first one
            }
            else
            {
                return null;
            }

            for (int i = 1; i < meanings.Length; i++)
            {
                ret += (", " + meanings[i]);
            }

            return ret;
        }

        public static Grid GetListElement(string word, bool details)
        {
            Grid ret = new Grid();
            Label label = new Label();
            Button button = new Button();

            Thickness marginLabel = new Thickness();
            marginLabel.Left = 10;

            ret.Height = 45;
            ret.Margin = marginLabel;
            
            label.Content = word;
            label.Foreground = new SolidColorBrush(Colors.White);
            label.FontSize = 14;
            label.VerticalAlignment = VerticalAlignment.Center;

            ret.Children.Add(label);

            if (details)
            {
                button.Content = "Details";
                button.Width = 60;
                button.Height = 20;
                button.HorizontalAlignment = HorizontalAlignment.Right;
                button.VerticalAlignment = VerticalAlignment.Center;
                Thickness marginButton = new Thickness();
                marginButton.Right = 15;
                button.Margin = marginButton;
                button.Tag = word;
                button.Click += DetailsOnWordEvent;

                ret.Children.Add(button);
            }

            return ret;
        }

        public static string[] GetListWordsRussianMeaning()
        {
            List<string> ret = new List<string>();
            foreach (RussianAdjective i in ResultsRA)
            {
                ret.Add(CreateMeaningString(i.Meanings));
            }
            foreach (RussianNoun i in ResultsRN)
            {
                ret.Add(CreateMeaningString(i.Meanings));
            }
            foreach (RussianVerb i in ResultsRV)
            {
                ret.Add(CreateMeaningString(i.Meanings));
                ret.Add(CreateMeaningString(i.Meanings));
            }

            return ret.ToArray();
        }

        public static string[] GetListWordsRussia()
        {
            List<string> ret = new List<string>();
            foreach (RussianAdjective i in ResultsRA)
            {
                ret.Add(i.Word);
            }
            foreach (RussianNoun i in ResultsRN)
            {
                ret.Add(i.Word);
            }
            foreach (RussianVerb i in ResultsRV)
            {
                ret.Add(i.Continous.Word + " (Continous)");
                ret.Add(i.Perfect.Word + " (Perfect)");
            }

            return ret.ToArray();
        }

        public static string[] GetTags()
        {
            List<string> ret = new List<string>();
            ret.AddRange(GenerateTags(ResultsRA.Length, 'a'));
            ret.AddRange(GenerateTags(ResultsRN.Length, 'n'));
            ret.AddRange(GenerateTags(ResultsRV.Length, 'v'));
            return ret.ToArray();
        }

        static string[] GenerateTags(int length, char prefix)
        {
            string[] ret = new string[length];
            for (int i = 0; i < length; i++)
            {
                ret[i] = prefix + "" + i;
            }
            return ret;
        }

        static string[] GenerateTagsForVerbs(int length, char prefix)
        {
            string[] ret = new string[length * 2];
            for (int i = 0; i < length; i++)
            {
                ret[i] = prefix + "" + i;
                ret[i] = prefix + "" + i;
            }
            return ret;
        }

        

        private static void DetailsOnWordEvent(object sender, RoutedEventArgs e)
        {
            string tag = (string)((Button)sender).Tag;

            PopupAdjectiveByTag(tag);
            PopupNounByTag(tag);
            PopupVerbByTag(tag);
        }

        public static void PopupAdjectiveByTag(string tag)
        {
            foreach (RussianAdjective i in ResultsRA)
            {
                if (i.Word == tag || CreateMeaningString(i.Meanings).Contains(tag))
                {
                    HandyMan.Popups.RussianAdjectivePopup popup = new HandyMan.Popups.RussianAdjectivePopup(i);
                    popup.Show();
                }
            }            
        }

        public static void PopupNounByTag(string tag)
        {
            foreach (RussianNoun i in ResultsRN)
            {
                if (i.Word == tag || CreateMeaningString(i.Meanings).Contains(tag))
                {
                    HandyMan.Popups.RussianNounPopup popup = new HandyMan.Popups.RussianNounPopup(i);
                    popup.Show();
                }
            }
        }

        public static void PopupVerbByTag(string tag)
        {
            foreach (RussianVerb i in ResultsRV)
            {
                if (i.Continous.Word == tag || i.Perfect.Word == tag || CreateMeaningString(i.Meanings).Contains(tag))
                {
                    HandyMan.Popups.RussianVerbPopup popup = new HandyMan.Popups.RussianVerbPopup(i);
                    popup.Show();
                }
            }
        }
    }
}