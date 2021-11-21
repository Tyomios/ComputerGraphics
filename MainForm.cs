using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics
{
	public partial class MainForm : Form
	{
		// начальные x y и конечные.
		private double xn, yn, xk, yk;

		private int xPrint, yPrint;

		private Pen _pen = new Pen(Color.Black, 1);

		private Bitmap bitmap;

		private int[,] _axis = new int[4, 3];

		private int[,] _square = new int[4, 3];

		private int[,] _shiftMartix = new int[3, 3];

		private int _k1, _l1;

		private enum PenSettings
		{
			px2 = 2,
			px4 = 4,
			px6 = 6,
			px8 = 8
		}

		public MainForm()
		{
			InitializeComponent();
			
			templatesComboBox.Items.Add("Треугольник");
			templatesComboBox.Items.Add("Прямоугольник");
			templatesComboBox.Items.Add("Круг");
			templatesComboBox.Items.Add("Вариант 14");

			penSettingsComboBox.Items.Add(PenSettings.px2);
			penSettingsComboBox.Items.Add(PenSettings.px4);
			penSettingsComboBox.Items.Add(PenSettings.px6);
			penSettingsComboBox.Items.Add(PenSettings.px8);
			penSettingsComboBox.Enabled = false;

			bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

			_k1 = pictureBox.Width / 2;
			_l1 = pictureBox.Height / 2;
			InitAxis();
		}



		private int[,] MultiplyMatrix(int[,] firstMatrix, int[,] secondMatrix)
		{
			// размерность первой матрицы
			var n = firstMatrix.GetLength(0);
			var m = firstMatrix.GetLength(1);

			var result = new int[n, m];
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					result[i, j] = 0;
					for (int k = 0; k < m; k++)
					{
						result[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
					}
				}
			}

			return result;
		}

		private void InitShiftMatrix(int k1, int l1)
		{
			_shiftMartix[0, 0] = 1;
			_shiftMartix[1, 0] = 0;
			_shiftMartix[2, 0] = k1;
			_shiftMartix[0, 1] = 0;
			_shiftMartix[1, 1] = 1;
			_shiftMartix[2, 1] = l1;
			_shiftMartix[0, 2] = 0;
			_shiftMartix[1, 2] = 0;
			_shiftMartix[2, 2] = 1;
		}

		private void InitSquare()
		{
			_square[0, 0] = -50;
			_square[1, 0] = 0;
			_square[2, 0] = 50;
			_square[3, 0] = 0;
			_square[0, 1] = 0;
			_square[1, 1] = 50;
			_square[2, 1] = 0;
			_square[3, 1] = -50;
			_square[0, 2] = 1;
			_square[1, 2] = 1;
			_square[2, 2] = 1;
			_square[3, 2] = 1;
		}


		private void BuildAxis()
		{
			_axis[0, 0] = -200;
			_axis[1, 0] = 200;
			_axis[2, 0] = 0;
			_axis[3, 0] = 0;
			_axis[0, 1] = 0;
			_axis[1, 1] = 0;
			_axis[2, 1] = 200;
			_axis[3, 1] = -200;
			_axis[0, 2] = 1;
			_axis[1, 2] = 1;
			_axis[2, 2] = 1;
			_axis[3, 2] = 1;

		}

		private void InitAxis()
		{
			BuildAxis();
			InitShiftMatrix(_k1, _l1);

			var axis = MultiplyMatrix(_axis, _shiftMartix);

			var pen = new Pen(Color.Black, 1);
			var g = Graphics.FromImage(bitmap);

			g.DrawLine(pen, axis[0,0], axis[0, 1], axis[1, 0], axis[1, 1]);
			g.DrawLine(pen, axis[2,0], axis[2, 1], axis[3, 0], axis[3, 1]);

			g.Dispose();

			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
		}

		private void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			
		}
		private void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			
		}

		public static Bitmap FloodFill(Bitmap bitmap, Point pt, Color color)
		{
			Stack<Point> pixels = new Stack<Point>();
			var targetColor = bitmap.GetPixel(pt.X, pt.Y);
			pixels.Push(pt);

			while (pixels.Count > 0)
			{
				Point currentP = pixels.Pop();
				if (currentP.X < bitmap.Width && currentP.X > -1 && currentP.Y < bitmap.Height && currentP.Y > -1)
				{
					if (bitmap.GetPixel(currentP.X, currentP.Y) == targetColor)
					{
						bitmap.SetPixel(currentP.X, currentP.Y, color);
						pixels.Push(new Point(currentP.X - 1, currentP.Y));
						pixels.Push(new Point(currentP.X + 1, currentP.Y));
						pixels.Push(new Point(currentP.X, currentP.Y - 1));
						pixels.Push(new Point(currentP.X, currentP.Y + 1));
					}
				}
			}
			return bitmap;
		}


		/// <summary>
		/// Отрисвока линии алгоритмом обычный ЦДА.
		/// </summary>
		/// <param name="e"> Событие мыши, через которое можно получить координаты курсора </param>
		private void simpleCDADraw(MouseEventArgs e, Bitmap b, double xk = 0, double yk = 0)
		{
			int i, n;
			double xt, yt, dx, dy;

			// используется рисование мышью
			if (xk == 0 && yk == 0)
			{
				xk = e.X;
				yk = e.Y;
			}

			if (xk < 0 || yk < 0 || xk > pictureBox.Width || yk > pictureBox.Height)
			{
				MessageBox.Show("Нельзя рисовать за пределами полотна", "Внимание", 
								MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			dx = xk - xn;
			dy = yk - yn;
			n = 300;
			xt = xn;
			yt = yn;

			for (i = 1; i <= n; i++)
			{
				b.SetPixel((int)xt, (int)yt, _pen.Color);

				xt = xt + dx / n;
				yt = yt + dy / n;
			}

			pictureBox.BackgroundImage = b;
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			var g = Graphics.FromImage(bitmap);
			g.Clear(Color.White);
			InitAxis();
		}
		
		private void colorPickerButton_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog1 = new ColorDialog();
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				_pen.Color = colorDialog1.Color;
				var color = colorDialog1.Color;

				var colorInfo = new List<byte>() {color.R, color.G, color.B};
				colorPickerButton.BackColor = _pen.Color;
				foreach (var value in colorInfo)
				{
					if (value > 200)
					{
						colorPickerButton.ForeColor = Color.Black;
						return;
					}
					else
					{
						colorPickerButton.ForeColor = Color.White;
					}
				}

				
			}
		}


		private void fatPencheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (fatPencheckBox.Checked)
			{
				penSettingsComboBox.Enabled = true;
			}
			else
			{
				_pen.Width = 1;
				penSettingsComboBox.Enabled = false;
			}
		}


		private void prevPenCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (prevPenCheckBox.Checked)
			{
				_pen.DashStyle = DashStyle.Dash;
			}
			else
			{
				_pen.DashStyle = DashStyle.Solid;
			}
		}


		private void templatesComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (templatesComboBox.SelectedItem == "Треугольник")
			{
				DrawTriangle();
			}
			if (templatesComboBox.SelectedItem == "Прямоугольник")
			{
				
				DrawRectangle();
			}
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				DrawSpecialFigure();
			}
			if (templatesComboBox.SelectedItem == "Круг")
			{
				DrawCircle();
			}
		}


		private void DrawCircle()
		{
			var g = Graphics.FromImage(bitmap);
			Brush b1 = new SolidBrush(_pen.Color);
			var random = new Random();
			int x = 20; //вносим радиус
			int y = 0;
			var x0 = random.Next(10, pictureBox.Width - 40);
			var y0 = random.Next(10, pictureBox.Height - 40);
			int radiusError = 1 - x;

			while (x >= y)
			{
				g.FillRectangle(b1, x + x0 , y + y0 , _pen.Width, _pen.Width);
				g.FillRectangle(b1, y + x0 , x + y0 , _pen.Width, _pen.Width);
				g.FillRectangle(b1, -x + x0 , y + y0 , _pen.Width, _pen.Width);
				g.FillRectangle(b1, -y + x0 , x + y0 , _pen.Width, _pen.Width);
				g.FillRectangle(b1, -x + x0 , -y + y0 , _pen.Width, _pen.Width);
				g.FillRectangle(b1, -y + x0 , -x + y0 , _pen.Width, _pen.Width);
				g.FillRectangle(b1, x + x0 , -y + y0 , _pen.Width, _pen.Width);
				g.FillRectangle(b1, y + x0 , -x + y0 , _pen.Width, _pen.Width);

				y++;
				if (radiusError < 0)
				{
					radiusError += 2 * y + 1;
				}
				else
				{
					x--;
					radiusError += 2 * (y - x + 1);
				}

			}

			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
		}


		private void DrawSpecialFigure()
		{
			var random = new Random();
			var point1 = new Point(random.Next(10,100), random.Next(50,70));
			var point2 = new Point(point1.X, point1.Y + random.Next(50, 70));
			var point3 = new Point(point1.X + random.Next(80,100), point2.Y);
			var point4 = new Point(point3.X - random.Next(30, 50), point1.Y);

			var g = Graphics.FromImage(bitmap);
			g.DrawLines(_pen, new[] { point1, point2, point3, point4, point1 });

			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
		}


		private void DrawTriangle()
		{
			var random = new Random();
			var width = pictureBox.Width;
			var height = pictureBox.Height;

			var point1 = new Point(random.Next(0, width), random.Next(0, height));
			var point2 = new Point(random.Next(0, width), random.Next(0, height));
			var point3 = new Point(random.Next(0, width), random.Next(0, height));

			var g = Graphics.FromImage(bitmap);
			g.DrawLines(_pen, new[] { point1, point2, point3, point1 });
			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
		}


		private void penSettingsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedValue = (PenSettings)penSettingsComboBox.SelectedItem;
			_pen.Width = (float)selectedValue;
		}

		private void DrawRectangle()
		{
			InitSquare();
			InitShiftMatrix(_k1, _l1);
			var rect = MultiplyMatrix(_square, _shiftMartix);

			var g = Graphics.FromImage(bitmap);
			
			g.DrawLine(_pen, rect[0,0], rect[0, 1], rect[1, 0], rect[1, 1]);
			g.DrawLine(_pen, rect[1,0], rect[1, 1], rect[2, 0], rect[2, 1]);
			g.DrawLine(_pen, rect[2,0], rect[2, 1], rect[3, 0], rect[3, 1]);
			g.DrawLine(_pen, rect[3,0], rect[3, 1], rect[0, 0], rect[0, 1]);

			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
		}
	}
}
