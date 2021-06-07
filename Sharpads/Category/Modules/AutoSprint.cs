using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class AutoSprint : Module
    {
        public AutoSprint() : base("AutoSprint", CategoryHandler.registry.categories[1], (char)0x07, false) { }

        public override void onTick()
        {
            base.onTick();
            Minecraft.ci.lp.sprinting = 1;
        }
    }
}
