using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK.SDK
{
    public class VanillaInput : SDKObject
    {
        public VanillaInput(string addr) : base(addr) { }

        public int hitting
        {
            get => mem.m.ReadByte(addr + Pointers.hitting_Hex.ToString("X"));
            set => mem.m.WriteMemory(addr + Pointers.hitting_Hex.ToString("X"), "byte", value.ToString());
        }

        public int placing
        {
            get => mem.m.ReadByte(addr + (Pointers.hitting_Hex + 1).ToString("X"));
            set => mem.m.WriteMemory(addr + (Pointers.hitting_Hex + 1).ToString("X"), "byte", value.ToString());
        }
    }
}
