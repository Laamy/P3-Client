using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class Jetpack : Module
    {
        public Jetpack() : base("Jetpack", CategoryHandler.registry.categories[1], 'G', false)
        {
            KeybindHandler.clientKeyUpEvent += UpKeyHeld;
        }
        public void UpKeyHeld(object sender, clientKeyEvent e)
        {
            if (e.key == keybind && Minecraft.inGUI)
                enabled = false;
        }
        public override void onTick()
        {
            base.onTick();
            Utils.Vec3f directionalVec = Minecraft.ci.lp.lookingVec;
            Minecraft.ci.lp.velX = 1F * directionalVec.x;
            Minecraft.ci.lp.velY = 1F * -directionalVec.y;
            Minecraft.ci.lp.velZ = 1F * directionalVec.z;
        }
    }
}
