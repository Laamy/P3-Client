using Sharpads.KeyHooks;
using Sharpads.SDK;
using Sharpads.UI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Sharpads.Category.Modules
{
    public class GMSpoof : VisualModule
    {
        public static GMSpoof instance;
        public GMSpoof() : base("GM Spoof", CategoryHandler.registry.categories[4], (char)0x07, false)
        {
            instance = this;
            KeybindHandler.clientKeyDownEvent += keyDown;
        }

        private void keyDown(object sender, clientKeyEvent e)
        {
            if (e.key == (int)KEYS.VK_SHIFT && enabled)
            {
                if (currentGM == 2)
                    currentGM = -1;
                currentGM++;
                mem.m.WriteMemory(Pointers.gamemodeSpoof, "byte", currentGM.ToString());
            }
        }

        int currentGM = 1;

        public override void onDraw(Graphics graphics)
        {
            base.onDraw(graphics);
            if (enabled)
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                SizeF cal = graphics.MeasureString("Press 'Shift'....", Program.textFont);
                graphics.DrawString($"Gamemode: " + currentGM, Program.textFont, Program.textColor, Render.handle.Width - cal.Width, Render.handle.height - cal.Height);
                graphics.DrawString($"Press 'Shift'", Program.textFont, Program.textColor, Render.handle.Width - cal.Width, Render.handle.height - (cal.Height * 2));
            }
        }
    }
}
