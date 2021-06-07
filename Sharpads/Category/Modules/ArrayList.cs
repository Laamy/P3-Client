using Sharpads.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharpads.Category.Modules
{
    public class ArrayList : Module
    {
        public static ArrayList instance;
        public ArrayList() : base("ArrayList", CategoryHandler.registry.categories[3], (char)0x07, true)
        {
            instance = this;
            new Thread(() => {
                while (Render.handle == null) { }
                Render.handle.Paint += onDraw;
            }).Start();
        }

        public void onDraw(object sender, PaintEventArgs e)
        {
            int guiScale = (int)(Program.guiSize);
            if (enabled)
            {
                uint yOff = 0;
                foreach (Category cat in CategoryHandler.registry.categories)
                {
                    foreach (Module mod in cat.modules)
                    {
                        if (mod.enabled)
                        {
                            float mwid = e.Graphics.MeasureString(mod.name, Program.textFont, 600).Width;
                            e.Graphics.FillRectangle(Program.Light_mainGUI, Render.handle.width - mwid - 5, (guiScale * Program.scale) * yOff, 5, Program.fontSize);
                            e.Graphics.FillRectangle(Program.mainGUI, Render.handle.width - mwid, (guiScale * Program.scale) * yOff, mwid, Program.fontSize);
                            e.Graphics.DrawString(mod.name, Program.textFont, Program.textColor, Render.handle.width - mwid, (guiScale * Program.scale) * yOff);
                            yOff++;
                        }
                    }
                }
            }
        }
    }
}
