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

		private int iter = 0;

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
		}

		private void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			if (simpleCDARadioButton.Checked)
			{
				simpleCDADraw(e, bitmap);
			}

			if (fillRadioButton.Checked)
			{
				//ColorIt(new Point(e.X, e.Y));
				var color = bitmap.GetPixel(e.X, e.Y);
				Stack<Point> collector = new Stack<Point>();
				Zaliv(e.X,e.Y, bitmap, color, collector);
			}
			pictureBox.Refresh();
		}
		private void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (simpleCDARadioButton.Checked)
			{
				xn = e.X;
				yn = e.Y;
			}
			xPrint = e.X;
			yPrint = e.Y;
			
			//else MessageBox.Show("Вы не выбрали алгоритм!",
			//					"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void ColorIt(Point p)
		{
			var pointColor = ((Bitmap)pictureBox.BackgroundImage).GetPixel(p.X, p.Y);
			if (pointColor == pictureBox.BackColor)
			{
				pointColor = _pen.Color;
				pictureBox.Refresh();
				//ColorIt(new Point(p.X + 1, p.Y));
				//ColorIt(new Point(p.X, p.Y + 1));
			}
		}


		private bool CheckColor(Color prevColor, Color )
		{

		}
		private void Zaliv(int x1, int y1, Bitmap mybitmap, Color prevColor, Stack<Point> collector)
		{
			if (x1 == pictureBox.Width || y1 == pictureBox.Height 
			                           || x1 < 0 || y1 < 0 || iter == 6888)
			{
				return;
			}


			try
			{
				Color old_color = mybitmap.GetPixel(x1, y1);
				collector.Push(new Point(x1, y1));

				// сравнение цветов происходит в формате RGB
				// для этого используем метод ToArgb объекта Color
				if (old_color.ToArgb() != _pen.Color.ToArgb()
					&& old_color.ToArgb() == prevColor.ToArgb())
				{
					//перекрашиваем пиксель
					mybitmap.SetPixel(x1, y1, _pen.Color);
					

					//вызываем метод для 4-х соседних пикселей
					Zaliv(x1 + 1, y1, mybitmap, old_color, collector);
					Zaliv(x1 - 1, y1, mybitmap, old_color, collector);
					Zaliv(x1, y1 + 1, mybitmap, old_color, collector);
					Zaliv(x1, y1 - 1, mybitmap, old_color, collector);
				}
			}
			catch (Exception e)
			{
			}
			pictureBox.BackgroundImage = mybitmap;

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
			//pictureBox.Refresh();
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			pictureBox.Image = null;
		}
		
		private void colorPickerButton_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog1 = new ColorDialog();
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				_pen.Color = colorDialog1.Color;
				var color = colorDialog1.Color;

				var colorInfo = new List<byte>();
				colorInfo.Add(color.R);
				colorInfo.Add(color.G);
				colorInfo.Add(color.B);
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
			var g = Graphics.FromHwnd(pictureBox.Handle);
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
		}


		private void DrawSpecialFigure()
		{
			var random = new Random();
			var point1 = new Point(random.Next(10,100), random.Next(50,70));
			var point2 = new Point(point1.X, point1.Y + random.Next(50, 70));
			var point3 = new Point(point1.X + random.Next(80,100), point2.Y);
			var point4 = new Point(point3.X - random.Next(30, 50), point1.Y);

			var g = Graphics.FromHwnd(pictureBox.Handle);
			g.DrawLines(_pen, new[] { point1, point2, point3, point4, point1 });
		}


		private void DrawTriangle()
		{
			var random = new Random();
			var width = pictureBox.Width;
			var height = pictureBox.Height;

			var point1 = new Point(random.Next(0, width), random.Next(0, height));
			var point2 = new Point(random.Next(0, width), random.Next(0, height));
			var point3 = new Point(random.Next(0, width), random.Next(0, height));

			var g = Graphics.FromHwnd(pictureBox.Handle);
			g.DrawLines(_pen, new[] { point1, point2, point3, point1 });
		}


		private void penSettingsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedValue = (PenSettings)penSettingsComboBox.SelectedItem;
			_pen.Width = (float)selectedValue;
		}

		private void DrawRectangle()
		{
			var random = new Random();
			var width = pictureBox.Width;
			var height = pictureBox.Height;
			
			var point1 = new Point(random.Next(0, width - 100), random.Next(0, height - 100));
			var size = new Size(random.Next(10, 80), random.Next(3, 200));
			var rect = new Rectangle(point1, size);
			var g = Graphics.FromHwnd(pictureBox.Handle);
			g.DrawRectangle(_pen, rect);
		}

		private void simpleCDARadioButton_CheckedChanged(object sender, EventArgs e)
		{

		}

		
	}
}
