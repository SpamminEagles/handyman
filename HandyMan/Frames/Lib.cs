using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HandyMan.Types;

namespace Handyman.Frames.Dictionary.Lib
{
    public static class Lib
    {
        static RussianAdjective[] ResultsRA;
        static RussianNoun[] ResultsRN;
        static RussianVerb[] ResultsRV;

        public static string[] SplitMeanings(string meanings)
        {
            string[] ret = meanings.Split(',', ';');

            //Make sure first if it contains anything
            if (meanings == "" || meanings == null)
            {
                return null;
            }

            for (int i = 0; i < ret[i].Length; i++)
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
                for (int k = param.Length; k > -1; k--)
                {
                    if (param[k] != ' ')
                    {
                        post = k;
                        postBool = true;
                    }
                }
            }

            //Let's chop off:
            if (pre != 0 || postBool)
            {
                param = param.Substring(pre, param.Length - post);
                postBool = false;
                pre = 0;
            }

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

        public static Grid GetListElement(string word, int tag)
        {
            Grid ret = new Grid();
            Label label = new Label();

            Thickness margin = new Thickness();
            margin.Left = 10;

            ret.Height = 45;
            ret.Margin = margin;
            ret.Tag = tag;
            
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
                ret.Add(CreateMeaningString(i.Continous.Meanings));
                ret.Add(CreateMeaningString(i.Perfect.Meanings));
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
                ret.Add(i.Continous.Word);
                ret.Add(i.Perfect.Word);
            }

            return ret.ToArray();
        }

        private static void DetailsOnWordEvent(object sender, RoutedEventArgs e)
        {

        }
    }
}