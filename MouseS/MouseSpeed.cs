using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseS
{
    static class MouseSpeed
    {
        public const UInt32 SPI_SETMOUSESPEED = 0x0071;




        [DllImport("User32.dll")]
        static extern bool SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            UInt32 pvParam,
            UInt32 fWinIni);


        public static void SetMouseSpeed ( int speed)
        {
            if(speed <= 20 && speed >= 1)
            {
                
                SystemParametersInfo(SPI_SETMOUSESPEED, 0, (UInt32)Convert.ToUInt32(speed), 0);
            }
            
        }
        
    }
}
