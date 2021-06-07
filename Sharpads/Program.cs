using Sharpads.Category;
using Sharpads.IO;
using Sharpads.UI;
using Sharpads.UI.Controls;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sharpads
{
    class Program
    {

        public static EventHandler<EventArgs> mainLoop;
        public static bool limiter = false;
        static void Main(string[] args)
        {
            Process.Start("minecraft://");

            FileMan fm = new FileMan();
            if (fm.configFile.Exists)
                fm.readConfig();
            else
                fm.saveConfig();
            fm.readConfig();

            mem.openProcess();

            new KeybindHandler(); // Create and setup mc key hooks

            Thread.Sleep(100);

            new CategoryHandler();

            Thread.Sleep(100);

            new ModuleHandler();

            Thread.Sleep(100);


            Thread uiApp = new Thread(() => {
                Render ui = new Render();
                Application.Run(ui);
            });
            uiApp.Start();

            Thread.Sleep(100);

            label = new CCLabel();
            panel = new CCPanel();

            while (true)
            {
                try
                {
                    if (mem.mcFocused())
                    {
                        if (Render.handle.Opacity != 100)
                            Render.handle.Opacity = 100;
                        mainLoop.Invoke(null, new EventArgs());
                    }
                    else if (Render.handle.Opacity != 0)
                        Render.handle.Opacity = 0;
                }
                catch { }
                if (limiter) Thread.Sleep(1);
            }
        }

        private static void gameCrash()
        {
            Console.WriteLine("Prgram has crashed!");
            while (true) { }
        }

        public static float catWidth = 0;
        public static float modWidth = 0;
        public static float catHeight = 0;
        public static float modHeight = 0;

        public static int fontSize = 28;
        public static int guiSize = 28;
        public static float scale = 1;
        public static Font textFont = new Font(new FontFamily("Arial"), fontSize * scale, FontStyle.Regular, GraphicsUnit.Pixel);
        public static SolidBrush textColor = new SolidBrush(Color.FromArgb(255, 255, 255)); // text Color
        public static SolidBrush mainGUI = new SolidBrush(Color.FromArgb(14, 30, 48)); // GUI Color
        public static SolidBrush Light_mainGUI = new SolidBrush(Color.FromArgb(18, 36, 57)); // GUI Color
        public static SolidBrush selected = new SolidBrush(Color.FromArgb(28, 107, 201)); // Selected Module
        public static SolidBrush selectedBlue = new SolidBrush(Color.FromArgb(28, 107, 201)); // Selected Module
        public static SolidBrush quaternary = new SolidBrush(Color.FromArgb(60, 100, 145)); // Selected & Enabled Module
        public static SolidBrush quinary = new SolidBrush(Color.FromArgb(200, 200, 200)); // Disabled

        public static void Update(object sender, PaintEventArgs e) // Draw on robloxes window via render overlayer
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            e.Graphics.FillRectangle(mainGUI, 0, 0, catWidth * scale, (guiSize * scale) * CategoryHandler.registry.categories.Count + 2);
            uint c = 0;
            foreach (Category.Category category in CategoryHandler.registry.categories)
            {
                float wid = e.Graphics.MeasureString(category.name, textFont, 600).Width + 6;
                if (wid > catWidth)
                    catWidth = wid;
            }
            foreach (Category.Category category in CategoryHandler.registry.categories)
            {
                if (category.active)
                {
                    e.Graphics.FillRectangle(mainGUI, catWidth, 0, modWidth * scale, (guiSize * scale) * category.modules.Count);
                    e.Graphics.FillRectangle(selectedBlue, 0, (guiSize * scale) * c, catWidth * scale, guiSize * scale);
                    e.Graphics.DrawString(" " + category.name, textFont, textColor, 0, (guiSize * scale) * c);

                    foreach (Module module in category.modules)
                    {
                        float wid = e.Graphics.MeasureString(module.name, textFont, 400).Width;
                        if (wid > modWidth)
                            modWidth = wid;
                    }
                    uint m = 0;
                    foreach (Module module in category.modules)
                    {
                        if (module.enabled && module.selected)
                        {
                            e.Graphics.FillRectangle(selectedBlue, catWidth, (guiSize * scale) * m, modWidth * scale, guiSize * scale);
                            e.Graphics.DrawString(module.name, textFont, textColor, catWidth, (guiSize * scale) * m);
                        }
                        else if (module.enabled)
                        {
                            e.Graphics.FillRectangle(mainGUI, catWidth, (guiSize * scale) * m, modWidth * scale, guiSize * scale);
                            e.Graphics.DrawString(module.name, textFont, textColor, catWidth, (guiSize * scale) * m);
                        }
                        else if (module.selected)
                        {
                            e.Graphics.FillRectangle(selectedBlue, catWidth, (guiSize * scale) * m, modWidth * scale, guiSize * scale);
                            e.Graphics.DrawString(module.name, textFont, quinary, catWidth, (guiSize * scale) * m);
                        }
                        else
                            e.Graphics.DrawString(module.name, textFont, quinary, catWidth, (guiSize * scale) * m);
                        string toDraw = ((char)module.keybind).ToString();
                        if (module.keybind == 0x07) toDraw = "          ";
                        float kwid = e.Graphics.MeasureString(toDraw, textFont, 200).Width;
                        e.Graphics.DrawString(toDraw, textFont, textColor, catWidth + modWidth, (guiSize * scale) * m);
                        m++;
                    }
                }
                else if (category.selected)
                {
                    e.Graphics.FillRectangle(selectedBlue, 0, (guiSize * scale) * c, catWidth * scale, guiSize * scale);
                    e.Graphics.DrawString(category.name, textFont, quinary, 0, (guiSize * scale) * c);
                }
                else
                    e.Graphics.DrawString(category.name, textFont, textColor, 0, (guiSize * scale) * c);
                c++;
            }
            catHeight = (guiSize * scale) * CategoryHandler.registry.categories.Count;
        }

        /*
                $"  {W1_}  \r\n" +
                $"{A1_} {S1_} {D1_}\r\n" +
                $"{B1_} {B1_} {B1_}",
         * */

        public static CCLabel label;
        public static CCPanel panel;
    }
}
