using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class BounceFly : Module
    {
        public BounceFly() : base("BounceFly", CategoryHandler.registry.categories[1], (char)0x07, false) { }

        public override void onTick()
        {
            base.onTick();
            if (Minecraft.ci.lp.velY <= -0.5F) Minecraft.ci.lp.velY = 0.5F;
        }
    }
}
