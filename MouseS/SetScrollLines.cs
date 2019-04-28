using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MouseS
{
    class SetScrollLines
    {
        public const UInt32 SPI_SETWHEELSCROLLLINES = 0x0069;




        [DllImport("User32.dll")]
        static extern bool SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            UInt32 pvParam,
            UInt32 fWinIni);


        public static void SetLineSpeed(int speed)
        {
            if (speed <= 50 && speed >= 1)
            {

                SystemParametersInfo(SPI_SETWHEELSCROLLLINES, (UInt32)Convert.ToUInt32(speed), 0, 0);

            }

        }
    }
}
