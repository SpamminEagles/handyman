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

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = RemoveSpacesFromEnds(ret[i]);
            }

            return ret;
        }

        public static string RemoveSpacesFromEnds(string param)
        {
            int pre = 0;
            int post = 1;
            bool postBool = false;

            //If it starts with [SPACE]s:
            if (param[0] == ' ')
            {
                for (int j = 0; j < param.Length; j++)
                {
                    if (param[j] != ' ')
                    {
                        pre = j;
                    }
                }
            }

            //If it ends witn [SPACE]s
            if (param[param.Length - 1] == ' ')
            {
                for (int k = (param.Length - 1); k > -1; k--)
                {
                    if (param[k] != ' ')
                    {
                        post = k;
                        postBool = true;
                    }
                }
            }

            //Let's chop off:
            /*if (pre != 0 || postBool)
            {
                if (postBool)
                {
                    param = param.Substring(pre, (param.Length - post));
                }
                else
                {
                    param = param.Substring(pre);
                }
                postBool = false;
                pre = 0;
            }*/

            return param;
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
                ret = meanings[0];
            }
            else
            {
                return null;
            }

            for (int i = 1; i < meanings.Length; i++)
            {
                meanings[i] = RemoveSpacesFromEnds(meanings[i]);
                ret += (", " + meanings[i]);
            }

            return ret;
        }

        public static Grid GetListElement(string word)
        {
            Grid ret = new Grid();
            Label label = new Label();

            Thickness margin = new Thickness();
            margin.Left = 10;

            ret.Height = 45;
            ret.Margin = margin;
            ret.Tag = word;
            
            label.Content = word;
            label.Foreground = new SolidColorBrush(Colors.White);
            label.FontSize = 14;

            ret.MouseUp += DetailsOnWordEvent;

            ret.Children.Add(label);

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
            string tag = (string)((Grid)sender).Tag;
            
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