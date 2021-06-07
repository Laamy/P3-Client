using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class QuerkBot : Module
    {
        public QuerkBot() : base("QuerkBot", CategoryHandler.registry.categories[0], (char)0x07, false)
        {
            KeybindHandler.clientKeyHeldEvent += keyHeldEvent;
        }

        public void keyHeldEvent(object sender, clientKeyEvent e)
        {
            if (enabled && e.key == (char)0x02)
            {
                if (Minecraft.ci.lp.pitch >= 85F)
                    Minecraft.ci.lp.velY = 1F;
            }
        }
    }
}
