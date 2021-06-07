using Sharpads.SDK;
using Sharpads.SDK.SDK;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Sharpads.Category.Modules
{
    public class TPFlight : Module
    {
        public TPFlight() : base("TPFlight", CategoryHandler.registry.categories[1], (char)0x07, false)
        {
            startTimer(300);
        }
        public override void onTimedTick()
        {
            base.onTimedTick();
            Utils.Vec3f directionalVec = Minecraft.ci.lp.lookingVec;
            if (mem.GetAsyncKeyState('W'))
                Minecraft.ci.lp.teleport(Minecraft.ci.lp.X1 + 10 / 10 * directionalVec.x, Minecraft.ci.lp.Y1 + 10 / 10 * -directionalVec.y, Minecraft.ci.lp.Z1 + 10 / 10 * directionalVec.z);
        }
        public override void onTick()
        {
            base.onTick();
            Minecraft.ci.lp.velX = 0;
            Minecraft.ci.lp.velY = 0;
            Minecraft.ci.lp.velZ = 0;
        }
    }
}
