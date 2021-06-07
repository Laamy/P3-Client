using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK.SDK
{
    public class Minecraft
    {
        public static ClientInstance ci
        { get => new ClientInstance(null); }
        public static bool inGUI
        {
            get
            {
                return true;
                /*float toBoolean = MCM.m.ReadFloat(Statics.inGUI);
                if (toBoolean == 0)
                    return false;
                else return true;*/
            }
        }
    }
}
