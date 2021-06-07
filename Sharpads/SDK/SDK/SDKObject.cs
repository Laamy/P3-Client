using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK.SDK
{
    public abstract class SDKObject
    {
        public string addr;
        public SDKObject(string addr) => this.addr = addr;
    }
}
