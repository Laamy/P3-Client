using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class Phase : Module
    {
        public Phase() : base("Phase", CategoryHandler.registry.categories[4], (char)0x07, false)
        {
        }

        public override void onEnable()
        {
            base.onEnable();
            Minecraft.ci.lp.Y2 = Minecraft.ci.lp.Y1;
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.ci.lp.teleport(Minecraft.ci.lp.X1, Minecraft.ci.lp.Y1, Minecraft.ci.lp.Z1);
        }
    }
}
