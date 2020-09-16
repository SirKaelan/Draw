using System;
using System.Drawing;

namespace Draw
{
    [Serializable]
    public class EllipseShape : Shape
    {
        public EllipseShape(Point location, Size size) : base(location, size)
        {
        }

        public override void DrawShape(Graphics graphics, Brush fillBrush, Pen drawPen)
        {
            graphics.FillEllipse(fillBrush, Rectangle);
            graphics.DrawEllipse(drawPen, Rectangle);
        }
    }
}
