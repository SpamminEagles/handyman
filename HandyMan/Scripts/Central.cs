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
            }

            setup = true;
            //OpenFS();
        }

        public static bool SaveDictionaries(Languages dictionary)
        {
            try
            {
                RequestCentralRelease();
                FileStream FS = new FileStream(Database.Settings.SavePath + @"dictionaries.dic", FileMode.Truncate, FileAccess.ReadWrite);
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
            if (!File.Exists(Database.Settings.SavePath += @"\russianDictionary.dic"))
            {
                File.Create(Database.Settings.SavePath += @"\russianDictionary.dic");
            }
            Reopen(false);
        }

        static void RequestCentralRelease()
        {
            RussianDictionaryFS.Close();
        }
        static void Reopen(bool release = true)
        {
            if (release)
            {
                RequestCentralRelease();
            }
            RussianDictionaryFS = new FileStream(Database.Settings.SavePath += @"\russianDictionary.dic", FileMode.Open, FileAccess.ReadWrite);
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
            List<RussianAdjective> ret = new List<RussianAdjective>();

            foreach (RussianAdjective i in Adjectives)
            {
                //if (i.Word.Contains(word) || i.Masculine.Contains(word) || i.Feminine.cont
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
            List<RussianVerb> ret = new List<RussianVerb>();

            foreach (RussianVerb i in Verbs)
            {
                //if (i.Word.Contains(word) || i.Masculine.Contains(word) || i.Feminine.cont
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
            List<RussianNoun> ret = new List<RussianNoun>();

            foreach (RussianNoun i in Nouns)
            {
                //if (i.Word.Contains(word) || i.Masculine.Contains(word) || i.Feminine.cont
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

    }
}
