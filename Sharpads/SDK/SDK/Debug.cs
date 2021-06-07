using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK.SDK
{
    public class Debug : Actor // Debugs not to useful but is in its own way lol
    {
        public Debug(string addr) : base(addr) { }

        public string getScene(int strSize) => mem.m.ReadString(addr + "6F4", "", strSize); // Return the scene lol
        public string gameVersion { get => mem.m.ReadString(addr + "59C", "", 16); }
        public bool IsScene(string strs)
        {
            if (getScene(strs.Length) == strs)
                return true;
            return false;
        }
    }
}
