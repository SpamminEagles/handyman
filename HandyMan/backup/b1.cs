//Edit: backup files contain not working/buggy code, but I worked too much on them to just throw them out.


/*
     public class KeyRetyper
    {
        #region DLL-Import
        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);
        [DllImport("user32.dll")]
        private static extern short VkKeyScanEx(char ch, int dwHKL);
        [DllImport("user32.dll")]
        static extern int MapVirtualKey(uint uCode, uint uMapType);
        [DllImport("user32.dll")]
        static extern int MapVirtualKeyEx(uint uCode, uint uMapType, int dwHKL);
        [DllImport("user32.dll")]
        static extern int LoadKeyboardLayout(int pwszKLID, uint flags);
        #endregion

        #region Declarations
        //The input type is the alphabet that we get the data, the target output is the alphabet in which we want the result
        Languages InputType = Languages.Hungarian;  
        Languages TargetOutput = Languages.Russian;

        public const int RUSSIAN_HKL = 0x0419;
        public const int HUNGARIAN_HKL = 0x040E;
        public const int ENGLISH_HKL = 0x0809;
        public const uint KLF_ACTIVATE = 0x00000001;

        private int CurrentInputHKL = HUNGARIAN_HKL;
        private int CurrentOutputHKL = RUSSIAN_HKL;

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
        public KeyRetyper(Languages Input = Languages.Hungarian, Languages Output = Languages.Russian)
        {
            ReInitialize(Input, Output);
        }

        public bool ReInitialize(Languages Input, Languages Output)
        {
            InputType = Input;
            TargetOutput = Output;

            CurrentInputHKL = GetHKL(Input);
            CurrentOutputHKL = GetHKL(Output);

            SetParsers();
            CollecDictionary();

            return true; //If I later want to add feedback on success
        }


        public int GetHKL(Languages lang)
        {
            switch (lang)
            {
                case Languages.Hungarian:
                    return LoadKeyboardLayout(HUNGARIAN_HKL, KLF_ACTIVATE);
                case Languages.English:
                    return LoadKeyboardLayout(ENGLISH_HKL, KLF_ACTIVATE);
                case Languages.Russian:
                    return LoadKeyboardLayout(RUSSIAN_HKL, KLF_ACTIVATE);

                default:
                    return ENGLISH_HKL;
            }
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
            return Convert.ToChar(MapVirtualKeyEx((uint)Vkey, 2, CurrentInputHKL));
        }

            //Output parsers    


        int VkeyParser(char character)
        {
            return VkKeyScanEx(character, CurrentOutputHKL);
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
            //return 'я';
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
            return VkeyParser(
                                    ConvertKey(InputCharacter));
        }

        public void GetOutputVkey(int InputVkey)
        {
            //return VkeyParser(
            //ConvertKey(InputVkey));
            //return VkKeyScan(Convert.ToChar(MapVirtualKey((uint)InputVkey, 2)));

            //return VkKeyScan('a');
}

#endregion
}*/