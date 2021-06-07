using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class Jesus : Module
    {
        public Jesus() : base("Jesus", CategoryHandler.registry.categories[2], (char)0x07, false) { }

        public override void onTick()
        {
            base.onTick();
            if (Minecraft.ci.lp.inWater)
            {
                Minecraft.ci.lp.velY = 0.1f;
                Minecraft.ci.lp.onGround = 1;
            }
        }
    }
}
