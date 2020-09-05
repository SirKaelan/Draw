using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Draw.src.Controls
{
    public class RectangleControl : Control
    {
        public RectangleControl(Color brushColor, Point location, Size size)
        {
            this.Degrees = 10;

            this.BrushColor = brushColor;
            this.Location = location;


            this.Size = CalculateBoundingSize(size);

            this.RectangleWidth = size.Width;
            this.RectangleHeight = size.Height;

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private Size CalculateBoundingSize(Size size)
        {
            var diagonal = Math.Sqrt(size.Height * size.Height + size.Width * size.Width);

            var diagDeg = Math.Atan2(size.Height, size.Width);
            var diagAng = diagDeg * (180 / Math.PI);

            var radians = (this.Degrees % 90 + diagAng) * Math.PI / 180;
            var sin = Math.Abs(Math.Sin(radians));
            var height = (int)Math.Ceiling(diagonal * sin);

            var radians2 = (this.Degrees % 90 - diagAng) * Math.PI / 180;
            var sin2 = Math.Abs(Math.Cos(radians2));
            var width = (int)Math.Ceiling(diagonal * sin2);

            return new Size(width, height);
        }

        //private Size CalculateContainedSize(Size size)
        //{

        //}

        public double Degrees { get; set; }

        public bool ShowBorder { get; set; }

        public Color BrushColor { get; set; }

        public bool IsClicked { get; set; }
        private Point ClickLocation { get; set; }

        private bool MouseIsOnLeftEdge { get; set; }
        private bool MouseIsOnRightEdge { get; set; }
        private bool MouseIsOnTopEdge { get; set; }
        private bool MouseIsOnBottomEdge { get; set; }

        private Size InitialSize { get; set; }

        private int RectangleHeight { get; set; }
        private int RectangleWidth { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            var brush = new SolidBrush(BrushColor);
            var rectangle = new Rectangle(Point.Empty, new Size(this.RectangleWidth, this.RectangleHeight));
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            if (this.ShowBorder)
            {
                using (var pen = new Pen(Color.Black, 10))
                {
                    pen.DashStyle = DashStyle.Dash;
                    var border = new Rectangle(Point.Empty, this.Size);
                    e.Graphics.DrawRectangle(pen, border);
                }
            }

            //var maxSize = Math.Max(this.Width, this.Height);
            //this.Size = new Size(maxSize, maxSize);


            //e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            //e.Graphics.RotateTransform(45, MatrixOrder.Prepend);
            //e.Graphics.TranslateTransform(-this.Width / 2, -this.Height / 2);

            var matrix = new Matrix();
            matrix.RotateAt((float)this.Degrees, new Point(this.Width / 2, this.Height / 2));
            matrix.Translate(this.Width / 2 - this.RectangleWidth / 2, this.Height / 2 - this.RectangleHeight / 2);
            e.Graphics.Transform = matrix;

            e.Graphics.FillRectangle(brush, rectangle);
            //this.Width = 250;
            //this.Height = 250;

            //this.BackColor = BrushColor;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.IsClicked = true;
            this.ClickLocation = e.Location;

            var edgeSize = 10;
            MouseIsOnLeftEdge = e.X <= edgeSize;
            MouseIsOnRightEdge = this.Width - e.X <= edgeSize;
            MouseIsOnTopEdge = e.Y <= edgeSize;
            MouseIsOnBottomEdge = this.Height - e.Y <= edgeSize;

            InitialSize = this.Size;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.ShowBorder && this.IsClicked)
            {
                var center = new Point(this.Width / 2, this.Height / 2);
                this.Degrees = CalculateAngle(center, this.ClickLocation, e.Location);
                this.Invalidate();
            }

            //if (this.ShowBorder && this.IsClicked && !this.MouseIsOnLeftEdge && !this.MouseIsOnRightEdge && !this.MouseIsOnTopEdge && !this.MouseIsOnBottomEdge)
            //{
            //    var newX = e.X + this.Left - this.ClickLocation.X;
            //    var newY = e.Y + this.Top - this.ClickLocation.Y;
            //    this.Location = new Point(newX, newY);
            //    return;
            //}

            if (this.ShowBorder && this.IsClicked && this.MouseIsOnLeftEdge)
            {
                this.Width -= e.X - this.ClickLocation.X;
                this.Left += e.X - this.ClickLocation.X;
            }

            if (this.ShowBorder && this.IsClicked && this.MouseIsOnRightEdge)
            {
                this.Width = e.X - this.ClickLocation.X + this.InitialSize.Width;
            }

            if (this.ShowBorder && this.IsClicked && this.MouseIsOnTopEdge)
            {
                this.Height -= e.Y - this.ClickLocation.Y;
                this.Top += e.Y - this.ClickLocation.Y;
            }

            if (this.ShowBorder && this.IsClicked && this.MouseIsOnBottomEdge)
            {
                this.Height = e.Y - this.ClickLocation.Y + this.InitialSize.Height;
            }

            //if (this.ShowBorder && this.IsClicked)
            //{
            //    this.Invalidate();
            //}

        }

        private double RadiansToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        private double CalculateDistance(Point a, Point b)
        {
            var xDistance = Math.Pow(a.X - b.X, 2);
            var yDistance = Math.Pow(a.Y - b.Y, 2);
            return Math.Sqrt(xDistance + yDistance);
        }

        private double CalculateAngle(Point a, Point b, Point c)
        {
            var dist12 = CalculateDistance(a, b);
            var dist13 = CalculateDistance(a, c);
            var dist23 = CalculateDistance(b, c);
            var radians = Math.Acos((Math.Pow(dist12, 2) + Math.Pow(dist13, 2) - Math.Pow(dist23, 2)) / (2 * dist12 * dist13));

            var deg = RadiansToDegrees(radians);
            var sameSide = WhichSide(a, b, c);
            if (sameSide > 0)
            {
                deg = -deg;
            }

            if (double.IsNaN(deg))
            {
                return 0;
            }


            return deg;
        }

        private int WhichSide(Point a, Point b, Point c)
        {
            return (c.X - a.X) * (b.Y - a.Y) - (c.Y - a.Y) * (b.X - a.X);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            this.IsClicked = false;
        }
    }
}
