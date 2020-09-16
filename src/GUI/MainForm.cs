﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

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

			SelectedColor.BackColor = Color.IndianRed;
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

            if (ColorPicker.Checked)
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
			SelectedColor.BackColor = ColorPickerDialog.Color;
		}

		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleButtonClick(object sender, EventArgs e)
		{
			var color = ColorPickerDialog.Color;
			dialogProcessor.AddRandomRectangle(color);

			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";

			viewPort.Invalidate();
		}

		private void DrawFilledRectangle_Click(object sender, EventArgs e)
        {
			var color = ColorPickerDialog.Color;
			dialogProcessor.AddRandomFilledRectangle(color);

			statusBar.Items[0].Text = "Последно действие: Рисуване на запълнен правоъгълник";

			viewPort.Invalidate();
		}

        private void DrawEllipse_Click(object sender, EventArgs e)
        {
			var color = ColorPickerDialog.Color;
			dialogProcessor.AddRandomElipse(color);

			statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";

			viewPort.Invalidate();
		}

        private void DrawFilledEllipse_Click(object sender, EventArgs e)
        {
			var color = ColorPickerDialog.Color;
			dialogProcessor.AddRandomFilledElipse(color);

			statusBar.Items[0].Text = "Последно действие: Рисуване на запълнена елипса";

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
            var dialog = new SaveFileDialog
            {
                DefaultExt = "bmp",
                Filter = "BMP (*.bmp)|*.bmp|JPEG (*.jpg;*.jpeg)|*.jpg|PNG (*.png)|*.png|GIF (*.gif)|*.gif"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
				_fileName = dialog.FileName;
				_filterIndex = dialog.FilterIndex;
				SaveFile(dialog.FileName, dialog.FilterIndex);
			}
        }

		private void SaveFile(string fileName, int filterIndex)
        {
			using (var bmp = new Bitmap(viewPort.Width, viewPort.Height))
			using (var graphics = Graphics.FromImage(bmp))
			using (var brush = new SolidBrush(Color.White))
			{
				graphics.FillRectangle(brush, new Rectangle(0, 0, viewPort.Width, viewPort.Height));
				dialogProcessor.Draw(graphics);
				bmp.Save(fileName, GetImageFormat(filterIndex));
			}
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
					return ImageFormat.Bmp;
            }
        }
    }
}
