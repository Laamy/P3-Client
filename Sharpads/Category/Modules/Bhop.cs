using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class Bhop : Module
    {
        public Bhop() : base("Bhop", CategoryHandler.registry.categories[1], (char)0x07, false) { }

        int speed = 5;
        int height = 7;

        public override void onTick()
        {
            base.onTick();
            float playerYaw = Minecraft.ci.lp.yaw;

            if (Minecraft.ci.lp.onGround == 1)
                if (KeybindHandler.isKeyDown('W') || KeybindHandler.isKeyDown('A') || KeybindHandler.isKeyDown('S') || KeybindHandler.isKeyDown('D'))
                    Minecraft.ci.lp.velY = height / 16.4f;


            if (KeybindHandler.isKeyDown('W'))
            {
                if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                {
                    playerYaw += 90F;
                }
                if (KeybindHandler.isKeyDown('A'))
                {
                    playerYaw += 45F;
                }
                else if (KeybindHandler.isKeyDown('D'))
                {
                    playerYaw += 135F;
                }
            }
            else if (KeybindHandler.isKeyDown('S'))
            {
                if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                    playerYaw -= 90F;
                if (KeybindHandler.isKeyDown('A'))
                    playerYaw -= 45F;
                else if (KeybindHandler.isKeyDown('D'))
                    playerYaw -= 135F;
            }
            else if (!KeybindHandler.isKeyDown('W') && !KeybindHandler.isKeyDown('S'))
            {
                if (!KeybindHandler.isKeyDown('A') && KeybindHandler.isKeyDown('D')) playerYaw += 180F;
            }

            if (KeybindHandler.isKeyDown('W') | KeybindHandler.isKeyDown('A') | KeybindHandler.isKeyDown('D') | KeybindHandler.isKeyDown('S'))
            {
                float calcYaw = (playerYaw) * ((float)Math.PI / 180F);
                Minecraft.ci.lp.velX = (float)Math.Cos(calcYaw) * speed / 10F;
                Minecraft.ci.lp.velZ = (float)Math.Sin(calcYaw) * speed / 10F;
            }
        }
    }
}
