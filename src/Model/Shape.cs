using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Draw.src.Enumerations;

namespace Draw
{
    [Serializable]
    public abstract class Shape
	{
        protected Point _center;
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
        public Handle _activeHandle;

        private bool _isClicked;
        private Point _clickLocation;
        private Rectangle _initialRectangle;

        protected Shape(Point location, Size size)
        {
            Location = location;
            SetSize(size);

            Rotation = 0;
            FillColor = Color.IndianRed;
            BorderColor = Color.Black;
            BorderWidth = 1;
            Opacity = 100;
        }

        public virtual Point Location { get; set; }
        public virtual Rectangle Rectangle { get; protected set; }
        public virtual float Rotation { get; set; }
        public virtual Color FillColor { get; set; }
        public virtual Color BorderColor { get; set; }
        public virtual float BorderWidth { get; set; }
        public virtual int Opacity { get; set; }

        public virtual bool Selected { get; set; }

        public abstract void DrawShape(Graphics graphics, Brush fillBrush, Pen drawPen);

        public virtual void Draw(Graphics graphics)
        {
            var handleSize = 10;
            var halfHandleSize = handleSize / 2;
            _topLeftHandle = new Rectangle(Rectangle.Left, Rectangle.Top, handleSize, handleSize);
            _topMiddleHandle = new Rectangle(Rectangle.Left + (Rectangle.Width / 2) - halfHandleSize, Rectangle.Top, handleSize, handleSize);
            _topRightHandle = new Rectangle(Rectangle.Left + Rectangle.Width - handleSize, Rectangle.Top, handleSize, handleSize);
            _bottomLeftHandle = new Rectangle(Rectangle.Left, Rectangle.Top + Rectangle.Height - handleSize, handleSize, handleSize);
            _bottomMiddleHandle = new Rectangle(Rectangle.Left + (Rectangle.Width / 2) - halfHandleSize, Rectangle.Top + Rectangle.Height - handleSize, handleSize, handleSize);
            _bottomRightHandle = new Rectangle(Rectangle.Left + Rectangle.Width - handleSize, Rectangle.Top + Rectangle.Height - handleSize, handleSize, handleSize);
            _middleLeftHandle = new Rectangle(Rectangle.Left, Rectangle.Top + (Rectangle.Height / 2) - halfHandleSize, handleSize, handleSize);
            _middleRightHandle = new Rectangle(Rectangle.Left + Rectangle.Width - handleSize, Rectangle.Top + (Rectangle.Height / 2) - halfHandleSize, handleSize, handleSize);
            _centerHandle = new Rectangle(Rectangle.Left + (Rectangle.Width / 2) - halfHandleSize, Rectangle.Top + (Rectangle.Height / 2) - halfHandleSize, handleSize, handleSize);
            _rotationHandle = new Rectangle(Rectangle.Left + (Rectangle.Width / 2) - halfHandleSize, Rectangle.Top - (handleSize * 2), handleSize, handleSize);
            _center = new Point(Rectangle.Left + (Rectangle.Width / 2), Rectangle.Top + (Rectangle.Height / 2));


            var matrix = GetTransformation();
            graphics.Transform = matrix;

            using (var drawPen = new Pen(GetColor(this.BorderColor), this.BorderWidth))
            using (var fillBrush = new SolidBrush(GetColor(this.FillColor)))
            using (var handleBrush = new SolidBrush(Color.Black))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                DrawShape(graphics, fillBrush, drawPen);
                if (this.Selected)
                {
                    graphics.FillRectangle(handleBrush, _topLeftHandle);
                    graphics.FillRectangle(handleBrush, _topMiddleHandle);
                    graphics.FillRectangle(handleBrush, _topRightHandle);
                    graphics.FillRectangle(handleBrush, _bottomLeftHandle);
                    graphics.FillRectangle(handleBrush, _bottomMiddleHandle);
                    graphics.FillRectangle(handleBrush, _bottomRightHandle);
                    graphics.FillRectangle(handleBrush, _middleLeftHandle);
                    graphics.FillRectangle(handleBrush, _middleRightHandle);
                    graphics.FillRectangle(handleBrush, _centerHandle);
                    graphics.FillRectangle(handleBrush, _rotationHandle);
                }
            }

            graphics.ResetTransform();
        }

        public virtual void DragStart(MouseEventArgs e)
        {
            _isClicked = true;
            _clickLocation = InvertTransformPoint(e.Location);
            _initialRectangle = Rectangle;
            _activeHandle = Handle.None;

            if (_rotationHandle.Contains(_clickLocation))
            {
                _activeHandle = Handle.Rotation;
            }
            else if (_topLeftHandle.Contains(_clickLocation))
            {
                _activeHandle = Handle.TopLeft;
            }
            else if (_topMiddleHandle.Contains(_clickLocation))
            {
                _activeHandle = Handle.TopMiddle;
            }
            else if (_topRightHandle.Contains(_clickLocation))
            {
                _activeHandle = Handle.TopRight;
            }
            else if (_middleLeftHandle.Contains(_clickLocation))
            {
                _activeHandle = Handle.MiddleLeft;
            }
            else if (_middleRightHandle.Contains(_clickLocation))
            {
                _activeHandle = Handle.MiddleRight;
            }
            else if (_bottomLeftHandle.Contains(_clickLocation))
            {
                _activeHandle = Handle.BottomLeft;
            }
            else if (_bottomMiddleHandle.Contains(_clickLocation))
            {
                _activeHandle = Handle.BottomMiddle;
            }
            else if (_bottomRightHandle.Contains(_clickLocation))
            {
                _activeHandle = Handle.BottomRight;
            }
            else if (Rectangle.Contains(_clickLocation))
            {
                _activeHandle = Handle.Inside;
            }
            else
            {
                _activeHandle = Handle.None;
            }
        }

        public virtual void Drag(MouseEventArgs e)
        {
            if (!_isClicked)
            {
                return;
            }

            var currentLocation = InvertTransformPoint(e.Location);
            var distanceX = _clickLocation.X - currentLocation.X;
            var distanceY = _clickLocation.Y - currentLocation.Y;

            var left = _initialRectangle.Left;
            var top = _initialRectangle.Top;
            var width = _initialRectangle.Width;
            var height = _initialRectangle.Height;

            if (_activeHandle == Handle.Rotation)
            {
                var x = currentLocation.X;
                var y = currentLocation.Y;
                var length = Math.Sqrt(x * x + y * y);
                var cos = y / length;
                var radians = Math.Acos(-cos);
                if (currentLocation.X < 0)
                {
                    radians = -radians;
                }

                if (double.IsNaN(radians))
                {
                    radians = 0;
                }

                this.Rotation += (float)(180 / Math.PI * radians);
            }
            else if (_activeHandle == Handle.TopLeft)
            {
                left -= distanceX;
                top -= distanceY;
                width += distanceX;
                height += distanceY;
            }
            else if (_activeHandle == Handle.TopMiddle)
            {
                top -= distanceY;
                height += distanceY;
            }
            else if (_activeHandle == Handle.TopRight)
            {
                top -= distanceY;
                width -= distanceX;
                height += distanceY;
            }
            else if (_activeHandle == Handle.MiddleLeft)
            {
                left -= distanceX;
                width += distanceX;
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
            else if (_activeHandle == Handle.Inside)
            {
                left -= distanceX;
                top -= distanceY;
            }

            Rectangle = new Rectangle(left, top, width, height);
        }

        public virtual void DragEnd(MouseEventArgs e)
        {
            _isClicked = false;
            Location = TransformPoint(_center);
            Rectangle = new Rectangle(0 - Rectangle.Width / 2, 0 - Rectangle.Height / 2, Rectangle.Width, Rectangle.Height);
        }

        public virtual void SetSize(Size size)
        {
            Rectangle = new Rectangle(0 - size.Width / 2, 0 - size.Height / 2, size.Width, size.Height);
        }

        public virtual bool Contains(Point point)
        {
            var transformedPoint = InvertTransformPoint(point);

            return Rectangle.Contains(transformedPoint)
                || (this.Selected && _rotationHandle.Contains(transformedPoint));
        }

        public virtual Shape Copy()
        {
            var copy = this.MemberwiseClone() as Shape;
            copy.Location = new Point(Rectangle.Width / 2 + 20, Rectangle.Height / 2 + 20);

            return copy;
        }

        private Color GetColor(Color color)
        {
            if (color == Color.Transparent)
            {
                return color;
            }

            return Color.FromArgb(Opacity * 255 / 100, color);
        }

        private Matrix GetTransformation()
        {
            var matrix = new Matrix();
            matrix.Translate(Location.X, Location.Y);
            matrix.Rotate(this.Rotation);
            return matrix;
        }

        private Point InvertTransformPoint(Point point)
        {
            var matrix = GetTransformation();
            matrix.Invert();

            var points = new Point[] { point };
            matrix.TransformPoints(points);
            return points[0];
        }

        private Point TransformPoint(Point point)
        {
            var matrix = GetTransformation();

            var points = new Point[] { point };
            matrix.TransformPoints(points);
            return points[0];
        }
    }
}
