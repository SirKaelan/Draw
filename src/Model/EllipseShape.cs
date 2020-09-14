using System.Drawing;

namespace Draw
{
    public class EllipseShape : Shape
    {
        public EllipseShape(Point location, Size size) : base(location, size)
        {
        }

        public override void DrawShape(Graphics graphics, Brush fillBrush, Pen drawPen)
        {
            graphics.FillEllipse(fillBrush, _rectangle);
            graphics.DrawEllipse(drawPen, _rectangle);
        }
    }
}
