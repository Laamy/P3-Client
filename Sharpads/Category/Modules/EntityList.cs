using Sharpads.SDK;
using Sharpads.SDK.SDK;
using Sharpads.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Timers;
using System.Windows.Forms;

namespace Sharpads.Category.Modules
{
    public class EntityList : VisualModule
    {
        public EntityList() : base("EntityList", CategoryHandler.registry.categories[3], (char)0x07, true) { }

        public override void onDraw(Graphics graphics)
        {
            base.onDraw(graphics);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int a = 9;
            Entity lp = new Entity("0");
            graphics.DrawString($"{lp.username}: {lp.X1}, {lp.Y1}, {lp.Z1}", Program.textFont, Program.textColor, 0, (Program.guiSize * Program.scale) * 8);
            foreach (Entity ent in Minecraft.ci.lp.Level.Players)
            {
                graphics.DrawString($"{ent.username}: {ent.X1}, {ent.Y1}, {ent.Z1}", Program.textFont, Program.textColor, 0, (Program.guiSize * Program.scale) * a);
                a++;
            }
        }
    }
}
