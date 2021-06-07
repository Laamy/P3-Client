using Sharpads.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class Velocity : Module
    {
        private int KB;

        public Velocity() : base("Velocity", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
            KB = mem.m.ReadByte(Statics.Knockback_X);
            if (KB == 0) KB = 137;
        }

        public override void onEnable()
        {
            base.onEnable();
            mem.m.WriteMemory(Statics.Knockback_X, "byte", "0"); // cut the knockback support smh
            mem.m.WriteMemory(Statics.Knockback_Y, "byte", "0");
            mem.m.WriteMemory(Statics.Knockback_Z, "byte", "0");
        }

        public override void onDisable()
        {
            base.onDisable();
            mem.m.WriteMemory(Statics.Knockback_X, "byte", KB.ToString()); // restore the old knockback value :D
            mem.m.WriteMemory(Statics.Knockback_Y, "byte", KB.ToString());
            mem.m.WriteMemory(Statics.Knockback_Z, "byte", KB.ToString());
        }
    }
}
