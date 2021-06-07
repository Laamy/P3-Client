using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class YBoost : Module
    {
        public YBoost() : base("YBooster", CategoryHandler.registry.categories[2], 'V', false)
        {
            KeybindHandler.clientKeyUpEvent += UpKeyHeld;
        }

        private void UpKeyHeld(object sender, clientKeyEvent e)
        {
            if (e.key == keybind && enabled == true && Minecraft.inGUI)
                onDisable();
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.ci.lp.velY = 0;
        }

        public override void onTick()
        {
            base.onEnable();
            Minecraft.ci.lp.velY = 0.6f;
        }
    }
}
