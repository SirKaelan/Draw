﻿using System.Drawing;

namespace Draw
{
    public class RectangleShape : Shape
    {
        public RectangleShape(Point location, Size size) : base(location, size)
        {
        }

        public override void DrawShape(Graphics graphics, Brush fillBrush, Pen drawPen)
        {
            graphics.FillRectangle(fillBrush, _rectangle);
            graphics.DrawRectangle(drawPen, _rectangle);
        }
    }
}
