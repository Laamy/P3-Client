using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK.SDK
{
    public class RakNetInstance : SDKObject
    {
        public RakNetInstance(string addr) : base(addr) { }

        public string connectedServerIP
        { get => mem.m.ReadString(addr + "0", "", 30); }
    }
}
