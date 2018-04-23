using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;

namespace HandyMan.Scripts
{
    public static class Central
    {
        static bool setup = false;
        public static void Setup()
        {
            if (!setup)
            {
                Ticker.StartTicking();

                LLproc.FunctionToCallOnce = MiscFunctions.SwapKeys;
            }

            setup = true;
        }
    }

    public class MiscFunctions
    {
        public static KeyRetyper KR = new KeyRetyper();

        public static void SwapKeys(int param)
        {            
            KeyPressSim.SimulateKeyOnForegroundWindow(KR.GetOutputVkey(param));
        }
    }
}
