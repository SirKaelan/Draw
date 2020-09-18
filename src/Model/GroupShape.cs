using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Draw.src.Enumerations;

namespace Draw
{
    [Serializable]
    public class GroupShape : Shape
    {
        private readonly List<Shape> _shapes = new List<Shape>();

        public GroupShape() 
            : base(Point.Empty, Size.Empty)
        {
            //_shapes = new List<Shape>();
        }

        public GroupShape(List<Shape> shapes)
            : this()
        {
            _shapes = shapes;
        }

        public override Point Location
        {
            get { return Point.Empty; }
            set { _shapes.ForEach(x => x.Location = value); }
        }
        public override Rectangle Rectangle => Rectangle.Empty;
        public override float Rotation
        {
            get { return 0; }
            set { _shapes.ForEach(x => x.Rotation = value); }
        }
        public override Color FillColor
        {
            get { return Color.Empty; }
            set { _shapes.ForEach(x => x.FillColor = value); }
        }
        public override Color BorderColor
        {
            get { return Color.Empty; }
            set { _shapes.ForEach(x => x.BorderColor = value); }
        }
        public override float BorderWidth
        {
            get { return 0f; }
            set { _shapes.ForEach(x => x.BorderWidth = value); }
        }
        public override int Opacity
        {
            get { return 100; }
            set { _shapes.ForEach(x => x.Opacity = value); }
        }

        public override bool Selected
        {
            get { return _shapes.Any(x => x.Selected); }
            set { _shapes.ForEach(x => x.Selected = value); }
        }

        public void AddShape(Shape shape)
        {
            shape.Selected = true;
            _shapes.Add(shape);
        }

        public void AddShapes(List<Shape> shapes)
        {
            shapes.ForEach(x => x.Selected = true);
            _shapes.AddRange(shapes);
        }

        public Shape RemoveShape(Point location)
        {
            var shape = _shapes.FirstOrDefault(x => x.Contains(location));
            if (shape == null)
            {
                return null;
            }

            shape.Selected = false;
            _shapes.Remove(shape);

            return shape;
        }

        public bool ContainsShape(Shape shape)
        {
            return _shapes.Contains(shape);
        }

        public void Clear()
        {
            _shapes.Clear();
        }

        public bool IsEmpty()
        {
            return _shapes.Count == 0;
        }

        public override void DrawShape(Graphics graphics, Brush fillBrush, Pen drawPen)
        {
        }

        public override void Draw(Graphics graphics)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(graphics);
            }
        }

        public override void DragStart(MouseEventArgs e)
        {
            var handle = Handle.None;
            foreach (var shape in _shapes)
            {
                shape.DragStart(e);
                handle = shape._activeHandle != Handle.None ? shape._activeHandle : handle;
            }

            foreach (var shape in _shapes)
            {
                shape._activeHandle = handle;
            }
        }

        public override void Drag(MouseEventArgs e)
        {
            foreach (var shape in _shapes)
            {
                shape.Drag(e);
            }
        }

        public override void DragEnd(MouseEventArgs e)
        {
            foreach (var shape in _shapes)
            {
                shape.DragEnd(e);
            }
        }

        public override bool Contains(Point point)
        {
            foreach (var shape in _shapes)
            {
                if (shape.Contains(point))
                {
                    return true;
                }
            }

            return false;
        }

        public override void SetSize(Size size)
        {
            foreach (var shape in _shapes)
            {
                shape.SetSize(size);
            }
        }

        public override Shape Copy()
        {
            var shapes = new List<Shape>();
            foreach (var shape in _shapes)
            {
                shapes.Add(shape.Copy());
            }

            var groupShape = base.Copy() as GroupShape;
            groupShape.Clear();
            groupShape.AddShapes(shapes);

            return groupShape;
        }
    }
}
