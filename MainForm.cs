using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ComputerGraphics
{
	public partial class MainForm : Form
	{
		private Pen _pen = new Pen(Color.Black, 1);

		private Bitmap bitmap;

		private int[,] _axis = new int[4, 3];

		private int[,] _square = new int[4, 3];

		private int[,] _shiftMartix = new int[3, 3];

		private int _k1, _l1;

		private int k,l;

		private Timer _timer = new Timer();

		private int _size = 1;

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
			
			templatesComboBox.Items.Add("Прямоугольник");
			templatesComboBox.Items.Add("Вариант 14");

			sizeComboBox.Items.Add(1);
			sizeComboBox.Items.Add(2);
			sizeComboBox.Items.Add(3);

			penSettingsComboBox.Items.Add(PenSettings.px2);
			penSettingsComboBox.Items.Add(PenSettings.px4);
			penSettingsComboBox.Items.Add(PenSettings.px6);
			penSettingsComboBox.Items.Add(PenSettings.px8);
			penSettingsComboBox.Enabled = false;

			bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

			_timer.Interval = 50;
			_timer.Enabled = false;

			rightShiftButton.MouseDown += RightShiftButtonOnMouseDown;
			rightShiftButton.MouseUp += RightShiftButtonOnMouseUp;

			leftShiftButton.MouseDown += LeftShiftButtonOnMouseDown;
			leftShiftButton.MouseUp += LeftShiftButtonOnMouseUp;

			upShiftButton.MouseDown += UpShiftButtonOnMouseDown;
			upShiftButton.MouseUp += UpShiftButtonOnMouseUp;

			downShiftButton.MouseDown += DownShiftButtonOnMouseDown;
			downShiftButton.MouseUp += DownShiftButtonOnMouseUp;

			_k1 = pictureBox.Width / 2;
			_l1 = pictureBox.Height / 2;
			k = _k1;
			l = _l1;
			InitAxis();
		}


		private void DownShiftButtonOnMouseUp(object? sender, MouseEventArgs e)
		{
			_timer.Stop();
			_timer.Tick -= downShiftButton_Click;
		}

		private void DownShiftButtonOnMouseDown(object? sender, MouseEventArgs e)
		{
			_timer.Enabled = true;
			_timer.Tick += downShiftButton_Click;
			_timer.Start();
		}

		private void UpShiftButtonOnMouseUp(object? sender, MouseEventArgs e)
		{
			_timer.Stop();
			_timer.Tick -= upShiftButton_Click;
		}

		private void UpShiftButtonOnMouseDown(object? sender, MouseEventArgs e)
		{
			_timer.Enabled = true;
			_timer.Tick += upShiftButton_Click;
			_timer.Start();
		}

		private void LeftShiftButtonOnMouseUp(object? sender, MouseEventArgs e)
		{
			_timer.Stop();
			_timer.Tick -= leftShiftButton_Click;
		}

		private void LeftShiftButtonOnMouseDown(object? sender, MouseEventArgs e)
		{
			_timer.Enabled = true;
			_timer.Tick += leftShiftButton_Click;
			_timer.Start();
		}


		private void RightShiftButtonOnMouseUp(object? sender, MouseEventArgs e)
		{
			_timer.Stop();
			_timer.Tick -= rightShiftButton_Click;
		}

		private void RightShiftButtonOnMouseDown(object? sender, MouseEventArgs e)
		{
			_timer.Enabled = true;
			_timer.Tick += rightShiftButton_Click;
			_timer.Start();
		}


		private void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			
		}
		private void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			Clear();
		}

		private void Clear()
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
		}

		
		private void leftShiftButton_Click(object sender, EventArgs e)
		{
			Clear();
			k -= 5;
			DrawRectangle();
		}

		private void upShiftButton_Click(object sender, EventArgs e)
		{
			Clear();
			l -= 5;
			DrawRectangle();
		}

		private void downShiftButton_Click(object sender, EventArgs e)
		{
			Clear();
			l += 5;
			DrawRectangle();
		}

		private void rightShiftButton_Click(object sender, EventArgs e)
		{
			Clear();
			k += 5;
			DrawRectangle();
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
			InitShiftMatrix(k, l);
			var rect = MultiplyMatrix(_square, _shiftMartix);

			var g = Graphics.FromImage(bitmap);
			
			g.DrawLine(_pen, rect[0,0], rect[0, 1], rect[1, 0], rect[1, 1]);
			g.DrawLine(_pen, rect[1,0], rect[1, 1], rect[2, 0], rect[2, 1]);
			g.DrawLine(_pen, rect[2,0], rect[2, 1], rect[3, 0], rect[3, 1]);
			g.DrawLine(_pen, rect[3,0], rect[3, 1], rect[0, 0], rect[0, 1]);

			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
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
			_shiftMartix[0, 0] = _size;
			_shiftMartix[1, 0] = 0;
			_shiftMartix[2, 0] = k1;
			_shiftMartix[0, 1] = 0;
			_shiftMartix[1, 1] = _size;
			_shiftMartix[2, 1] = l1;
			_shiftMartix[0, 2] = 0;
			_shiftMartix[1, 2] = 0;
			_shiftMartix[2, 2] = _size;
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

		private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			_size = (int)sizeComboBox.SelectedItem;
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

			g.DrawLine(pen, axis[0, 0], axis[0, 1], axis[1, 0], axis[1, 1]);
			g.DrawLine(pen, axis[2, 0], axis[2, 1], axis[3, 0], axis[3, 1]);

			g.Dispose();

			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
		}
	}
}
