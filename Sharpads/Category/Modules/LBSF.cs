using Sharpads.SDK;
using Sharpads.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Timers;

namespace Sharpads.Category.Modules
{
    public class LBSF : VisualModule
    {
        public static LBSF instance;
        public LBSF() : base("LBSF", CategoryHandler.registry.categories[5], (char)0x07, true)
        {
            instance = this;

            Render.postOverlayLoad += (object sen, EventArgs e) =>
            {
                Timer rgbTimer = new Timer(60000);
                rgbTimer.Elapsed += (object send, ElapsedEventArgs arg) =>
                {
                    updateStaff();
                };
                rgbTimer.Start();
            };
        }

        bool staffDetected = false;

        public override void onDraw(Graphics graphics)
        {
            base.onDraw(graphics);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            if (staffDetected)
            {
                graphics.FillRectangle(Program.mainGUI, 0, (Program.guiSize * Program.scale) * 7, Program.catWidth * Program.scale, Program.guiSize * Program.scale);
                graphics.DrawString("Lifeboat staff (L)!", Program.textFont, Program.textColor, 0, (Program.guiSize * Program.scale) * 7);
            }
        }

        public async void updateStaff()
        {
            /*
            bool staffFound = false;
            foreach (string staff in Cache.staffList.Split('\r'))
            {
                IEnumerable<long> AoBScanResults = await MCM.m.AoBScan(staff);
                if (AoBScanResults != null)
                    staffFound = true;
            }
            if (staffFound)
                staffDetected = true;
            else staffDetected = false;*/
        }
    }
}
