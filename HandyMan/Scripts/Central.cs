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
        #region Setup and main variables
        static bool setup = false;
        static KeyRetyper KR = new KeyRetyper();
        #endregion

        public static void Setup()
        {
            if (!setup)
            {
                Ticker.StartTicking();

                LLproc.FunctionToCallOnce = KR.TriggerTransfomedKey;
            }

            setup = true;
        }

    }

    public class MiscFunctions
    {
        public static KeyRetyper KR = new KeyRetyper();

        public static void SwapKeys(int param)
        {            
            //KeyPressSim.SimulateKeyOnForegroundWindow(KR.GetOutputVkey(param));
        }
    }
}
