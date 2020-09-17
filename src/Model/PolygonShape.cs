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
            var radians = 360 / _points * Math.PI / 180f;

            var polygon = new PointF[_points];
            for (int i = 0; i < _points; i++)
            {
                var pointX = _center.X + radius * (float)Math.Cos(i * radians);
                var pointY = _center.Y + radius * (float)Math.Sin(i * radians);
                polygon[i] = new PointF(pointX, pointY);
            }

            graphics.FillPolygon(fillBrush, polygon);
            graphics.DrawPolygon(drawPen, polygon);
        }
    }
}
