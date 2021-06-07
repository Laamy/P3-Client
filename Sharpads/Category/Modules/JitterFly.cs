using Sharpads.SDK;
using Sharpads.SDK.SDK;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Sharpads.Category.Modules
{
    public class JitterFly : Module
    {
        public JitterFly() : base("JitterFly", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
        }

        public int Counter;
        public int Counter2;

        public override void onTick()
        {
            base.onTick();
            Minecraft.ci.lp.velY = 0F;

            Counter++;
            Counter2++;

            if (Counter == 1)
            {

                if (KeybindHandler.isKeyDown('W'))
                {
                    Utils.Vec3f directionalVec = Utils.directionalVector((Minecraft.ci.lp.yaw + 89.9f) * (float)Math.PI / 178F, Minecraft.ci.lp.pitch * (float)Math.PI / 178F);
                    Minecraft.ci.lp.velX = 0.4f / 10F * directionalVec.x;
                    Minecraft.ci.lp.velZ = 0.4f / 10F * directionalVec.z;
                }
                if (Counter2 > 50)
                {
                    Minecraft.ci.lp.teleport(Minecraft.ci.lp.X1, Minecraft.ci.lp.Y1 + 0.4f, Minecraft.ci.lp.Z1);
                    Counter2 = 0;
                }
            }

            if (Counter >= 2)
            {
                Minecraft.ci.lp.velY = -0.2f;
                Counter = 0;
            }
        }
    }
}
