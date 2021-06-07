using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class BoostHit : Module
    {
        public BoostHit() : base("BoostHit", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            KeybindHandler.clientKeyHeldEvent += keyHeldEvent;
        }

        public void keyHeldEvent(object sender, clientKeyEvent e)
        {
            if (enabled)
            {
                if (Minecraft.ci.lp.lookingAtEntity == true && e.key == (char)0x01)
                {
                    Utils.Vec3f directionalVec = Utils.directionalVector((Minecraft.ci.lp.yaw + 90) * (float)Math.PI / 180, (float)Math.PI / 180);
                    Minecraft.ci.lp.velX = 16f / 10F * directionalVec.x;
                    Minecraft.ci.lp.velZ = 16f / 10F * directionalVec.z;
                }
            }
        }
    }
}
