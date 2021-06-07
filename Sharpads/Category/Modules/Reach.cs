using Sharpads.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class Reach : Module
    {
        public Reach() : base("Reach", CategoryHandler.registry.categories[0], (char)0x07, false) { }

        public override void onEnable()
        {
            base.onEnable();
            mem.m.WriteMemory(Statics.reach, "float", "7");
        }

        public override void onTick()
        {
            base.onTick();
            mem.m.WriteMemory(Statics.reach, "float", "7");
        }

        public override void onDisable()
        {
            base.onDisable();
            mem.m.WriteMemory(Statics.reach, "float", "3");
        }
    }
}
