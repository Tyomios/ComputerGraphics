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
	//TODO: Поворот
	public partial class MainForm : Form
	{
		private Pen _pen = new Pen(Color.Black, 1);

		private Bitmap bitmap;

		private double[,] _axis = new double[4, 3];

		private double[,] _square = new double[4, 3];

		private double[,] _shiftMartix = new double[3, 3];

		private double[,] ShiftMartix = new double[3, 3];

		private int _k1, _l1;

		private int k,l;

		private Timer _timer = new Timer();

		private int _size = 1;

		private int f = 0;

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


		#region HoldButtonsEvents

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

		#endregion

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

		#region PenSettings

		private void colorPickerButton_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog1 = new ColorDialog();
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				_pen.Color = colorDialog1.Color;
				var color = colorDialog1.Color;

				var colorInfo = new List<byte>() { color.R, color.G, color.B };
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

		private void penSettingsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedValue = (PenSettings)penSettingsComboBox.SelectedItem;
			_pen.Width = (float)selectedValue;
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

		#endregion

		#region ShiftButtons

		private void templatesComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (templatesComboBox.SelectedItem == "Прямоугольник")
			{
				Clear();
				DrawRectangle();
			}
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				Clear();
				DrawSpecialFigure();
			}
		}


		private void leftShiftButton_Click(object sender, EventArgs e)
		{
			if (templatesComboBox.SelectedItem == "Прямоугольник")
			{
				k -= 5;
				if (CheckRect())
				{
					k += 5;
					return;
				}
				Clear();
				DrawRectangle();
			}
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				k -= 5;
				if (CheckSpecialFigure())
				{
					k += 5;
					return;
				}
				Clear();
				DrawSpecialFigure();
			}

		}

		private void upShiftButton_Click(object sender, EventArgs e)
		{
			if (templatesComboBox.SelectedItem == "Прямоугольник")
			{
				l -= 5;
				if (CheckRect())
				{
					l += 5;
					return;
				}
				Clear();
				DrawRectangle();
			}
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				l -= 5;
				if (CheckSpecialFigure())
				{
					l += 5;
					return;
				}
				Clear();
				DrawSpecialFigure();
			}

		}

		private void downShiftButton_Click(object sender, EventArgs e)
		{
			if (templatesComboBox.SelectedItem == "Прямоугольник")
			{
				l += 5;
				if (CheckRect())
				{
					l -= 5;
					return;
				}
				Clear();
				DrawRectangle();
			}
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				l += 5;
				if (CheckSpecialFigure())
				{
					l -= 5;
					return;
				}
				Clear();
				DrawSpecialFigure();
			}
		}

		private void rightShiftButton_Click(object sender, EventArgs e)
		{
			if (templatesComboBox.SelectedItem == "Прямоугольник")
			{
				k += 5;
				if (CheckRect())
				{
					k -= 5;
					return;
				}
				Clear();
				DrawRectangle();
			}
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				k += 5;
				if (CheckSpecialFigure())
				{
					k -= 5;
					return;
				}
				Clear();
				DrawSpecialFigure();
			}
		}

		#endregion

		private void DrawSpecialFigure()
		{
			InitSpecialFigure();
			InitShiftMatr(k, l);
			
			
			var rect = MultiplyMatrix(_square, ShiftMartix);
			var m = rect[0, 2];
			var n = rect[1, 2];
			var rotateMatrix = new double[3, 3];
			rotateMatrix[0, 0] = Math.Cos(f);
			rotateMatrix[0, 1] = -Math.Sin(f);
			rotateMatrix[1, 0] = Math.Sin(f);
			rotateMatrix[1, 1] = Math.Cos(f);
			rotateMatrix[2, 0] = k;
			rotateMatrix[2, 1] = l;
			rotateMatrix[2, 2] = 1;
			rotateMatrix[1, 2] = -m * (Math.Cos(f) - 1) + n * Math.Sin(f);
			rotateMatrix[0, 2] = -m * Math.Sin(f) - n * (Math.Cos(f) - 1); //

			rect = MultiplyMatrix(_square, rotateMatrix);

			var g = Graphics.FromImage(bitmap);
			g.DrawLine(_pen, (int)rect[0, 0], (int)rect[0, 1], (int)rect[1, 0], (int)rect[1, 1]);
			g.DrawLine(_pen, (int)rect[1, 0], (int)rect[1, 1], (int)rect[2, 0], (int)rect[2, 1]);
			g.DrawLine(_pen, (int)rect[2, 0], (int)rect[2, 1], (int)rect[3, 0], (int)rect[3, 1]);
			g.DrawLine(_pen, (int)rect[3, 0], (int)rect[3, 1], (int)rect[0, 0], (int)rect[0, 1]);

			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
		}

		private void DrawRectangle()
		{
			InitSquare();
			InitShiftMatrix(k, l);
			var rect = MultiplyMatrix(_square, _shiftMartix);

			var g = Graphics.FromImage(bitmap);


			g.DrawLine(_pen, (float)rect[0,0], (float)rect[0, 1], (float)rect[1, 0], (float)rect[1, 1]);
			g.DrawLine(_pen, (float)rect[1,0], (float)rect[1, 1], (float)rect[2, 0], (float)rect[2, 1]);
			g.DrawLine(_pen, (float)rect[2,0], (float)rect[2, 1], (float)rect[3, 0], (float)rect[3, 1]);
			g.DrawLine(_pen, (float)rect[3,0], (float)rect[3, 1], (float)rect[0, 0], (float)rect[0, 1]);

			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
		}


		#region Checkers

		private bool CheckLocation(double x, double y)
		{
			if (x < 0 || y < 0) return true;

			if (x > pictureBox.Width) return true;

			if (y > pictureBox.Height) return true;

			return false;
		}


		private bool CheckRect()
		{
			InitSquare();
			InitShiftMatrix(k, l);
			var rect = MultiplyMatrix(_square, _shiftMartix);

			if (CheckLocation(rect[0, 0], rect[0, 1]) || CheckLocation(rect[1, 0], rect[1, 1])
			                                          || CheckLocation(rect[1, 0], rect[1, 1]) ||
			                                          CheckLocation(rect[2, 0], rect[2, 1])
			                                          || CheckLocation(rect[2, 0], rect[2, 1]) ||
			                                          CheckLocation(rect[3, 0], rect[3, 1])
			                                          || CheckLocation(rect[3, 0], rect[3, 1]) ||
			                                          CheckLocation(rect[0, 0], rect[0, 1]))
			{
				return true;
			}

			return false;
		}

		private bool CheckSpecialFigure()
		{
			InitSpecialFigure();
			InitShiftMatrix(k, l);
			var rect = MultiplyMatrix(_square, _shiftMartix);

			if (CheckLocation(rect[0, 0], rect[0, 1]) || CheckLocation(rect[1, 0], rect[1, 1])
			                                          || CheckLocation(rect[1, 0], rect[1, 1]) ||
			                                          CheckLocation(rect[2, 0], rect[2, 1])
			                                          || CheckLocation(rect[2, 0], rect[2, 1]) ||
			                                          CheckLocation(rect[3, 0], rect[3, 1])
			                                          || CheckLocation(rect[3, 0], rect[3, 1]) ||
			                                          CheckLocation(rect[0, 0], rect[0, 1]))
			{
				return true;
			}

			return false;
		}

		#endregion

		#region Fundamentals

		private double[,] MultiplyMatrix(double[,] firstMatrix, double[,] secondMatrix)
		{
			// размерность первой матрицы
			var n = firstMatrix.GetLength(0);
			var m = firstMatrix.GetLength(1);

			var result = new double[n, m];
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
			_shiftMartix[1, 0] = 0; //
			_shiftMartix[2, 0] = k1;
			_shiftMartix[0, 1] = 0; //
			_shiftMartix[1, 1] = _size;
			_shiftMartix[2, 1] = l1;
			_shiftMartix[0, 2] = 0; //
			_shiftMartix[1, 2] = 0; // 
			_shiftMartix[2, 2] = _size;
		}


		private void InitShiftMatr(int k1, int l1)
		{
			ShiftMartix[0, 0] = _size;
			ShiftMartix[1, 0] = 0;
			ShiftMartix[2, 0] = k1;
			ShiftMartix[0, 1] = 0;
			ShiftMartix[1, 1] = _size;
			ShiftMartix[2, 1] = l1;
			ShiftMartix[0, 2] = 0; //
			ShiftMartix[1, 2] = 0; // 
			ShiftMartix[2, 2] = _size;
		}


		private void InitSquare()
		{
			_square[0, 0] = -50; //x1
			_square[1, 0] = 0; //x2
			_square[2, 0] = 50; //x3
			_square[3, 0] = 0; //x4
			_square[0, 1] = 0;  //y1
			_square[1, 1] = 50; //y2
			_square[2, 1] = 0; //y3
			_square[3, 1] = -50; //y4
			_square[0, 2] = 1;
			_square[1, 2] = 1;
			_square[2, 2] = 1;
			_square[3, 2] = 1;
		}


		private void InitSpecialFigure()
		{
			_square[0, 0] = -50;
			_square[1, 0] = 0;
			_square[2, 0] = 50;
			_square[3, 0] = 50;
			_square[0, 1] = 0;
			_square[1, 1] = 50;
			_square[2, 1] = 0;
			_square[3, 1] = -100;
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
			_axis[2, 1] = 400;
			_axis[3, 1] = -400;
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

			g.DrawLine(pen, (float)axis[0, 0], (float)axis[0, 1], (float)axis[1, 0], (float)axis[1, 1]);
			g.DrawLine(pen, (float)axis[2, 0], (float)axis[2, 1], (float)axis[3, 0], (float)axis[3, 1]);

			g.Dispose();

			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
		}
		#endregion

		private void rotateButton_Click(object sender, EventArgs e)
		{
			f += 45;
			Clear();
			DrawSpecialFigure();
		}

		private void rotateRightButton_Click(object sender, EventArgs e)
		{
			f -= 45;
			Clear();
			DrawSpecialFigure();
		}

		private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			_size = (int)sizeComboBox.SelectedItem;
		}

		private void mirrorCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (mirrorCheckBox.Checked)
			{
				_size *= -1;
			}
			else
			{
				Math.Abs(_size);
			}
		}
	}
}