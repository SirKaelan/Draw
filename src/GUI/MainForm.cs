using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Draw.src.GUI.Dialogs;

namespace Draw
{
    /// <summary>
    /// Върху главната форма е поставен потребителски контрол,
    /// в който се осъществява визуализацията
    /// </summary>
    public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();

		private ColorDialog ColorPickerDialog = new ColorDialog();

		private string _fileName;
		private int _filterIndex;
		
		public MainForm()
		{
			InitializeComponent();

			ColorPickerButton.BackColor = Color.IndianRed;
			ColorPickerDialog.Color = Color.IndianRed;
		}

        /// <summary>
        /// Изход от програмата. Затваря главната форма, а с това и програмата.
        /// </summary>
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
            dialogProcessor.ReDraw(sender, e);
        }

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, MouseEventArgs e)
		{
			var shape = dialogProcessor.ContainsPoint(e.Location);
            if (shape == null)
            {
				dialogProcessor.Deselect();
				viewPort.Invalidate();
				return;
            }

			if (PointerButton.Checked) 
			{
				dialogProcessor.Select(shape);
				shape.DragStart(e);
				statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
            }

            if (ColorBucketButton.Checked)
            {
				shape.FillColor = ColorPickerDialog.Color;
				shape.BorderColor = ColorPickerDialog.Color;
				statusBar.Items[0].Text = "Последно действие: Задаване цвят на примитив";
			}

			viewPort.Invalidate();
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, MouseEventArgs e)
		{
			if (dialogProcessor.Selection == null)
            {
				return;
            }

            if (PointerButton.Checked)
            {
				dialogProcessor.Selection.Drag(e);
				statusBar.Items[0].Text = "Последно действие: Влачене";
            }

			viewPort.Invalidate();
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, MouseEventArgs e)
		{
			if (dialogProcessor.Selection == null)
			{
				return;
			}

			if (PointerButton.Checked)
            {
				dialogProcessor.Selection.DragEnd(e);
            }

			viewPort.Invalidate();
		}

		private void SelectedColor_Click(object sender, EventArgs e)
		{
			ColorPickerDialog.ShowDialog();
			ColorPickerButton.BackColor = ColorPickerDialog.Color;
		}

		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleButtonClick(object sender, EventArgs e)
		{
			DrawEmptyRectangle();
		}

		private void DrawFilledRectangle_Click(object sender, EventArgs e)
        {
			DrawFilledRectangle();
		}

        private void DrawEllipse_Click(object sender, EventArgs e)
        {
			DrawEllipse();
		}

        private void DrawFilledEllipse_Click(object sender, EventArgs e)
        {
			DrawFilledEllipse();
		}

		private void NewToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (dialogProcessor.ShapeList.Count != 0)
            {
				var shouldSave = MessageBox.Show("Do you wish to save the image?", "Save Image", MessageBoxButtons.YesNo);
				if (shouldSave == DialogResult.Yes)
				{
					SaveAsToolStripMenuItem_Click(sender, e);
				}
            }

			statusBar.Items[0].Text = "Последно действие: Нов екран";

			dialogProcessor.Clear();
			viewPort.Invalidate();
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (_fileName != null)
            {
				SaveFile(_fileName, _filterIndex);
            }
            else
            {
				SaveAsToolStripMenuItem_Click(sender, e);
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
				dialog.DefaultExt = "bmp";
                dialog.Filter = GetFileTypeFilter();

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					_fileName = dialog.FileName;
					_filterIndex = dialog.FilterIndex;
					SaveFile(dialog.FileName, dialog.FilterIndex);
				}
            }
        }

		private void SaveFile(string fileName, int filterIndex)
        {
			dialogProcessor.Deselect();

			var imageFormat = GetImageFormat(filterIndex);
            if (imageFormat != null)
            {
				SaveImage(fileName, imageFormat);
            } 
			else
            {
				SaveBinary(fileName);
            }

			viewPort.Invalidate();
		}

		private void SaveImage(string fileName, ImageFormat imageFormat)
        {
			using (var bmp = new Bitmap(viewPort.Width, viewPort.Height))
			using (var graphics = Graphics.FromImage(bmp))
			using (var brush = new SolidBrush(Color.White))
			{
				graphics.FillRectangle(brush, new Rectangle(0, 0, viewPort.Width, viewPort.Height));
				dialogProcessor.Draw(graphics);
				bmp.Save(fileName, imageFormat);
			}

			statusBar.Items[0].Text = "Последно действие: Запазване на изображението";
		}

		private void SaveBinary(string fileName)
        {
			using (var file = new FileStream(fileName, FileMode.Create))
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(file, dialogProcessor.ShapeList);
			}

			statusBar.Items[0].Text = "Последно действие: Запазване на работен файл";
		}

		private ImageFormat GetImageFormat(int filterIndex)
        {
            switch (filterIndex)
            {
				case 1:
					return ImageFormat.Bmp;
				case 2:
					return ImageFormat.Jpeg;
				case 3:
					return ImageFormat.Png;
				case 4:
					return ImageFormat.Gif;
                default:
					return null;
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.CopyShape();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.PasteShape();
			viewPort.Invalidate();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
			dialogProcessor.DeleteShape();
			viewPort.Invalidate();
        }

        private void RectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
			DrawEmptyRectangle();
        }

		private void DrawEmptyRectangle()
        {
			var color = ColorPickerDialog.Color;
			dialogProcessor.AddRandomRectangle(color);

			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";

			viewPort.Invalidate();
		}

		private void DrawFilledRectangle()
        {
			var color = ColorPickerDialog.Color;
			dialogProcessor.AddRandomFilledRectangle(color);

			statusBar.Items[0].Text = "Последно действие: Рисуване на запълнен правоъгълник";

			viewPort.Invalidate();
		}

        private void EllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
			DrawEllipse();
        }

		private void DrawEllipse()
        {
			var color = ColorPickerDialog.Color;
			dialogProcessor.AddRandomElipse(color);

			statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";

			viewPort.Invalidate();
		}

		private void DrawFilledEllipse()
        {
			var color = ColorPickerDialog.Color;
			dialogProcessor.AddRandomFilledElipse(color);

			statusBar.Items[0].Text = "Последно действие: Рисуване на запълнена елипса";

			viewPort.Invalidate();
		}

        private void FilledEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
			DrawFilledEllipse();
        }

        private void FilledRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
			DrawFilledRectangle();
        }

        private void RotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
			RotateShape();
        }

		private void RotateShape()
        {
			if (dialogProcessor.Selection == null)
			{
				MessageBox.Show("Select a shape to rotate", "Rotate");
				return;
			}

			using (var rotateDialog = new RotateDialog(dialogProcessor.Selection.Rotation))
			{
				if (rotateDialog.ShowDialog() == DialogResult.OK)
				{
					dialogProcessor.Selection.Rotation = rotateDialog.Degrees;
				}
			}

			viewPort.Invalidate();
		}

        private void ResizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
			ResizeShape();
		}

		private void ResizeShape()
        {
			if (dialogProcessor.Selection == null)
			{
				MessageBox.Show("Select a shape to resize", "Resize");
				return;
			}

			var currentWidth = dialogProcessor.Selection.Rectangle.Width;
			var currentHeight = dialogProcessor.Selection.Rectangle.Height;
			using (var resizeDialog = new ResizeDialog(currentWidth, currentHeight))
			{
				if (resizeDialog.ShowDialog() == DialogResult.OK)
				{
					dialogProcessor.Selection.SetSize(new Size(resizeDialog.ShapeWidth, resizeDialog.ShapeHeight));
				}
			}

			viewPort.Invalidate();
		}

        private void RelocateToolStripMenuItem_Click(object sender, EventArgs e)
        {
			RelocateShape();
		}

		private void RelocateShape()
        {
			if (dialogProcessor.Selection == null)
			{
				MessageBox.Show("Select a shape to relocate", "Relocate");
				return;
			}

			var currentX = dialogProcessor.Selection.Location.X;
			var currentY = dialogProcessor.Selection.Location.Y;
			using (var relocateDialog = new RelocateDialog(currentX, currentY))
			{
				if (relocateDialog.ShowDialog() == DialogResult.OK)
				{
					dialogProcessor.Selection.Location = new Point(relocateDialog.XCoord, relocateDialog.YCoord);
				}
			}

			viewPort.Invalidate();
		}

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
				openFileDialog.DefaultExt = "bmp";
				openFileDialog.Filter = GetFileTypeFilter();
				if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
					_fileName = openFileDialog.FileName;
					_filterIndex = openFileDialog.FilterIndex;
                    using (var file = openFileDialog.OpenFile() as FileStream)
                    {
                        if (file.Name.EndsWith(".bin"))
                        {
							var formatter = new BinaryFormatter();
							var shapes = formatter.Deserialize(file) as List<Shape>;
							dialogProcessor.ShapeList = shapes;
							dialogProcessor.Deselect();

							statusBar.Items[0].Text = "Последно действие: Отваряне на работен файл";
                        }
						else
                        {
							var image = Image.FromStream(file);
							dialogProcessor.OpenedImage?.Dispose();
							dialogProcessor.OpenedImage = image;

							statusBar.Items[0].Text = "Последно действие: Отваряне на изображение";
						}
					}
                }
            }

			viewPort.Invalidate();
		}

		private string GetFileTypeFilter()
        {
			return "BMP (*.bmp)|*.bmp|JPEG (*.jpg;*.jpeg)|*.jpg|PNG (*.png)|*.png|GIF (*.gif)|*.gif|Work File (*.bin)|*.bin";
		}

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (dialogProcessor.Selection == null)
			{
				MessageBox.Show("Select a shape to color", "Color");
				return;
			}

            if (ColorPickerDialog.ShowDialog() == DialogResult.OK)
            {
				dialogProcessor.Selection.FillColor = ColorPickerDialog.Color;
				dialogProcessor.Selection.BorderColor = ColorPickerDialog.Color;
            }
		}

        private void OpacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
			SetShapeOpacity();
		}

		private void SetShapeOpacity()
        {
			if (dialogProcessor.Selection == null)
			{
				MessageBox.Show("Select a shape to change opacity", "Opacity");
				return;
			}

			var currentOpacity = dialogProcessor.Selection.Opacity;
			using (var opacityDialog = new OpacityDialog(currentOpacity))
			{
				if (opacityDialog.ShowDialog() == DialogResult.OK)
				{
					dialogProcessor.Selection.Opacity = opacityDialog.ShapeOpacity;
				}
			}

			viewPort.Invalidate();
		}

        private void BorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
			SetShapeBorder();
		}

		private void SetShapeBorder()
        {
			if (dialogProcessor.Selection == null)
			{
				MessageBox.Show("Select a shape to change border", "Border");
				return;
			}

			var currentBorderWidth = dialogProcessor.Selection.BorderWidth;
			var currentBorderColor = dialogProcessor.Selection.BorderColor;
			using (var borderDialog = new BorderDialog(currentBorderWidth, currentBorderColor))
			{
				if (borderDialog.ShowDialog() == DialogResult.OK)
				{
					dialogProcessor.Selection.BorderWidth = borderDialog.BorderWidth;
					dialogProcessor.Selection.BorderColor = borderDialog.BorderColor;
				}
			}

			viewPort.Invalidate();
		}

        private void RotateButton_Click(object sender, EventArgs e)
        {
			RotateShape();
        }

        private void ResizeButton_Click(object sender, EventArgs e)
        {
			ResizeShape();
        }

        private void RelocateButton_Click(object sender, EventArgs e)
        {
			RelocateShape();
        }

        private void OpacityButton_Click(object sender, EventArgs e)
        {
			SetShapeOpacity();
        }

        private void BorderButton_Click(object sender, EventArgs e)
        {
			SetShapeBorder();
        }
    }
}
