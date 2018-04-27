using System;
using System.Collections;
using System.Collections.Generic;
namespace HandyMan.Types
{
    public enum TPartsOfSpeech { Noun, Verb, Adjective }
    public enum Languages { English, Russian, Hungarian}
    public enum Alphabet { RussianCirillyc}
    public enum RussianConjugation { Regular1, Regular2, Irregular }
    public enum FileStreams { RussianDictionary }

    [Serializable]
    public struct RussianAdjective
    {
        public string Word;

        public string[] Meanings;

        public string Masculine;
        public string Feminine;
        public string Neuter;

        public IEnumerator<string> GetEnumerator()
        {
            List<string> ret = new List<string>();

            ret.Add(Word);
            ret.Add(Masculine);
            ret.Add(Feminine);
            ret.Add(Neuter);

            foreach(string i in Meanings)
            {
                ret.Add(i);
            }

            return ret.GetEnumerator();
        }
    }

    [Serializable]
    public struct RussianVerb
    {
        public RussianContinousVerb Continous;
        public RussianPerfectVerb Perfect;
        public string[] Meanings;

        public IEnumerator<string> GetEnumerator()
        {
            List<string> ret = new List<string>();

            ret.Add(Continous.Word);
            ret.Add(Perfect.Word);

            if (Continous.Conjugation == RussianConjugation.Irregular)
            {
                ret.Add(Continous.S1);
                ret.Add(Continous.S2);
                ret.Add(Continous.P3);
            }

            ret.Add(Perfect.S1);
            ret.Add(Perfect.S2);
            ret.Add(Perfect.P3);

            ret.AddRange(Meanings);

            return ret.GetEnumerator();
        }
    }

    [Serializable]
    public struct RussianContinousVerb
    {
        public string Word;

        public RussianConjugation Conjugation;

        string s1;
        string s2;
        string p3;

        public string S1
        {
            get
            {
                switch (Conjugation)
                {
                    case RussianConjugation.Irregular:
                        return s1;
                    case RussianConjugation.Regular1:
                        return "Regular 1";
                    case RussianConjugation.Regular2:
                        return "Regular 2";
                    default:
                        return "N/A";
                }
            }
            set
            {
                if(Conjugation == RussianConjugation.Irregular)
                {
                    s1 = value;
                }
            }
        }

        public string S2
        {
            get
            {
                switch (Conjugation)
                {
                    case RussianConjugation.Irregular:
                        return s2;
                    case RussianConjugation.Regular1:
                        return "Regular 1";
                    case RussianConjugation.Regular2:
                        return "Regular 2";
                    default:
                        return "N/A";
                }
            }
            set
            {
                if (Conjugation == RussianConjugation.Irregular)
                {
                    s2 = value;
                }
            }
        }

        public string P3
        {
            get
            {
                switch (Conjugation)
                {
                    case RussianConjugation.Irregular:
                        return p3;
                    case RussianConjugation.Regular1:
                        return "Regular 1";
                    case RussianConjugation.Regular2:
                        return "Regular 2";
                    default:
                        return "N/A";
                }
            }
            set
            {
                if (Conjugation == RussianConjugation.Irregular)
                {
                    p3 = value;
                }
            }
        }
    }

    [Serializable]
    public struct RussianPerfectVerb
    {
        public string Word;

        public string S1;
        public string S2;
        public string P3;
    }

    [Serializable]
    public struct RussianNoun
    {
        public string Word;
        public string Plural;
        public string[] Meanings;

        public IEnumerator<string> GetEnumerator()
        {
            List<string> ret = new List<string>();

            ret.Add(Word);

            foreach (string i in Meanings)
            {
                ret.Add(i);
            }

            return ret.GetEnumerator();
        }
    }
}