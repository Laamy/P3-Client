using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class NoSwing : Module
    {
        public NoSwing() : base("NoSwing", CategoryHandler.registry.categories[3], (char)0x07, false) { }

        public override void onTick()
        {
            base.onTick();
            Minecraft.ci.lp.swingingAnimation = 4;
        }
    }
}
