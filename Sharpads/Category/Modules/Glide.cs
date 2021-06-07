using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class Glide : Module
    {
        public Glide() : base("Glide", CategoryHandler.registry.categories[2], (char)0x07, false) { }

        public override void onTick()
        {
            base.onTick();
            Minecraft.ci.lp.velY = 0;
        }
    }
}
