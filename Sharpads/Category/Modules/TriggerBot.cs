using Sharpads.KeyHooks;
using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpads.Category.Modules
{
    public class TriggerBot : Module
    {
        public TriggerBot() : base("TriggerBot", CategoryHandler.registry.categories[0], (char)0x07, false) { }

        public override void onTick()
        {
            if (Minecraft.ci.lp.lookingAtEntity && mem.isMinecraftFocused())
                Mouse.MouseEvent(Mouse.MouseEventFlags.MOUSEEVENTF_LEFTDOWN);
        }
    }
}
