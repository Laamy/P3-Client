using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.SDK.SDK
{
    public class Packet : Actor
    {
        public Packet() : base(null) { }

        public void moveForwards(int toks)
        {
            float calcYaw = (Minecraft.ci.lp.yaw + 90F) * ((float)Math.PI / 180F);
            Minecraft.ci.lp.velX = (float)Math.Cos(calcYaw) * (toks / 9f);
            Minecraft.ci.lp.velZ = (float)Math.Sin(calcYaw) * (toks / 9f);
        }
        public bool isMoving_WASD
        {
            get
            {
                if (Minecraft.ci.lp.velocityXZ == 0.0) return false;
                else return true;
            }
        }
        public bool isMoving_Space
        {
            get
            {
                if (Minecraft.ci.lp.velY == 0) return false;
                else return true;
            }
        }
    }
}
