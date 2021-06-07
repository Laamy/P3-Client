using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class HighJump : Module
    {
        public HighJump() : base("HighJump", CategoryHandler.registry.categories[2], (char)0x07, false)
        {
            KeybindHandler.clientKeyHeldEvent += KeyHeldEvent;
        }

        public void KeyHeldEvent(object sender, clientKeyEvent e)
        {
            if (e.key == (char)0x20)
                if (enabled)
                    if (Minecraft.ci.lp.onGround == 0 | Minecraft.ci.lp.onGround > 0)
                        Minecraft.ci.lp.velY = 6 / 10F;
        }
    }
}
