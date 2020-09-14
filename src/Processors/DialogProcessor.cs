using System;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor
		
		public DialogProcessor()
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Избран елемент.
		/// </summary>
		public Shape Selection { get; private set; }
		
		#endregion
		
		/// <summary>
		/// Добавя примитив - правоъгълник на произволно място върху клиентската област.
		/// </summary>
		public void AddRandomRectangle(Color borderColor)
		{
			GetRandomDimensions(out var location, out var size);
			var rect = new RectangleShape(location, size)
			{
				FillColor = Color.Transparent,
				BorderColor = borderColor,
			};

			ShapeList.Add(rect);
		}

		public void AddRandomFilledRectangle(Color fillColor)
        {
			GetRandomDimensions(out var location, out var size);
			var rect = new RectangleShape(location, size)
			{
				FillColor = fillColor,
				BorderColor = Color.Transparent,
			};

			ShapeList.Add(rect);
		}

		public void AddRandomElipse(Color borderColor)
        {
			GetRandomDimensions(out var location, out var size);
			var ellipse = new EllipseShape(location, size)
			{
				FillColor = Color.Transparent,
				BorderColor = borderColor,
			};

			ShapeList.Add(ellipse);
        }

		public void AddRandomFilledElipse(Color fillColor)
        {
			GetRandomDimensions(out var location, out var size);
			var ellipse = new EllipseShape(location, size)
			{
				FillColor = fillColor,
				BorderColor = Color.Transparent,
			};

			ShapeList.Add(ellipse);
        }
		
		/// <summary>
		/// Проверява дали дадена точка е в елемента.
		/// Обхожда в ред обратен на визуализацията с цел намиране на
		/// "най-горния" елемент т.е. този който виждаме под мишката.
		/// </summary>
		/// <param name="point">Указана точка</param>
		/// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
		public Shape ContainsPoint(Point point)
		{
			for(int i = ShapeList.Count - 1; i >= 0; i--)
			{
				if (ShapeList[i].Contains(point))
				{
					return ShapeList[i];
				}
			}

			return null;
		}
		

		public void Select(Shape shape)
        {
            foreach (var s in ShapeList)
            {
				s.Selected = false;
            }

			shape.Selected = true;
			Selection = shape;
        }

		public void Deselect()
        {
            if (Selection == null)
            {
				return;
            }

			Selection.Selected = false;
			Selection = null;
        }

		private void GetRandomDimensions(out Point location, out Size size)
        {
			var rnd = new Random();
			var x = rnd.Next(100, 1000);
			var y = rnd.Next(100, 600);
			location = new Point(x, y);

			var width = rnd.Next(100, 400);
			var height = rnd.Next(100, 400);
			size = new Size(width, height);
		}
	}
}
