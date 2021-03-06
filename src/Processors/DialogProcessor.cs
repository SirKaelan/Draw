﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		private Shape _copiedShape;
		private GroupShape _group;

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

		public void AddRandomTriangle(Color borderColor)
        {
			AddRandomPolygon(borderColor, 3);
        }

		public void AddRandomFilledTriangle(Color fillColor)
		{
			AddRandomFilledPolygon(fillColor, 3);
		}

		public void AddRandomPentagon(Color borderColor)
        {
			AddRandomPolygon(borderColor, 5);
        }

		public void AddRandomFilledPentagon(Color fillColor)
        {
			AddRandomFilledPolygon(fillColor, 5);
        }

		public void AddRandomHexagon(Color borderColor)
        {
			AddRandomPolygon(borderColor, 6);
        }

		public void AddRandomFillexHexagon(Color fillColor)
        {
			AddRandomFilledPolygon(fillColor, 6);
        }

		public void AddRandomPolygon(Color borderColor, int points)
        {
			GetRandomDimensions(out var location, out var size);
			var triangle = new PolygonShape(location, size.Width, points)
			{
				FillColor = Color.Transparent,
				BorderColor = borderColor,
			};

			ShapeList.Add(triangle);
		}

		public void AddRandomFilledPolygon(Color fillColor, int points)
        {
			GetRandomDimensions(out var location, out var size);
			var triangle = new PolygonShape(location, size.Width, points)
			{
				FillColor = fillColor,
				BorderColor = Color.Transparent,
			};

			ShapeList.Add(triangle);
		}

		public void AddToGroup(Shape shape)
        {
            if (_group == null)
            {
				_group = new GroupShape();
				ShapeList.Add(_group);
            }

            if (!_group.ContainsShape(shape) && !(shape is GroupShape))
            {
				_group.AddShape(shape);
				ShapeList.Remove(shape);
            }

			Select(_group);
        }

		public void RemoveFromGroup(Point location)
        {
            if (_group == null)
            {
				return;
            }

            if (_group.Contains(location))
            {
				var shape = _group.RemoveShape(location);
				ShapeList.Add(shape);
            }

            if (_group.IsEmpty())
            {
				ShapeList.Remove(_group);
				_group = null;
            }
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

		public void SelectGroup()
        {
			Deselect();

            if (_group == null)
            {
				return;
            }

			Select(_group);
        }

		public void Clear()
        {
			ShapeList.Clear();
			OpenedImage?.Dispose();
			OpenedImage = null;
        }

		public void CopyShape()
        {
            if (Selection != null)
            {
				_copiedShape = Selection;
            }
        }

		public void PasteShape()
        {
            if (_copiedShape != null)
            {
                if (_copiedShape is GroupShape gs)
                {
					var shapes = gs.CopyShapes();
					ShapeList.AddRange(shapes);
                }
				else
                {
					var newShape = _copiedShape.Copy();
					ShapeList.Add(newShape);
					Select(newShape);
                }
            }
        }

		public void DeleteShape()
        {
            if (Selection != null)
            {
                if (Selection is GroupShape)
                {
					_group = null;
                }

				ShapeList.Remove(Selection);
				Selection = null;
            }
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
