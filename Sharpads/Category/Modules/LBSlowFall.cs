using Sharpads.SDK;
using Sharpads.SDK.SDK;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Sharpads.Category.Modules
{
    public class LBSlowFall : Module
    {
        public LBSlowFall() : base("LB SlowFall", CategoryHandler.registry.categories[5], (char)0x07, false)
        {
            startTimer(300);
        }

        public override void onDisable()
        {
            base.onDisable();
            switcher = true;
        }

        bool switcher = true;
        int timedTicks = 0;
        public override void onTimedTick()
        {
            base.onTimedTick();
            if (timedTicks > 2)
                timedTicks = 0;
            if (switcher) switcher = false;
            else switcher = true;
            timedTicks++;
        }

        public override void onTick()
        {
            base.onTick();
            if (Minecraft.ci.lp.onGround == 0)
            {
                if (!switcher)
                {
                    if (timedTicks > 1) return;
                    Utils.Vec3f directionalVec = Minecraft.ci.lp.lookingVec;
                    Minecraft.ci.lp.velX = 1f / 10f * directionalVec.x;
                    Minecraft.ci.lp.velY = 0.8f / 10f * -directionalVec.y;
                    Minecraft.ci.lp.velZ = 1f / 10f * directionalVec.z;
                }
                else
                {
                    // if (timedTicks > 2) return;
                    Utils.Vec3f directionalVec = Minecraft.ci.lp.lookingVec;
                    Minecraft.ci.lp.velX = 0.5f / 10f * directionalVec.x;
                    Minecraft.ci.lp.velY = 0.4f / 10f * -directionalVec.y;
                    Minecraft.ci.lp.velZ = 0.5f / 10f * directionalVec.z;
                }
            }
        }
    }
}
