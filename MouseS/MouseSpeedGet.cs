﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MouseS
{
    class MouseSpeedGet
    {

        

        public const UInt32 SPI_GETMOUSESPEED = 0x0070;


        [DllImport("User32.dll")]
        static extern bool SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            IntPtr pvParam,
            UInt32 fWinIni);
        public static unsafe int GetMouseSpeed()
        {

            uint speed;

            SystemParametersInfo(SPI_GETMOUSESPEED, 0, new IntPtr(&speed), 0);



            return Convert.ToInt32(Convert.ToInt32(speed));

        }

    }
}
