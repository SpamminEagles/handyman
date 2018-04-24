using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Input;
using HandyMan.Types;

namespace HandyMan.Scripts
{
    public class KeyRetyper
    {
        #region Declarations
        //The input type is the alphabet that we get the data, the target output is the alphabet in which we want the result
        Languages InputType = Languages.Hungarian;  
        Languages TargetOutput = Languages.Russian;

        //The dictionary to use:
        public Dictionary<char, char> CharDictionary = KeyDictionaries.CirillycLatinKeys;
        private char[] KeyArray;
        #endregion

        //Contains constructor
        #region Initializers
        public KeyRetyper(Languages Input = Languages.Hungarian, Languages Output = Languages.Russian)
        {
            ReInitialize(Input, Output);
        }

        public bool ReInitialize(Languages Input, Languages Output)
        {
            InputType = Input;
            TargetOutput = Output;
            
            CollecDictionary();
            KeyArray = new char[CharDictionary.Count];
            CharDictionary.Keys.CopyTo(KeyArray, 0);

            return true; //If I later want to add feedback on success
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

        #region Where the magic happens
        public int SwapKeys(int Vkey)
        {
            return
            //Get the VKey (char->key->VKey)
            KeyInterop.VirtualKeyFromKey(
                //Get the transformed char
                (Key)ParseTargetChar(
                    //Get the char to convert (VKey->Key->char)
                    (char)KeyInterop.KeyFromVirtualKey(Vkey)));
        }

        public void TriggerTransfomedKey(int VKey)
        {
            if (CheckIfToTransform(VKey))
            {
                KeyPressSim.SimulateKeyOnForegroundWindow(SwapKeys(VKey));
            }
            else
            {
                KeyPressSim.SimulateKeyOnForegroundWindow(VKey);
            }
        }

        char ParseTargetChar(char InputChar)
        {
            //return CharDictionary[InputChar];
            return 'б';
        }

        //If the user presses a key that is not part of the transformation table, it should be called without a touch
        public bool CheckIfToTransform(int VKey)
        {
            foreach (char i in KeyArray)
            {
                if( i == (char)KeyInterop.KeyFromVirtualKey(VKey))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
