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
	//TODO: Поворот матрицы не нужно смешивать, фигуру умножить
	//на матрицу сдвига на матрицу масштаба, на матрицу поворота
	public partial class MainForm : Form
	{
		private Pen _pen = new Pen(Color.Black, 1);

		private Bitmap bitmap;

		private double[,] _axis = new double[4, 4]; 

		private double[,] _square = new double[6, 4];

		private double[,] ShiftMartix = new double[4, 4];

		private double[,] _rotateMatrix = new double[4, 4];

		private double[,] _sizeMatrix = new double[4, 4]; 

		private int _k1, _l1, _p1;

		private int k,l, p;

		private Timer _timer = new Timer();

		private Timer _rotateTimer = new Timer();

		private double _size = 50;

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
			
			templatesComboBox.Items.Add("Вариант 14");

			sizeComboBox.Items.Add("0.5");
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

			_rotateTimer.Interval = 50;
			_rotateTimer.Enabled = false;

			rotateRightButton.MouseDown += RotateRightButtonOnMouseDown;
			rotateRightButton.MouseUp += RotateRightButtonOnMouseUp;

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
			p = 1;
			InitAxis();
		}


		#region HoldButtonsEvents

		private void RotateRightButtonOnMouseUp(object? sender, MouseEventArgs e)
		{
			_rotateTimer.Stop();
			_rotateTimer.Tick -= rotateRightButton_Click;
		}

		private void RotateRightButtonOnMouseDown(object? sender, MouseEventArgs e)
		{
			_rotateTimer.Enabled = true;
			_rotateTimer.Tick += rotateRightButton_Click;
			_rotateTimer.Start();
		}

		private void rotateButton_MouseDown(object sender, MouseEventArgs e)
		{
			_rotateTimer.Enabled = true;
			_rotateTimer.Tick += rotateButton_Click;
			_rotateTimer.Start();
		}

		private void rotateButton_MouseUp(object sender, MouseEventArgs e)
		{
			_rotateTimer.Stop();
			_rotateTimer.Tick -= rotateButton_Click;
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
			
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				Clear();
				DrawSpecialFigure();
			}
		}


		private void leftShiftButton_Click(object sender, EventArgs e)
		{
			
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				k -= 5;
				
				Clear();
				DrawSpecialFigure();
			}

		}

		private void upShiftButton_Click(object sender, EventArgs e)
		{
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				l -= 5;
				Clear();
				DrawSpecialFigure();
			}

		}

		private void downShiftButton_Click(object sender, EventArgs e)
		{
			
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				l += 5;
				Clear();
				DrawSpecialFigure();
			}
		}

		private void rightShiftButton_Click(object sender, EventArgs e)
		{
			
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				k += 5;
				Clear();
				DrawSpecialFigure();
			}
		}

		#endregion

		private void DrawSpecialFigure()
		{
			InitSpecialFigure();
			InitShiftMatrix(k, l, p);
			InitRotateMatrix();
			//InitRotateX();
			InitSizeMatrix();

			var rect = MultiplyMatrix(_square, _sizeMatrix);
			rect = MultiplyMatrix(rect, _rotateMatrix);
			rect = MultiplyMatrix(rect, ShiftMartix);

			var g = Graphics.FromImage(bitmap);

			// соединение верхней вершины
			g.DrawLine(_pen, (float)rect[1, 0], (float)rect[1, 1], (float)rect[3, 0], (float)rect[3, 1]); //дальняя
			g.DrawLine(_pen, (float)rect[1, 0], (float)rect[1, 1], (float)rect[2, 0], (float)rect[2, 1]); // ближняя
			g.DrawLine(_pen, (float)rect[1, 0], (float)rect[1, 1], (float)rect[4, 0], (float)rect[4, 1]); //правая
			g.DrawLine(_pen, (float)rect[1, 0], (float)rect[1, 1], (float)rect[0, 0], (float)rect[0, 1]); //правая

			// соединение нижней вершины
			g.DrawLine(_pen, (float)rect[5, 0], (float)rect[5, 1], (float)rect[3, 0], (float)rect[3, 1]); //дальняя
			g.DrawLine(_pen, (float)rect[5, 0], (float)rect[5, 1], (float)rect[2, 0], (float)rect[2, 1]); // ближняя
			g.DrawLine(_pen, (float)rect[5, 0], (float)rect[5, 1], (float)rect[4, 0], (float)rect[4, 1]); //правая
			g.DrawLine(_pen, (float)rect[5, 0], (float)rect[5, 1], (float)rect[0, 0], (float)rect[0, 1]); //правая

			// соединение соседних 
			g.DrawLine(_pen, (float)rect[0, 0], (float)rect[0, 1], (float)rect[2, 0], (float)rect[2, 1]); // ближнаяя с левой
			g.DrawLine(_pen, (float)rect[0, 0], (float)rect[0, 1], (float)rect[3, 0], (float)rect[3, 1]); // дальняя с левой
			g.DrawLine(_pen, (float)rect[4, 0], (float)rect[4, 1], (float)rect[3, 0], (float)rect[3, 1]); // правая с дальней
			g.DrawLine(_pen, (float)rect[4, 0], (float)rect[4, 1], (float)rect[2, 0], (float)rect[2, 1]); // правая с бижней

			pictureBox.BackgroundImage = bitmap;
			pictureBox.Refresh();
		}


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


		private void InitSizeMatrix()
		{
			_sizeMatrix[0, 0] = _size;
			_sizeMatrix[1, 1] = _size;
			_sizeMatrix[2, 2] = _size;
			_sizeMatrix[3, 3] = 1;

			_sizeMatrix[0, 1] = 0;
			_sizeMatrix[0, 2] = 0;
			_sizeMatrix[0, 3] = 0;
			_sizeMatrix[1, 0] = 0;
			_sizeMatrix[1, 2] = 0;
			_sizeMatrix[1, 3] = 0;
			_sizeMatrix[2, 0] = 0;
			_sizeMatrix[2, 1] = 0;
			_sizeMatrix[2, 3] = 0;
			_sizeMatrix[3, 0] = 0;
			_sizeMatrix[3, 1] = 0;
			_sizeMatrix[3, 2] = 0;
			
		}

		/// <summary>
		/// Матрица вращения вокруг OY
		/// </summary>
		private void InitRotateMatrix()
		{
			var rad = Math.PI / 360 * f;
			_rotateMatrix[0, 0] = Math.Cos(rad);
			_rotateMatrix[0, 1] = 0;
			_rotateMatrix[0, 2] = Math.Sin(rad);
			_rotateMatrix[0, 3] = 0;
			_rotateMatrix[1, 0] = 0;
			_rotateMatrix[1, 1] = 1;
			_rotateMatrix[1, 2] = 0;
			_rotateMatrix[1, 3] = 0;
			_rotateMatrix[2, 0] = -Math.Sin(rad);
			_rotateMatrix[2, 1] = 0;
			_rotateMatrix[2, 2] = Math.Cos(rad);
			_rotateMatrix[2, 3] = 0;
			_rotateMatrix[3, 0] = 0;
			_rotateMatrix[3, 1] = 0;
			_rotateMatrix[3, 2] = 0;
			_rotateMatrix[3, 3] = 1;
		}

		private void InitRotateX()
		{
			var rad = Math.PI / 360 * f;
			_rotateMatrix[0, 0] = 1;
			_rotateMatrix[0, 1] = 0;
			_rotateMatrix[0, 2] = 0;
			_rotateMatrix[0, 3] = 0;
			_rotateMatrix[1, 0] = 0;
			_rotateMatrix[1, 1] = Math.Cos(rad);
			_rotateMatrix[1, 2] = -Math.Sin(rad);
			_rotateMatrix[1, 3] = 0;
			_rotateMatrix[2, 0] = 0;
			_rotateMatrix[2, 1] = Math.Sin(rad);
			_rotateMatrix[2, 2] = Math.Cos(rad);
			_rotateMatrix[2, 3] = 0;
			_rotateMatrix[3, 0] = 0;
			_rotateMatrix[3, 1] = 0;
			_rotateMatrix[3, 2] = 0;
			_rotateMatrix[3, 3] = 1;
		}

		private void InitShiftMatrix(int k1, int l1, int p)
		{
			ShiftMartix[0, 0] = 1;
			ShiftMartix[0, 1] = 0;
			ShiftMartix[0, 2] = 0;
			ShiftMartix[0, 3] = 0;

			ShiftMartix[1, 3] = 0;
			ShiftMartix[1, 0] = 0;
			ShiftMartix[1, 1] = 1;
			ShiftMartix[1, 2] = 0;
			
			ShiftMartix[2, 0] = 0;
			ShiftMartix[2, 1] = 0;
			ShiftMartix[2, 2] = 1;
			ShiftMartix[2, 3] = 0;
			
			ShiftMartix[3, 0] = k1;
			ShiftMartix[3, 1] = l1;
			ShiftMartix[3, 2] = p;
			ShiftMartix[3, 3] = 1;
		}

		private void InitSpecialFigure()
		{
			// левая вершина 
			_square[0, 0] = -1;
			_square[0, 1] = 0;
			_square[0, 2] = 0;
			_square[0, 3] = 1;

			// правая вершина
			_square[4, 0] = 1;
			_square[4, 1] = 0;
			_square[4, 2] = 0;
			_square[4, 3] = 1;

			// верхняя вершина 
			_square[1, 0] = 0;
			_square[1, 1] = -2;
			_square[1, 2] = 0;
			_square[1, 3] = 1;

			// Нижнаяя вершина
			_square[5, 0] = 0;
			_square[5, 1] = 2;
			_square[5, 2] = 0;
			_square[5, 3] = 1;

			// ближняя вершина.
			_square[2, 0] = 0;
			_square[2, 1] = 0;
			_square[2, 2] = 1;
			_square[2, 3] = 1;

			// дальняя вершина.
			_square[3, 0] = 0;
			_square[3, 1] = 0;
			_square[3, 2] = -1;
			_square[3, 3] = 1;
		}

		private void BuildAxis()
		{
			_axis[0, 0] = -200; //x1
			_axis[1, 0] = 200; //x2
			_axis[2, 0] = 0; //x3
			_axis[3, 0] = 0; //x4

			_axis[0, 1] = 0; //y1
			_axis[1, 1] = 0; //y2
			_axis[2, 1] = 400; //y3
			_axis[3, 1] = -400; //y4

			_axis[0, 2] = 0; //z1
			_axis[1, 2] = 0; //z2
			_axis[2, 2] = 0; //z3
			_axis[3, 2] = 0; //z4

			_axis[0, 3] = 1;
			_axis[1, 3] = 1;
			_axis[2, 3] = 1;
			_axis[3, 3] = 1;
		}


		private void InitAxis()
		{
			BuildAxis();
			InitShiftMatrix(_k1, _l1, p);

			var axis = MultiplyMatrix(_axis, ShiftMartix);

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
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				f += 1;
				Clear();
				DrawSpecialFigure();
			}
			else
			{
				MessageBox.Show("Поворот доступен только специальной фигуре", "Внимание", MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
			}
		}

		private void rotateRightButton_Click(object sender, EventArgs e)
		{
			if (templatesComboBox.SelectedItem == "Вариант 14")
			{
				f -= 1;
				Clear();
				DrawSpecialFigure();
			}
			else
			{
				MessageBox.Show("Поворот доступен только специальной фигуре", "Внимание", MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
			}
		}

		private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sizeComboBox.SelectedItem == "0.5")
			{
				_size = 25;

			}
			else if ((int)sizeComboBox.SelectedItem == 1)
			{
				_size = 50;
			}
			else if ((int)sizeComboBox.SelectedItem == 2)
			{
				_size = 100;
			}
			else if ((int)sizeComboBox.SelectedItem == 3)
			{
				_size = 150;
			}
		}
	}
}