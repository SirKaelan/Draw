﻿using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Draw
{
    /// <summary>
    /// Класът, който ще бъде използван при управляване на дисплейната система.
    /// </summary>
    public class DisplayProcessor
	{
		#region Constructor
		
		public DisplayProcessor()
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Списък с всички елементи формиращи изображението.
		/// </summary>
		public List<Shape> ShapeList { get; set; } = new List<Shape>();

		public Image OpenedImage { get; set; }

		#endregion

		#region Drawing

		/// <summary>
		/// Прерисува всички елементи в shapeList върху e.Graphics
		/// </summary>
		public void ReDraw(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			Draw(e.Graphics);
		}
		
		/// <summary>
		/// Визуализация.
		/// Обхождане на всички елементи в списъка и извикване на визуализиращия им метод.
		/// </summary>
		/// <param name="grfx">Къде да се извърши визуализацията.</param>
		public virtual void Draw(Graphics grfx)
		{
			if (OpenedImage != null)
			{
				grfx.DrawImage(OpenedImage, Point.Empty);
			}

			foreach (Shape item in ShapeList){
				DrawShape(grfx, item);
			}
		}
		
		/// <summary>
		/// Визуализира даден елемент от изображението.
		/// </summary>
		/// <param name="grfx">Къде да се извърши визуализацията.</param>
		/// <param name="item">Елемент за визуализиране.</param>
		public virtual void DrawShape(Graphics grfx, Shape item)
		{
			item.Draw(grfx);
		}
		
		#endregion
	}
}
