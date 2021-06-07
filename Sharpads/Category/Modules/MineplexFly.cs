using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class MineplexFly : Module
    {
        public MineplexFly() : base("MineplexFly", CategoryHandler.registry.categories[1], 'X', false)
        {
            KeybindHandler.clientKeyUpEvent += UpKeyHeld;
        }

        public void UpKeyHeld(object sender, clientKeyEvent e)
        {
            if (e.key == keybind && enabled == true && Minecraft.inGUI)
                onDisable();
        }

        public override void onEnable()
        {
            base.onEnable();
            Minecraft.ci.lp.velY = 5f;
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.ci.lp.velX = 0f;
            Minecraft.ci.lp.velZ = 0f;
            Minecraft.ci.lp.velY = 0f;
        }

        public override void onTick()
        {
            base.onTick();
            float calcYaw = (Minecraft.ci.lp.yaw + 90F) * ((float)Math.PI / 180F);
            Minecraft.ci.lp.velX = (float)Math.Cos(calcYaw) * 5F; // 1.655354
            Minecraft.ci.lp.velZ = (float)Math.Sin(calcYaw) * 5F;
            Minecraft.ci.lp.velY = 0.000f; // disable falling via the y ac
        }
    }
}
