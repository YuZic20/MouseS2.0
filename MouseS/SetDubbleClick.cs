using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MouseS
{
    class SetDubbleClick
    {
        public const UInt32 SPI_SETDOUBLECLICKTIME = 0x0020;




        [DllImport("User32.dll")]
        static extern bool SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            UInt32 pvParam,
            UInt32 fWinIni);


        public static void SetClickSpeed(int speed)
        {
            if (speed <= 5000 && speed >= 1)
            {
                
                SystemParametersInfo(SPI_SETDOUBLECLICKTIME, (UInt32)Convert.ToUInt32(speed),0, 0);

            }

        }
    }
}
