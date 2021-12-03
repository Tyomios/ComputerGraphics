using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ComputerGraphics
{
	/// <summary>
	/// Вершина 
	/// </summary>
	public class Node
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public Node(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public Node()
		{

		}
	}
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

		private int k, l, p;

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
			
			templatesComboBox.Items.Add("Фигура");

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

			_rotateTimer.Interval = 20;
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
			k = _k1;
			l = _l1;
			p = 1;
			f = 0;
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
			
			if (templatesComboBox.SelectedItem == "Фигура")
			{
				Clear();
				DrawSpecialFigure();
			}
		}


		private void leftShiftButton_Click(object sender, EventArgs e)
		{
			
			if (templatesComboBox.SelectedItem == "Фигура")
			{
				k -= 5;
				
				Clear();
				DrawSpecialFigure();
			}

		}

		private void upShiftButton_Click(object sender, EventArgs e)
		{
			if (templatesComboBox.SelectedItem == "Фигура")
			{
				l -= 5;
				Clear();
				DrawSpecialFigure();
			}
		}

		private void downShiftButton_Click(object sender, EventArgs e)
		{
			
			if (templatesComboBox.SelectedItem == "Фигура")
			{
				l += 5;
				Clear();
				DrawSpecialFigure();
			}
		}

		private void rightShiftButton_Click(object sender, EventArgs e)
		{
			
			if (templatesComboBox.SelectedItem == "Фигура")
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

			var edges = GetEdges(rect);

			foreach (var edge in edges)
			{
				if (CheckEdge(edge[0], edge[1], edge[2], GetW(rect)))
				{
					g.DrawLine(_pen, (float)edge[0].X, (float)edge[0].Y, (float)edge[1].X, (float)edge[1].Y);
					g.DrawLine(_pen, (float)edge[0].X, (float)edge[0].Y, (float)edge[2].X, (float)edge[2].Y);
					g.DrawLine(_pen, (float)edge[2].X, (float)edge[2].Y, (float)edge[1].X, (float)edge[1].Y);
				}
			}

			// соединение верхней вершины
			//g.DrawLine(_pen, (float)rect[1, 0], (float)rect[1, 1], (float)rect[3, 0], (float)rect[3, 1]); //дальняя
			//g.DrawLine(_pen, (float)rect[1, 0], (float)rect[1, 1], (float)rect[2, 0], (float)rect[2, 1]); // ближняя
			//g.DrawLine(_pen, (float)rect[1, 0], (float)rect[1, 1], (float)rect[4, 0], (float)rect[4, 1]); //правая
			//g.DrawLine(_pen, (float)rect[1, 0], (float)rect[1, 1], (float)rect[0, 0], (float)rect[0, 1]); //правая

			//// соединение нижней вершины
			//g.DrawLine(_pen, (float)rect[5, 0], (float)rect[5, 1], (float)rect[3, 0], (float)rect[3, 1]); //дальняя
			//g.DrawLine(_pen, (float)rect[5, 0], (float)rect[5, 1], (float)rect[2, 0], (float)rect[2, 1]); // ближняя
			//g.DrawLine(_pen, (float)rect[5, 0], (float)rect[5, 1], (float)rect[4, 0], (float)rect[4, 1]); //правая
			//g.DrawLine(_pen, (float)rect[5, 0], (float)rect[5, 1], (float)rect[0, 0], (float)rect[0, 1]); //правая

			//// соединение соседних 
			//g.DrawLine(_pen, (float)rect[0, 0], (float)rect[0, 1], (float)rect[2, 0], (float)rect[2, 1]); // ближнаяя с левой
			//g.DrawLine(_pen, (float)rect[0, 0], (float)rect[0, 1], (float)rect[3, 0], (float)rect[3, 1]); // дальняя с левой
			//g.DrawLine(_pen, (float)rect[4, 0], (float)rect[4, 1], (float)rect[3, 0], (float)rect[3, 1]); // правая с дальней
			//g.DrawLine(_pen, (float)rect[4, 0], (float)rect[4, 1], (float)rect[2, 0], (float)rect[2, 1]); // правая с бижней

			//var leftNode = new Node(rect[0, 0], rect[0, 1], rect[0, 2]);
			//var upNode = new Node(rect[1, 0], rect[1, 1], rect[1, 2]);
			//var nearNode = new Node(rect[2, 0], rect[2, 1], rect[2, 2]);
			//var farNode = new Node(rect[3, 0], rect[3, 1], rect[3, 2]);
			//var rightNode = new Node(rect[4, 0], rect[4, 1], rect[4, 2]);
			//var downNode = new Node(rect[5, 0], rect[5, 1], rect[5, 2]);

			////g.DrawRectangle(new Pen(Color.Red), (float)leftNode.X, (float)leftNode.Y, 1, 1);
			////g.DrawRectangle(new Pen(Color.Blue), (float)rightNode.X, (float)rightNode.Y, 2, 2);
			//g.DrawRectangle(new Pen(Color.GreenYellow), (float)downNode.X, (float)downNode.Y, 2, 2);
			//g.DrawRectangle(new Pen(Color.Orange), (float)upNode.X, (float)upNode.Y, 2, 2);
			//g.DrawRectangle(new Pen(Color.Red), (float)nearNode.X, (float)nearNode.Y, 2, 2);
			//g.DrawRectangle(new Pen(Color.Blue), (float)farNode.X, (float)farNode.Y, 2, 2);

			if (rotateAxisCheckBox.Checked)
			{
				var axisPen = new Pen(_pen.Color);
				axisPen.DashStyle = DashStyle.Dash;
				g.DrawLine(axisPen, (float)rect[1, 0], (float)rect[1, 1] - 15, (float)rect[5, 0], (float)rect[5, 1] + 15);
			}
			

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

		private Node GetW(double[,] rect)
		{
			var W = new Node();
			for (int i = 0; i < 6; i++)
			{
				W.X += rect[i, 0];
				W.Y += rect[i, 1];
				W.Z += rect[i, 2];
			}

			W.X /= 6;
			W.Y /= 6;
			W.Z /= 6;
			return W;
		}


		private bool CheckEdge(Node fPoint, Node sPoint, Node thPoint, Node W)
		{
			var vect1X = fPoint.X - sPoint.X;
			var vect1Y = fPoint.Y - sPoint.Y;
			var vect1Z = fPoint.Z - sPoint.Z;

			var vect2X = thPoint.X - sPoint.X;
			var vect2Y = thPoint.Y - sPoint.Y;
			var vect2Z = thPoint.Z - sPoint.Z;

			var A = vect1Y * vect2Z - vect1Y * vect1Z;
			var B = vect1Z * vect2X - vect2Z * vect1X;
			var C = vect1X * vect2Y - vect2X * vect1Y;

			var D = -(A * fPoint.X + B * fPoint.Y + C * fPoint.Z);
			var m = -Math.Sign(A * W.X + B * W.Y + C * W.Z + D);

			A *= m;
			B *= m;
			C *= m;
			D *= m;

			var VisionPoint = new Node();
			VisionPoint.X = 0;
			VisionPoint.Y = 0;
			VisionPoint.Z = 1000;

			var statement = A * VisionPoint.X + B * VisionPoint.Y + C * VisionPoint.Z + D;

			if (statement > 0)
			{
				return true;
			}

			return false;
		}


		private List<List<Node>> GetEdges(double[,] rect)
		{
			var leftNode = new Node(rect[0,0], rect[0, 1], rect[0, 2]);
			var upNode = new Node(rect[1,0], rect[1, 1], rect[1, 2]);
			var farNode = new Node(rect[2,0], rect[2, 1], rect[2, 2]);
			var nearNode = new Node(rect[3,0], rect[3, 1], rect[3, 2]);
			var rightNode = new Node(rect[4,0], rect[4, 1], rect[4, 2]);
			var downNode = new Node(rect[5,0], rect[5, 1], rect[5, 2]);
			

			var result = new List<List<Node>>();

			result.Add(new List<Node>() 
			{
				upNode, leftNode, nearNode
			});

			result.Add(new List<Node>()
			{
				upNode, leftNode, farNode
			});

			result.Add(new List<Node>()
			{
				upNode, rightNode, nearNode
			});

			result.Add(new List<Node>()
			{
				upNode, rightNode, farNode
			});


			result.Add(new List<Node>()
			{
				downNode, leftNode, nearNode
			});

			result.Add(new List<Node>()
			{
				downNode, leftNode, farNode
			});

			result.Add(new List<Node>()
			{
				downNode, rightNode, nearNode
			});

			result.Add(new List<Node>()
			{
				downNode, rightNode, farNode
			});

			return result;
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
			if (templatesComboBox.SelectedItem == "Фигура")
			{
				f += 1;
				Clear();
				DrawSpecialFigure();
			}
			else
			{
				MessageBox.Show("Создайте фигуру", "Внимание", MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
			}
		}

		private void rotateRightButton_Click(object sender, EventArgs e)
		{
			if (templatesComboBox.SelectedItem == "Фигура")
			{
				f -= 1;
				Clear();
				DrawSpecialFigure();
			}
			else
			{
				MessageBox.Show("Создайте фигуру", "Внимание", MessageBoxButtons.OK,
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