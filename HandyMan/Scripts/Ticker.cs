using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HandyMan.Scripts
{
    class Ticker
    {
        private static int tickLength = 50;
        private static Dictionary<TickSlice, string[]> Slices = new Dictionary<TickSlice, string[]>();
        private static Timer Clock  = new Timer();

        private static void Tick(Object sender, ElapsedEventArgs e)
        {
            TickSlice CurrentSlice;
            foreach (KeyValuePair<TickSlice, string[]> i in Slices)
            {
                CurrentSlice = i.Key;
                CurrentSlice(i.Value);                
            }
        }        

        public static void StartTicking ()
        {
            Clock.AutoReset = true;
            Clock.Interval = tickLength;
            Clock.Elapsed += Tick;
            Clock.Enabled = true;
        }

        public static void StopTicking()
        {
            Clock.Elapsed -= Tick;
            Clock.Enabled = false;
        }

        public static int AddTickSlice(TickSlice del, params string[] Args)
        {
            try
            {                
                Slices.Add(del, Args);
                return (Slices.Count - 1);
            }catch (Exception E)
            {
                return -1;
            }

        }

        public static bool RemoveTickSlice(int TickID)
        {
            try
            {                
                Slices.Remove(Slices.Keys.ToArray()[TickID]);
            }
            catch
            {
                return false;
            }
            return true;
        }

        #region Definitions
        public delegate int TickSlice(params string[] Args);
        public int TICK_LENGTH
        {
            get
            {
                return tickLength;
            }
        }
        #endregion
    }
}
