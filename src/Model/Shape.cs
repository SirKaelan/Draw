﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Draw.src.Enumerations;

namespace Draw
{
    public class Shape
	{
        private Point _location;
        private Rectangle _rectangle;

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

        private bool _isClicked;
        private Point _clickLocation;
        private Rectangle _initialRectangle;

        public Shape(Point location, Size size)
        {
            _location = location;
            _rectangle = new Rectangle(0 - size.Width / 2, 0 - size.Height / 2, size.Width, size.Height);

            this.Rotation = 0;
            this.FillColor = Color.IndianRed;
            this.BorderColor = Color.Black;
            this.BorderWidth = 1;
        }

        public float Rotation { get; set; }
        public Color FillColor { get; set; }
        public Color BorderColor { get; set; }
        public float BorderWidth { get; set; }

        public bool Selected { get; set; }

        public Point Location => _location;

        public virtual void Paint(Graphics graphics)
        {
            var handleSize = 10;
            var halfHandleSize = handleSize / 2;
            _topLeftHandle = new Rectangle(_rectangle.Left, _rectangle.Top, handleSize, handleSize);
            _topMiddleHandle = new Rectangle(_rectangle.Left + (_rectangle.Width / 2) - halfHandleSize, _rectangle.Top, handleSize, handleSize);
            _topRightHandle = new Rectangle(_rectangle.Left + _rectangle.Width - handleSize, _rectangle.Top, handleSize, handleSize);
            _bottomLeftHandle = new Rectangle(_rectangle.Left, _rectangle.Top + _rectangle.Height - handleSize, handleSize, handleSize);
            _bottomMiddleHandle = new Rectangle(_rectangle.Left + (_rectangle.Width / 2) - halfHandleSize, _rectangle.Top + _rectangle.Height - handleSize, handleSize, handleSize);
            _bottomRightHandle = new Rectangle(_rectangle.Left + _rectangle.Width - handleSize, _rectangle.Top + _rectangle.Height - handleSize, handleSize, handleSize);
            _middleLeftHandle = new Rectangle(_rectangle.Left, _rectangle.Top + (_rectangle.Height / 2) - halfHandleSize, handleSize, handleSize);
            _middleRightHandle = new Rectangle(_rectangle.Left + _rectangle.Width - handleSize, _rectangle.Top + (_rectangle.Height / 2) - halfHandleSize, handleSize, handleSize);
            _centerHandle = new Rectangle(_rectangle.Left + (_rectangle.Width / 2) - halfHandleSize, _rectangle.Top + (_rectangle.Height / 2) - halfHandleSize, handleSize, handleSize);
            _rotationHandle = new Rectangle(_rectangle.Left + (_rectangle.Width / 2) - halfHandleSize, _rectangle.Top - (handleSize * 2), handleSize, handleSize);
            _center = new Point(_rectangle.Left + (_rectangle.Width / 2), _rectangle.Top + (_rectangle.Height / 2));


            var matrix = GetTransformation();
            graphics.Transform = matrix;

            var drawPen = new Pen(this.BorderColor, this.BorderWidth);
            var fillBrush = new SolidBrush(this.FillColor);
            var handleBrush = new SolidBrush(Color.Black);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle(fillBrush, _rectangle);
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
            graphics.DrawRectangle(drawPen, _rectangle);

            graphics.ResetTransform();
        }

        public virtual void MouseDown(Control control, MouseEventArgs e)
        {
            _isClicked = true;
            _clickLocation = InvertTransformPoint(e.Location);
            _initialRectangle = _rectangle;
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
            else if (_rectangle.Contains(_clickLocation))
            {
                _activeHandle = Handle.Inside;
            }
            else
            {
                _activeHandle = Handle.None;
            }

            control.Invalidate();
        }

        public virtual void MouseMove(MouseEventArgs e)
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

            _rectangle = new Rectangle(left, top, width, height);
        }

        public virtual void MouseUp(MouseEventArgs e)
        {
            _isClicked = false;
            _location = TransformPoint(_center);
            _rectangle = new Rectangle(0 - _rectangle.Width / 2, 0 - _rectangle.Height / 2, _rectangle.Width, _rectangle.Height);
        }

        public virtual bool Contains(Point point)
        {
            var transformedPoint = InvertTransformPoint(point);

            return _rectangle.Contains(transformedPoint)
                || (this.Selected && _rotationHandle.Contains(transformedPoint));
        }

        private Matrix GetTransformation()
        {
            var matrix = new Matrix();
            matrix.Translate(_location.X, _location.Y);
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
