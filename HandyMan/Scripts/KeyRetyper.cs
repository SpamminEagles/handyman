using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HandyMan.Types;

namespace HandyMan.Scripts
{
    //This class is created with the information I found over here: https://blogs.msdn.microsoft.com/toub/2006/05/03/low-level-keyboard-hook-in-c/
    
    
    public class KeyRetyper
    {
        #region DLL-Import
        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);
        #endregion

        #region Declarations
        //The input type is the alphabet that we get the data, the target output is the alphabet in which we want the result
        Languages InputType = Languages.English;  
        Languages TargetOutput = Languages.Russian;        

        //The delegates I can later use easily to convert anything to the proper form
        public delegate char ParseCharType (int Vkey);
        ParseCharType ParseInputChar;
        public delegate int ParseVkeyType(char character);
        ParseVkeyType ParseOutputVkey;

        //The dictionary to use:
        public Dictionary<char, char> CharDictionary;

        #endregion

        //Contains constructor
        #region Initializers
        public KeyRetyper(Languages Input, Languages Output)
        {
            ReInitialize(Input, Output);
        }

        public bool ReInitialize(Languages Input, Languages Output)
        {
            InputType = Input;
            TargetOutput = Output;

            SetParsers();
            CollecDictionary();

            return true; //If I later want to add feedback on success
        }

        //Get the proper parsers
        void SetParsers()
        {
            //Parse input
            switch (InputType)
            {
                case Languages.English:
                    ParseInputChar = LatinCharParser;
                    break;
                case Languages.Russian:
                    InputType = Languages.English;
                    ParseInputChar = LatinCharParser;
                    break;

                default:
                    InputType = Languages.English;
                    ParseInputChar = LatinCharParser;
                    break;
            }

            //Parse output
            switch (TargetOutput)
            {
                case Languages.Russian:
                    ParseOutputVkey = CirillicVkeyParser;
                    break;

                default:
                    ParseOutputVkey = CirillicVkeyParser;
                    break;
                  
            }
        }

        //Get the dictionary we actually need for converting characters between alphabets
        void CollecDictionary()
        {
            if (InputType == Languages.English && TargetOutput == Languages.Russian)
            {
                CharDictionary = KeyDictionaries.CirillycLatinKeys;
            }
            else   //A "default" block
            {
                CharDictionary = KeyDictionaries.CirillycLatinKeys;
            }
        }

        #endregion

        #region Converter functions (Parsers)

        //Input Parsers
        char LatinCharParser(int Vkey)
        {
            return KeyDictionaries.LatinVkeyReversed[Vkey];
        }

            //Output parsers
        int LatinVkeyParser(char character)
        {
            return KeyDictionaries.LatinVkey[character];
        }

        int CirillicVkeyParser(char character)
        {
            return VkKeyScan(character);
        }
        
            //Midway

        char ParseTargetChar (char InputChar)
        {
            if (VerifyCharacter(InputChar))
            {
                return CharDictionary[InputChar];
            }
            return 'a';
        }

        #endregion

        #region Helpers
        //Verify that this character is actually part the Dictionaries
        public static bool VerifyCharacter(char character)
        {
            return true;
        }
        #endregion

        #region Actual-Converting
        public char ConvertKey(int Key)
        {
            return 
                ParseTargetChar(
                                ParseInputChar(Key));
        }

        public char ConvertKey(char character) {
            return ParseTargetChar(character);
        }

        public int GetOutputVkey(char InputCharacter)
        {
            return ParseOutputVkey(
                                    ConvertKey(InputCharacter));
        }

        public int GetoutputVkey(int InputVkey)
        {
            return ParseOutputVkey(
                                    ConvertKey(InputVkey));
        }

        #endregion
    }
}
