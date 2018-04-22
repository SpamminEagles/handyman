using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HandyMan.Types;
namespace HandyMan.Scripts
{
    //This class is created with the information I found over here: https://blogs.msdn.microsoft.com/toub/2006/05/03/low-level-keyboard-hook-in-c/
    public static class LLproc
    {       

        #region DllImports
        //Stuff that will establish the Hook
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        //Stuff that will stop the already established hook!
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        //Stuff that will get the modulehandler
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        //Next hook in the chain
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        #endregion

        //Variables
        private const int WH_KEYBOARD_LL = 13;  //Constant that defines Hook mode of SetWindowsHookExt(), in this case it's a keyboard hook-a low level one! needed as a parameter
        public const int WM_KEYDOWN = 0x0100;   //#define-d in the cpp file - or header dunno' - now is needed as a parameter

        private static bool hookSet = false;    //readonly public via Property
        private static int latestPressedKey;

        private static IntPtr _hookId = IntPtr.Zero;
        private static LowLevelKeyboardProc Proc = CallbackHook;

        public static CallFunc FunctionToCallOne;

        

        #region Delegates&Properties        
        //Delegates
        private delegate IntPtr LowLevelKeyboardProc (int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void CallFunc(string param);

        //Propertites
        public static bool HookSet
        {
            get
            {
                return hookSet;
            }
        }

        public static char LatestPressedkey
        {
            get
            {
                return (char)latestPressedKey;
            }
        }
        #endregion
        
        //Functions
        public static void StartHook()
        {
            using (Process currentProcess = Process.GetCurrentProcess())
            using (ProcessModule currentModule = currentProcess.MainModule)
            {
                _hookId = SetWindowsHookEx(WH_KEYBOARD_LL, Proc, GetModuleHandle(currentModule.ModuleName), 0);
            }

            hookSet = true;
        }

        public static void StopHook()
        {
            if (hookSet)
            {
                UnhookWindowsHookEx(_hookId);
                hookSet = false;
            }
        }

        private static IntPtr CallbackHook(int nCode, IntPtr wParam, IntPtr lParam)
        {           

            if (wParam == (IntPtr)WM_KEYDOWN)
            {
                latestPressedKey = Marshal.ReadInt32(lParam);
            }

            //return CallNextHookEx(_hookId, nCode, wParam, lParam);
            return (IntPtr)1;
        }

    }
    
    public class KeyRetyper : Window
    {


        public static char Retype(char input, Languages languageTo = Languages.Russian)
        {
            switch (languageTo)
            {
                case Languages.Russian:
                    
                    break;
            }
            return 'a';
        }


        public int Listener (params string[] args)
        {
            ((TextBox)FindName(args[0])).Text = "" + LLproc.LatestPressedkey;
            return 0;
        }
    }
}
