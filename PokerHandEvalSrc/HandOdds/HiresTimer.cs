// This application is covered by the LGPL Gnu license. See http://www.gnu.org/copyleft/lesser.html 
// for more information on this license.
using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;

namespace HandOdds
{
    /// <summary>
    /// This class is used to make high resolution timing measurements
    /// </summary>
    public class HiPerfTimer
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        /// <exclude/>
        private double startTime;
        /// <exclude/>
        private long freq;

        /// <summary>
        /// Constructor
        /// </summary>
        public HiPerfTimer()
        {
            startTime = 0.0;

            if (QueryPerformanceFrequency(out freq) == false)
            {
                // high-performance counter not supported 
                throw new Win32Exception();
            }
        }

        /// <summary>
        /// Returns current time value as a double. This value is only
        /// useful for makeing relative time measurements. The relationship of
        /// this value to system time is unknown.
        /// </summary>
        public double CurrentTime
        {
            get {
                long time;
                QueryPerformanceCounter(out time);
                return ((double) time)/((double) freq);
            }
        }

        /// <summary>
        /// Used to mark the start of a time duration measurement
        /// </summary>
        public void Start()
        {
            startTime = CurrentTime;
        }

       /// <summary>
       /// Retreives time since the last time Start() was called.
       /// </summary>
        public double Duration
        {
            get
            {
                return (CurrentTime - startTime);
            }
        }
    }
}

