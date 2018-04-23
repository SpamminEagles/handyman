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
        [DllImport("user32.dll")]
        static extern int MapVirtualKey(uint uCode, uint uMapType);
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
        public Dictionary<char, char> CharDictionary = KeyDictionaries.CirillycLatinKeys;

        #endregion

        //Contains constructor
        #region Initializers
        public KeyRetyper(Languages Input = Languages.English, Languages Output = Languages.Russian)
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
            ParseInputChar = InputCharParser;                    

            //Parse output            
            ParseOutputVkey = VkeyParser;
                    
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
        char InputCharParser(int Vkey)
        {
            return Convert.ToChar(MapVirtualKey((uint)Vkey, 2));
        }

            //Output parsers    
        int VkeyParser(char character)
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
            else
            {
                return 'a';
            }
            return 'я';
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
        public char ConvertKey(int Vkey)
        {
            return 
                ParseTargetChar(
                                ParseInputChar(Vkey));
        }

        public char ConvertKey(char character) {
            return ParseTargetChar(character);
        }

        public int GetOutputVkey(char InputCharacter)
        {
            return ParseOutputVkey(
                                    ConvertKey(InputCharacter));
        }

        public int GetOutputVkey(int InputVkey)
        {
            return ParseOutputVkey(
                                    ConvertKey(InputVkey));
            //return VkKeyScan(Convert.ToChar(MapVirtualKey((uint)InputVkey, 2)));
        }

        #endregion
    }

    
}
