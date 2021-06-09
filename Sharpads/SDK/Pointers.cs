using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK
{
    public class Pointers
    {
        public static string hitting = "base+03FE4618,0,4D0,2A0,8,50"; //v1.17.0
        public static string localPlayer = "base+03FFFA98,0,50,138,"; //v1.17.0
        public static string floatOption = "base+03F58578,28,138,18"; //v1.17.0
        public static string sprinting = "base+03F108A0,98,138,E8,5C"; //v1.17.0

        public static int Camera_Hex = 0x140; // LocalPlayer v1.17.0
        public static int Step_Hex = 0x240;
        public static int Type_Hex = 0x410;
        public static int PositionX_Hex = 0x4D0;
        public static int VelocityX_Hex = 0x50C;
        public static int VelocityY_Hex = 0x510;
        public static int VelocityZ_Hex = 0x514;
        public static int SwingAn_Hex = 0x7A0;
        public static int Username_Hex = 0x920;
        public static int LookingEntityID_Hex = 0x10B8;
        public static int inWater_Hex = 0x265;
        public static int onGround_Hex = 0x1E0;
    }
}