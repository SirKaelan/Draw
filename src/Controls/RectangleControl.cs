using System.Drawing;
using System.Windows.Forms;

namespace Draw.src.Controls
{
    public class RectangleControl : Control
    {
        public RectangleControl(Color brushColor, Point location, Size size)
        {
            this.BrushColor = brushColor;
            this.Location = location;
            this.Size = size;

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        public bool ShowBorder { get; set; }

        public Color BrushColor { get; set; }

        public bool IsClicked { get; set; }
        private Point ClickLocation { get; set; }

        private bool MouseIsOnLeftEdge { get; set; }
        private bool MouseIsOnRightEdge { get; set; }
        private bool MouseIsOnTopEdge { get; set; }
        private bool MouseIsOnBottomEdge { get; set; }

        private Size InitialSize { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            //var brush = new SolidBrush(BrushColor);
            //var rectangle = new Rectangle(this.Location, this.Size);

            //e.Graphics.FillRectangle(brush, rectangle);

            if (this.ShowBorder)
            {
                using (var pen = new Pen(Color.Black, 10))
                {
                    var border = new Rectangle(Point.Empty, this.Size);
                    e.Graphics.DrawRectangle(pen, border);
                }
            }

            this.BackColor = BrushColor;
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

            if (this.ShowBorder && this.IsClicked && !this.MouseIsOnLeftEdge && !this.MouseIsOnRightEdge && !this.MouseIsOnTopEdge && !this.MouseIsOnBottomEdge)
            {
                var newX = e.X + this.Left - this.ClickLocation.X;
                var newY = e.Y + this.Top - this.ClickLocation.Y;
                this.Location = new Point(newX, newY);
            }

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

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            this.IsClicked = false;
        }
    }
}
