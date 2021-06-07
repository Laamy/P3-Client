using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpads.Category.Modules
{
    public class FixHitbox : Module
    {
        public FixHitbox() : base("FixHitbox", CategoryHandler.registry.categories[4], (char)0x07, false)
        {
        }

        public override void onEnable() // Setup noclip
        {
            onDisable();
            Minecraft.ci.lp.teleport(Minecraft.ci.lp.X1, Minecraft.ci.lp.Y1, Minecraft.ci.lp.Z1);
        }
    }
}
