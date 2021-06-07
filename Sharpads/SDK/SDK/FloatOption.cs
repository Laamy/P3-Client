using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK.SDK
{
    public class FloatOption : SDKObject
    {
        public FloatOption(string addr) : base(addr) { }

        public float playerFOV
        {
            get => mem.m.ReadFloat(addr.ToString());
            set => mem.m.WriteMemory(addr.ToString(), "float", value.ToString());
        }
    }
}
