using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MouseS
{
    class GetScrollLines
    {
        public const UInt32 SPI_GETWHEELSCROLLLINES = 0x0068;


        [DllImport("User32.dll")]
        static extern bool SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            IntPtr pvParam,
            UInt32 fWinIni);
        public static unsafe int GetSpeed()
        {

            uint speed;

            SystemParametersInfo(SPI_GETWHEELSCROLLLINES, 0, new IntPtr(&speed), 0);



            return Convert.ToInt32(Convert.ToInt32(speed));

        }
    }
}
