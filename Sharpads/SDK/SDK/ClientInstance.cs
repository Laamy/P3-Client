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

        public Debug debug
        { get => new Debug(Pointers.debug); }

        public RakNetInstance rakNetInstance
        { get => new RakNetInstance(Pointers.rakNet); }

        public FloatOption floatOption
        { get => new FloatOption(Pointers.floatOption); }

        public Packet packet
        { get => new Packet(); }
    }
}
