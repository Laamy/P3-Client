using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK.SDK
{
    public class ClientInstance : SDKObject
    {
        public ClientInstance(string addr) : base(addr) { }

        public LocalPlayer lp
        { get => new LocalPlayer(Pointers.localPlayer); }

        public Packet packet
        { get => new Packet(); }
    }
}
