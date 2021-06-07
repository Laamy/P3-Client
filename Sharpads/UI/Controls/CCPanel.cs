using System;
using System.Drawing;

namespace Sharpads.UI.Controls
{
    class CCPanel : CustomControl
    {
        public override void draw(Graphics e, string font, Point Location, string text, float textSize, Brush color) => throw new NotImplementedException();
        // Disable the original arguments via ERROR

        public void draw(Graphics e, Rectangle rect, Brush color)
        {
            e.FillRectangle(color, rect);
        }
    }
}
