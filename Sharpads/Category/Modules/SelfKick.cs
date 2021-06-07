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
    public class SelfKick : Module
    {
        public SelfKick() : base("SelfKick", CategoryHandler.registry.categories[4], (char)0x07, false)
        {
        }

        public override void onEnable() // Setup noclip
        {
            base.onEnable();
            Minecraft.ci.lp.Y1 = Minecraft.ci.lp.Y2;
            Thread.Sleep(250);
            Minecraft.ci.lp.Y1 = Minecraft.ci.lp.Y2;
        }

        int tickmodule = 0;

        public override void onTick()
        {
            base.onTick();
            if (tickmodule == 3) Minecraft.ci.lp.velY = 6f;
            if (tickmodule == 6)
            {
                Minecraft.ci.lp.velY = -3f;
                tickmodule = 0;
            }
            tickmodule++;
            float calcYaw = (Minecraft.ci.lp.yaw + 90) * ((float)Math.PI / 180F);
            Minecraft.ci.lp.velX = (float)Math.Cos(calcYaw) * 2f;
            Minecraft.ci.lp.velZ = (float)Math.Sin(calcYaw) * 2f;
        }

        public override void onDisable() // Remove noclip effects noclip
        {
            base.onDisable();
            float y = Minecraft.ci.lp.Y1;
            Minecraft.ci.lp.Y1 = Minecraft.ci.lp.Y1 - 1.8f;
            Minecraft.ci.lp.Y1 = Minecraft.ci.lp.Y1 - 1.8f;
        }
    }
}
