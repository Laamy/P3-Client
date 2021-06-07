using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpads.Category.Modules
{
    public class Zoom : Module
    {
        float savedFOV;

        public Zoom() : base("Zoom", CategoryHandler.registry.categories[3], 'C', false)
        {
            KeybindHandler.clientKeyUpEvent += UpKeyHeld;
        }

        public void UpKeyHeld(object sender, clientKeyEvent e)
        {
            if (e.key == keybind && enabled == true && Minecraft.inGUI)
                onDisable();
        }

        public override void onEnable()
        {
            base.onEnable();
            savedFOV = Minecraft.ci.floatOption.playerFOV;
        }

        public override void onTick()
        {
            base.onTick();
            Minecraft.ci.floatOption.playerFOV = 30;
        }

        public override void onDisable()
        {
            base.onDisable();
            Minecraft.ci.floatOption.playerFOV = savedFOV;
        }
    }
}
