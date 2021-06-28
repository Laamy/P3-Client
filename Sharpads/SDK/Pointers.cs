using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK
{
    public class Pointers
    {
        public static string // Pointers for v1.17.0
            vanillaInput = "base+03FE4618,0,4D0,2A0,8,",
            localPlayer = "base+04020228,0,18,B8,", // Uv1.17.2
            sprinting = "base+03F11820,98,138,F0,8,1C0,8,9EC"; // Uv1.17.2

        public static int // LocalPlayer v1.17.2 offsets
            Camera_Hex = 0x140,
            Step_Hex = 0x240,
            Type_Hex = 0x410,
            PositionX_Hex = 0x4D0,
            VelocityX_Hex = 0x50C,
            SwingAn_Hex = 0x7A0,
            Username_Hex = 0x920,
            LookingEntityID_Hex = 0x10B8,
            inWater_Hex = 0x265,
            onGround_Hex = 0x1E0;

        public static int // VanillaInput 1.17.2 offsets
            hitting_Hex = 0x50,
            placing_Hex = 0x51;
    }
}