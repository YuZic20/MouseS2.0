using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseS
{
    public class Profile
    {
        public string Name { get; set; }
        public int MouseSpeed { get; set; } // 1-20
        public int DubbleClick { get; set; }// 1 -5000
        public int ScrollSpeed { get; set; }// 1-50
    }
}
