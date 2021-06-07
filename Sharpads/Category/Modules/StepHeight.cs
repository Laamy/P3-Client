using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class StepHeight : Module
    {
        public StepHeight() : base("Step", CategoryHandler.registry.categories[2], (char)0x07, false) { }

        public override void onTick()
        {
            base.onTick();
            Minecraft.ci.lp.stepHeight = 1F;
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.ci.lp.stepHeight = 0.52f;
        }
    }
}
