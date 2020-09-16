using System;
using System.Drawing;

namespace Draw
{
    [Serializable]
    public class RectangleShape : Shape
    {
        public RectangleShape(Point location, Size size) : base(location, size)
        {
        }

        public override void DrawShape(Graphics graphics, Brush fillBrush, Pen drawPen)
        {
            graphics.FillRectangle(fillBrush, Rectangle);
            graphics.DrawRectangle(drawPen, Rectangle);
        }
    }
}
