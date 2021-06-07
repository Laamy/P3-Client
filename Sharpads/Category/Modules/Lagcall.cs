using Sharpads.SDK;
using Sharpads.SDK.SDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;

namespace Sharpads.Category.Modules
{
    public class Lagcall : Module
    {
        public List<List<float>> prevPositions = new List<List<float>>();
        public Lagcall() : base("Lagcall", CategoryHandler.registry.categories[4], (char)0x07, false)
        {
            startTimer(750);
        }

        public override void onTimedTick()
        {
            base.onTimedTick();
            List<float> position = new List<float>();
            position.Add(Minecraft.ci.lp.X1);
            position.Add(Minecraft.ci.lp.Y1);
            position.Add(Minecraft.ci.lp.Z1);
            prevPositions.Add(position);
        }

        public override void onDisable()
        {
            base.onDisable();

            new Thread(() =>
            {
                prevPositions.Reverse();
                foreach (List<float> list in prevPositions)
                {
                    Minecraft.ci.lp.teleport(list[0], list[1], list[2]);
                    Thread.Sleep(750);
                }
                prevPositions.Clear();
            }).Start();
        }
    }
}
