using Sharpads.SDK;
using Sharpads.SDK.SDK;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

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

            LocalPlayer lp = new LocalPlayer(Pointers.localPlayer);
            graphics.DrawString($"{lp.username}: {lp.X1}, {lp.Y1}, {lp.Z1}\r\n" +
                                $"{lp.type}, {lp.lookingAtEntity}, {lp.hitting}\r\n" +
                                $", {lp.inWater}\r\n" +
                                $"{lp.lookingAtEntity_ID}, {lp.onGround}, {lp.pitch}\r\n" +
                                $"{lp.sprinting}, {lp.stepHeight}, {lp.swingingAnimation}\r\n" +
                                $"{lp.velocityXYZ}, {lp.velocityXZ}, {lp.velX}\r\n" +
                                $"{lp.velY}, {lp.velZ}, {lp.X1}\r\n" +
                                $"{lp.X2}, {lp.Y1}, {lp.Y2}\r\n" +
                                $"{lp.yaw}, {lp.Z1}, {lp.Z2}\r\n\r\n", Program.textFont, Program.textColor, 0, (Program.guiSize * Program.scale) * 8);
        }
    }
}
