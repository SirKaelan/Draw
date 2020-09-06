using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Draw.src.Controls
{
    public class RectangleControl : Control
    {
        private Point _center;
        private Rectangle _centerHandle;
        private Rectangle _rotationHandle;
        private Rectangle _topLeftHandle;
        private Rectangle _topMiddleHandle;
        private Rectangle _topRightHandle;
        private Rectangle _bottomLeftHandle;
        private Rectangle _bottomMiddleHandle;
        private Rectangle _bottomRightHandle;
        private Rectangle _middleLeftHandle;
        private Rectangle _middleRightHandle;
        private Handle _activeHandle;

        public RectangleControl(Color brushColor, Point location, Size size)
        {
            this.Degrees = 10;

            this.BrushColor = brushColor;
            this.Location = location;


            this.Size = CalculateBoundingSize(size);

            this.RectangleWidth = size.Width;
            this.RectangleHeight = size.Height;

            this.Rectangle = new Rectangle(new Point(0, 0), size);

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public double Degrees { get; set; }

        public bool ShowBorder { get; set; }

        public Color BrushColor { get; set; }

        public bool IsClicked { get; set; }
        private Point ClickLocation { get; set; }
        private Point TClickLocation { get; set; }

        private bool MouseIsOnLeftEdge { get; set; }
        private bool MouseIsOnRightEdge { get; set; }
        private bool MouseIsOnTopEdge { get; set; }
        private bool MouseIsOnBottomEdge { get; set; }

        private Size InitialSize { get; set; }
        private Rectangle InitialRectangle { get; set; }

        private int RectangleHeight { get; set; }
        private int RectangleWidth { get; set; }

        private Rectangle Rectangle { get; set; }

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

            var handleSize = 10;
            var halfHandleSize = handleSize / 2;
            _topLeftHandle = new Rectangle(this.Rectangle.Left, this.Rectangle.Top, handleSize, handleSize);
            _topMiddleHandle = new Rectangle(this.Rectangle.Left + (this.Rectangle.Width / 2) - halfHandleSize, this.Rectangle.Top, handleSize, handleSize);
            _topRightHandle = new Rectangle(this.Rectangle.Left + this.Rectangle.Width - handleSize, this.Rectangle.Top, handleSize, handleSize);
            _bottomLeftHandle = new Rectangle(this.Rectangle.Left, this.Rectangle.Top + this.Rectangle.Height - handleSize, handleSize, handleSize);
            _bottomMiddleHandle = new Rectangle(this.Rectangle.Left + (this.Rectangle.Width / 2) - halfHandleSize, this.Rectangle.Top + this.Rectangle.Height - handleSize, handleSize, handleSize);
            _bottomRightHandle = new Rectangle(this.Rectangle.Left + this.Rectangle.Width - handleSize, this.Rectangle.Top + this.Rectangle.Height - handleSize, handleSize, handleSize);
            _middleLeftHandle = new Rectangle(this.Rectangle.Left, this.Rectangle.Top + (this.Rectangle.Height / 2) - halfHandleSize, handleSize, handleSize);
            _middleRightHandle = new Rectangle(this.Rectangle.Left + this.Rectangle.Width - handleSize, this.Rectangle.Top + (this.Rectangle.Height / 2) - halfHandleSize, handleSize, handleSize);
            _centerHandle = new Rectangle(this.Rectangle.Left + (this.Rectangle.Width / 2) - halfHandleSize, this.Rectangle.Top + (this.Rectangle.Height / 2) - halfHandleSize, handleSize, handleSize);
            _rotationHandle = new Rectangle(this.Rectangle.Left + (this.Rectangle.Width / 2) - halfHandleSize, this.Rectangle.Top - (handleSize * 2), handleSize, handleSize);

            _center = new Point(this.Rectangle.Left + (this.Rectangle.Width / 2), this.Rectangle.Top + (this.Rectangle.Height / 2));


            var matrix = new Matrix();
            matrix.RotateAt((float)this.Degrees, new Point(this.Width / 2, this.Height / 2));
            matrix.Translate(this.Width / 2 - this.RectangleWidth / 2, this.Height / 2 - this.RectangleHeight / 2);
            e.Graphics.Transform = matrix;

            //var matrix = new Matrix();
            //matrix.Translate(this.Rectangle.Location.X, this.Rectangle.Location.Y);
            //matrix.Rotate((float)this.Degrees);
            //e.Graphics.Transform = matrix;

            var handleBrush = new SolidBrush(Color.Black);

            e.Graphics.FillRectangle(brush, this.Rectangle);
            e.Graphics.FillRectangle(handleBrush, _topLeftHandle);
            e.Graphics.FillRectangle(handleBrush, _topMiddleHandle);
            e.Graphics.FillRectangle(handleBrush, _topRightHandle);
            e.Graphics.FillRectangle(handleBrush, _bottomLeftHandle);
            e.Graphics.FillRectangle(handleBrush, _bottomMiddleHandle);
            e.Graphics.FillRectangle(handleBrush, _bottomRightHandle);
            e.Graphics.FillRectangle(handleBrush, _middleLeftHandle);
            e.Graphics.FillRectangle(handleBrush, _middleRightHandle);
            e.Graphics.FillRectangle(handleBrush, _centerHandle);
            e.Graphics.FillRectangle(handleBrush, _rotationHandle);

            e.Graphics.ResetTransform();
            var clickLocation = TransformPoint(this.ClickLocation);
            var clickRect = new Rectangle(clickLocation, new Size(10, 10));
            e.Graphics.FillRectangle(new SolidBrush(Color.DeepSkyBlue), clickRect);

            //e.Graphics.ResetTransform();
        }

        private Point TransformPoint(Point point)
        {
            var matrix = new Matrix();
            matrix.RotateAt((float)this.Degrees, new Point(this.Width / 2, this.Height / 2));
            matrix.Translate(this.Width / 2 - this.RectangleWidth / 2, this.Height / 2 - this.RectangleHeight / 2);
            matrix.Invert();

            //var matrix = new Matrix();
            //matrix.RotateAt((float)this.Degrees, _center);
            //matrix.Translate(this.Width / 2 - this.RectangleWidth / 2, this.Height / 2 - this.RectangleHeight / 2);
            //matrix.Invert();

            //var matrix = new Matrix();
            //matrix.Translate(this.Rectangle.Location.X, this.Rectangle.Location.Y);
            //matrix.Rotate((float)this.Degrees);
            //matrix.Invert();

            var points = new Point[] { point };
            matrix.TransformPoints(points);
            return points[0];
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
            this.InitialRectangle = this.Rectangle;

            _activeHandle = Handle.None;
            var clickLocation = TransformPoint(this.ClickLocation);
            this.TClickLocation = clickLocation;

            if (_rotationHandle.Contains(clickLocation))
            {
                _activeHandle = Handle.Rotation;
            }
            else if (_topLeftHandle.Contains(clickLocation))
            {
                _activeHandle = Handle.TopLeft;
            }
            else if (_topMiddleHandle.Contains(clickLocation))
            {
                _activeHandle = Handle.TopMiddle;
            }
            else if (_topRightHandle.Contains(clickLocation))
            {
                _activeHandle = Handle.TopRight;
            }
            else if (_middleLeftHandle.Contains(clickLocation))
            {
                //BackColor = Color.DeepPink;
                _activeHandle = Handle.MiddleLeft;
            }
            else if (_middleRightHandle.Contains(clickLocation))
            {
                _activeHandle = Handle.MiddleRight;
            }
            else if (_bottomLeftHandle.Contains(clickLocation))
            {
                _activeHandle = Handle.BottomLeft;
            }
            else if (_bottomMiddleHandle.Contains(clickLocation))
            {
                _activeHandle = Handle.BottomMiddle;
            }
            else if (_bottomRightHandle.Contains(clickLocation))
            {
                _activeHandle = Handle.BottomRight;
            }
            else
            {
                _activeHandle = Handle.None;
            }

            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!this.IsClicked)
            {
                return;
            }

            //if (this.ShowBorder && this.IsClicked)
            //{
            //    var center = new Point(this.Width / 2, this.Height / 2);
            //    this.Degrees = CalculateAngle(center, this.ClickLocation, e.Location);
            //    this.Invalidate();
            //    return;
            //}

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

            var currentLocation = TransformPoint(e.Location);
            var distanceX = this.TClickLocation.X - currentLocation.X;
            var distanceY = this.TClickLocation.Y - currentLocation.Y;

            var left = this.InitialRectangle.Left;
            var top = this.InitialRectangle.Top;
            var width = this.InitialRectangle.Width;
            var height = this.InitialRectangle.Height;

            if (_activeHandle == Handle.Rotation)
            {
                var center = new Point(this.InitialRectangle.Left + (this.InitialRectangle.Width / 2), this.InitialRectangle.Top + (this.InitialRectangle.Height / 2));
                this.Degrees = CalculateAngle(center, this.TClickLocation, currentLocation);

                this.Invalidate();
                return;
            }
            else if (_activeHandle == Handle.TopLeft)
            {
                left -= distanceX;
                top -= distanceY;
                width += distanceX;
                height += distanceY;
                //this.Rectangle = new Rectangle(this.InitialRectangle.Left - distanceX, this.InitialRectangle.Top - distanceY, this.InitialRectangle.Width + distanceX, this.InitialRectangle.Height + distanceY);
            }
            else if (_activeHandle == Handle.TopMiddle)
            {
                top -= distanceY;
                height += distanceY;
                //this.Rectangle = new Rectangle(this.InitialRectangle.Left, this.InitialRectangle.Top - distanceY, this.InitialRectangle.Width, this.InitialRectangle.Height + distanceY);
            }
            else if (_activeHandle == Handle.TopRight)
            {
                top -= distanceY;
                width -= distanceX;
                height += distanceY;
                //this.Rectangle = new Rectangle(this.InitialRectangle.Left, this.InitialRectangle.Top - distanceY, this.InitialRectangle.Width - distanceX, this.InitialRectangle.Height + distanceY);
            }
            else if (_activeHandle == Handle.MiddleLeft)
            {
                left -= distanceX;
                width += distanceX;
                //var distance = (int)CalculateDistance(this.TClickLocation, currentLocation);
                //if (this.InitialRectangle.Contains(currentLocation))
                //{
                //    distance = -distance;
                //}

                //this.Rectangle = new Rectangle(this.InitialRectangle.Left - distanceX, this.InitialRectangle.Top, this.InitialRectangle.Width + distanceX, this.InitialRectangle.Height);
            }
            else if (_activeHandle == Handle.MiddleRight)
            {
                width -= distanceX;
            }
            else if (_activeHandle == Handle.BottomLeft)
            {
                left -= distanceX;
                width += distanceX;
                height -= distanceY;
            }
            else if (_activeHandle == Handle.BottomMiddle)
            {
                height -= distanceY;
            }
            else if (_activeHandle == Handle.BottomRight)
            {
                width -= distanceX;
                height -= distanceY;
            }
            else
            {
                left -= distanceX;
                top -= distanceY;
            }

            this.Rectangle = new Rectangle(left, top, width, height);

            this.Invalidate();
            //if (this.ShowBorder && this.IsClicked)
            //{
            //    this.Invalidate();
            //}

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
        public enum Handle
        {
            None,
            TopLeft,
            TopMiddle,
            TopRight,
            BottomLeft,
            BottomMiddle,
            BottomRight,
            MiddleLeft,
            MiddleRight,
            Center,
            Rotation,
        }
    }

}
