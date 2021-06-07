using Sharpads.KeyHooks;
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
    public class Noclip : Module
    {
        public Noclip() : base("Noclip", CategoryHandler.registry.categories[4], (char)KEYS.VK_TAB, false)
        {
        }

        public override void onEnable() // Setup noclip
        {
            base.onEnable();
            Minecraft.ci.lp.teleport(Minecraft.ci.lp.X1, Minecraft.ci.lp.Y1 - 3.6f, Minecraft.ci.lp.Z1);
            Minecraft.ci.lp.Y1 = Minecraft.ci.lp.Y2 + 1.8f;
        }

        public override void onDisable() // Remove noclip effects noclip
        {
            base.onDisable();
            Minecraft.ci.lp.teleport(Minecraft.ci.lp.X1, Minecraft.ci.lp.Y1, Minecraft.ci.lp.Z1);
        }

        public override void onTick() // Key controls
        {
            base.onTick();
            float playerYaw = Minecraft.ci.lp.yaw;

            if (KeybindHandler.isKeyDown(' '))
                Minecraft.ci.lp.velY = 0.5f;
            else if (KeybindHandler.isKeyDown((char)0x10))
                Minecraft.ci.lp.velY = -0.5f;
            else
                Minecraft.ci.lp.velY = 0f;

            if (KeybindHandler.isKeyDown('W'))
            {
                if (!KeybindHandler.isKeyDown('A') && !KeybindHandler.isKeyDown('D'))
                    playerYaw += 90F;
                if (KeybindHandler.isKeyDown('A'))
                    playerYaw += 45F;
                else if (KeybindHandler.isKeyDown('D'))
                    playerYaw += 135F;
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
                if (!KeybindHandler.isKeyDown('A') && KeybindHandler.isKeyDown('D')) playerYaw += 180F;

            if (KeybindHandler.isKeyDown('W') | KeybindHandler.isKeyDown('A') | KeybindHandler.isKeyDown('D') | KeybindHandler.isKeyDown('S'))
            {
                float calcYaw = (playerYaw) * ((float)Math.PI / 180F);
                Minecraft.ci.lp.velX = (float)Math.Cos(calcYaw) * 5 / 10F;
                Minecraft.ci.lp.velZ = (float)Math.Sin(calcYaw) * 5 / 10F;
            }
        }
    }
}
