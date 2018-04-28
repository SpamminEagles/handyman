using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using HandyMan.Scripts;
using HandyMan.Types;

namespace HandyMan.Scripts
{
    public static class Central
    {
        #region System variables
        static bool setup = false;
        static bool fileStreamBusy = false;
        static KeyRetyper KR = new KeyRetyper();
        public static bool LCInternal = false;  //Switch for the temporary Latin>Cyrillic replacer, until the system level solution works

        static FileStream RussianDictionaryFS;
        
        public static bool FileStreamBusy
        {
            get
            {
                return fileStreamBusy;
            }
        }
        #endregion

        public static void Setup()
        {
            if (!setup)
            {
                Ticker.StartTicking();

                LLproc.FunctionToCallOnce = KR.TriggerTransfomedKey;
                OpenFS();
            }

            setup = true;

            LoadDictionaries(Languages.Russian);            
        }

        public static void Shutdown()
        {
            RequestCentralRelease();
            SaveDictionaries(Languages.Russian);
            Application.Current.Shutdown();
        }

        public static bool SaveDictionaries(Languages dictionary)
        {
            string path = Database.Settings.SavePath;
            switch (dictionary)
            {
                case Languages.Russian:
                    path += @"\russianDictionary.dic";
                    break;
            }

            try
            {
                RequestCentralRelease();
                FileStream FS = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite);
                BinaryFormatter BF = new BinaryFormatter();

                BF.Serialize(FS, Database.RussianDictionary);
                FS.Close();
                Reopen();
                return true;
            }catch (Exception E)
            {
                return false;
            }
        }

        public static bool LoadDictionaries(Languages dictionary)
        {
            try
            {
                if (!fileStreamBusy)
                {
                    FileStream FS = RequestFileStream(FileStreams.RussianDictionary);
                    BinaryFormatter BF = new BinaryFormatter();

                    Database.RussianDictionary = (RD)BF.Deserialize(FS);
                    RelaseFS(false);
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (Exception E)
            {
                return false;
            }
        }

        public static FileStream RequestFileStream(FileStreams requested)
        {
            if (fileStreamBusy)
            {
                return null;
            }
            else
            {
                switch (requested)
                {
                    case FileStreams.RussianDictionary:
                        return RussianDictionaryFS;

                    default:
                        return null;
                }

            }
        }

        public static void RelaseFS(bool reopen = true)
        {
            fileStreamBusy = false;
            if (reopen)
            {
                Reopen();
            }
        }

        static void OpenFS()
        {
            if (!Directory.Exists(Database.Settings.SavePath))
            {
                Directory.CreateDirectory(Database.Settings.SavePath);
            }
            if (!File.Exists(Database.Settings.SavePath + @"\russianDictionary.dic"))
            {
                FileStream FS = new FileStream(Database.Settings.SavePath + @"\russianDictionary.dic", FileMode.Create);
                FS.Close();
            }
            Reopen();
        }

        static void RequestCentralRelease()
        {
            try
            {
                RussianDictionaryFS.Close();
            }catch(Exception E)
            {

            }
        }
        static void Reopen(bool release = true)
        {
            if (release)
            {
                RequestCentralRelease();
            }
            RussianDictionaryFS = new FileStream(Database.Settings.SavePath + @"\russianDictionary.dic", FileMode.Open, FileAccess.ReadWrite);
        }
    }
}

namespace HandyMan
{
    public static class Database
    {
        public static class Settings
        {
            public static string SavePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\HandyMan\";
        }

        public static RD RussianDictionary = new RD();
        
    }

    [Serializable]
    public class RD
    {
        List<RussianNoun> Nouns = new List<RussianNoun>();
        List<RussianAdjective> Adjectives = new List<RussianAdjective>();
        List<RussianVerb> Verbs = new List<RussianVerb>();

        //Adjective
        public void AddAdjective(RussianAdjective data)
        {
            Adjectives.Add(data);
        }

        public void RemoveAdjective(RussianAdjective data)
        {
            Adjectives.Remove(data);
        }

        public bool ContainsAdjective(RussianAdjective data)
        {
            return Adjectives.Contains(data);
        }

        public RussianAdjective[] FindAdjectives(string word)
        {
            if (word == "*")
            {
                return Adjectives.ToArray();
            }
            else if (word == "")
            {
                return new RussianAdjective[0];
            }

            List<RussianAdjective> ret = new List<RussianAdjective>();

            foreach (RussianAdjective i in Adjectives)
            {
                foreach (string j in i)
                {
                    if (j.Contains(word))
                    {
                        ret.Add(i);
                        continue;
                    }
                }
            }

            return ret.ToArray();
        }

        //Verbs
        public void AddVerb(RussianVerb data)
        {
            Verbs.Add(data);
        }

        public void RemoveVerb(RussianVerb data)
        {
            Verbs.Remove(data);
        }

        public bool ContainsVerb(RussianVerb data)
        {
            return Verbs.Contains(data);
        }

        public RussianVerb[] FindVerbs(string word)
        {
            if (word == "*")
            {
                return Verbs.ToArray();
            }
            else if (word == "")
            {
                return new RussianVerb[0];
            }

            List<RussianVerb> ret = new List<RussianVerb>();

            foreach (RussianVerb i in Verbs)
            {
                foreach (string j in i)
                {
                    if (j.Contains(word))
                    {
                        ret.Add(i);
                        continue;
                    }
                }
            }

            return ret.ToArray();
        }

        //Nouns
        public void AddNoun(RussianNoun data)
        {
            Nouns.Add(data);
        }

        public void RemoveNoun(RussianNoun data)
        {
            Nouns.Remove(data);
        }

        public bool ContainsNoun(RussianNoun data)
        {
            return Nouns.Contains(data);
        }

        public RussianNoun[] FindNouns(string word)
        {
            if (word == "*")
            {
                return Nouns.ToArray();
            }
            else if (word == "")
            {
                return new RussianNoun[0];
            }

            List<RussianNoun> ret = new List<RussianNoun>();

            foreach (RussianNoun i in Nouns)
            {
                foreach (string j in i)
                {
                    if (j.Contains(word))
                    {
                        ret.Add(i);
                        continue;
                    }
                }
            }

            return ret.ToArray();
        }



        //Misc:
        public string CreateMeaningString(string[] meanings)
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

        public string RemoveSpacesFromEnds(string param)
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

        public string[] SplitMeanings(string meanings)
        {

            //Make sure first if it contains anything
            if (meanings == "" || meanings == null)
            {
                return null;
            }
            else if (!(meanings.Contains(",") || meanings.Contains(";")))
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

    }
}
