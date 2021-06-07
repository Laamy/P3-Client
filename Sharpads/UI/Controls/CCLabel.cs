using System.Drawing;

namespace Sharpads.UI.Controls
{
    class CCLabel : CustomControl
    {
        public override void draw(Graphics e, string font, Point Location, string text, float textSize, Brush color)
        {
            e.DrawString(text, new Font(font, textSize), color, Location.X, Location.Y);
        }
    }
}
