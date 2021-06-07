using Sharpads.SDK;
using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class Nightmode : Module
    {
        public Nightmode() : base("Nightmode", CategoryHandler.registry.categories[3], (char)0x07, false) { }

        public override void onTick()
        {
            base.onTick();
            mem.m.WriteMemory(Pointers.time, "int", "20000");
        }
    }
}
