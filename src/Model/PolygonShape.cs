using System;
using System.Drawing;

namespace Draw
{
    [Serializable]
    public class PolygonShape : Shape
    {
        private readonly int _points;

        public PolygonShape(Point location, int diameter, int points)
            : base(location, new Size(diameter, diameter))
        {
            _points = points;
        }

        public override void DrawShape(Graphics graphics, Brush fillBrush, Pen drawPen)
        {
            var diameter = Math.Min(Rectangle.Width, Rectangle.Height);
            var radius = diameter / 2;
            var degrees = 360 / _points;

            var polygon = new PointF[_points];
            for (int i = 0; i < _points; i++)
            {
                polygon[i] = ConvertDegreesToPoint(radius, i * degrees);
            }

            graphics.FillPolygon(fillBrush, polygon);
            graphics.DrawPolygon(drawPen, polygon);
        }

        private PointF ConvertDegreesToPoint(int radius, double degrees)
        {
            var radians = degrees * Math.PI / 180f;
            var x = _center.X + radius * (float)Math.Cos(radians);
            var y = _center.Y + radius * (float)Math.Sin(radians);
            return new PointF(x, y);
        }
    }
}
