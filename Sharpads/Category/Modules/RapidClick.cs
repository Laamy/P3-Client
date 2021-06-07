using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class RapidClick : Module
    {
        public RapidClick() : base("RapidHit", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.ci.lp.hitting = 0;
        }
    }
}
