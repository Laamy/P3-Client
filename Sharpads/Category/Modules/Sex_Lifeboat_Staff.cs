using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class Sex_Lifeboat_Staff : Module
    {
        public Sex_Lifeboat_Staff() : base("SLS Exploit", CategoryHandler.registry.categories[1], 'F', false)
        {

            KeybindHandler.clientKeyUpEvent += UpKeyHeld;
        }

        private void UpKeyHeld(object sender, clientKeyEvent e)
        {
            if (e.key == keybind && enabled == true && Minecraft.inGUI)
                onDisable();
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.ci.lp.velX = 0f;
            Minecraft.ci.lp.velY = -1f;
            Minecraft.ci.lp.velZ = 0f;
        }

        int tickmodule = 0;

        public override void onTick()
        {
            base.onTick();
            if (tickmodule == 3) Minecraft.ci.lp.velY = 3f;
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
    }
}
