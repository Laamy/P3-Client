using Sharpads.SDK.SDK;

namespace Sharpads.Category.Modules
{
    public class CubeCraftFly : Module
    {
        public CubeCraftFly() : base("CubeCraftFly", CategoryHandler.registry.categories[1], 0x07, false)
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
            if (timedTicks > 3)
                timedTicks = 0;
            if (switcher) switcher = false;
            else switcher = true;
            timedTicks++;
        }

        public override void onTick()
        {
            base.onTick();
            if (!switcher)
            {
                if (timedTicks > 2) return;
                Utils.Vec3f directionalVec = Minecraft.ci.lp.lookingVec;
                Minecraft.ci.lp.velX = 2f / 10f * directionalVec.x;
                Minecraft.ci.lp.velY = 2f / 10f * -directionalVec.y;
                Minecraft.ci.lp.velZ = 2f / 10f * directionalVec.z;
            }
            else
            {
                if (timedTicks > 3) return;
                Utils.Vec3f directionalVec = Minecraft.ci.lp.lookingVec;
                Minecraft.ci.lp.velX = 0.5f / 10f * directionalVec.x;
                Minecraft.ci.lp.velY = 0.5f / 10f * -directionalVec.y;
                Minecraft.ci.lp.velZ = 0.5f / 10f * directionalVec.z;
            }
        }
    }
}
