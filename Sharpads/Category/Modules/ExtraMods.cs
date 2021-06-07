using Sharpads.SDK;
using Sharpads.UI;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Timers;

namespace Sharpads.Category.Modules
{
    public class ExtraMods : VisualModule
    {
        public static ExtraMods instance;
        public ExtraMods() : base("ExtraMods", CategoryHandler.registry.categories[3], (char)0x07, true)
        {
            instance = this;

            Render.postOverlayLoad += (object sen, EventArgs e) =>
            {
                Timer rgbTimer = new Timer(1000);
                rgbTimer.Elapsed += (object send, ElapsedEventArgs arg) =>
                {
                    if (enabled)
                    {
                        lastFPS = currFPS;
                        currFPS = (int)mem.m.ReadFloat(Statics.GameFPS);
                        if (lastFPS != currFPS)
                            Render.handle.Invalidate();
                    }
                };
                rgbTimer.Start();
            };
        }

        int lastFPS = 0;
        int currFPS = 0;

        public override void onDraw(Graphics graphics)
        {
            base.onDraw(graphics);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            graphics.FillRectangle(Program.mainGUI, 0, (Program.guiSize * Program.scale) * 6, Program.catWidth * Program.scale, Program.guiSize * Program.scale);
            graphics.DrawString("FPS: " + currFPS, Program.textFont, Program.textColor, 0, (Program.guiSize * Program.scale) * 6);
            graphics.FillRectangle(Program.mainGUI, 0, (Program.guiSize * Program.scale) * 7, Program.catWidth * Program.scale, Program.guiSize * Program.scale);
            graphics.DrawString("CPS: 0 - 0", Program.textFont, Program.textColor, 0, (Program.guiSize * Program.scale) * 7);
        }
    }
}
