using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MouseS
{
    class GetDubbleClick
    {
        public const UInt32 SPI_GETMOUSESPEED = 0x0070;


        [DllImport("User32.dll")]
        static extern uint GetDoubleClickTime();
        public static unsafe int GetClickSpeed()
        {

            uint speed;

            speed = GetDoubleClickTime();

            

            return Convert.ToInt32(Convert.ToInt32(speed));

        }
    }
}
