using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics
{
	// TODO: настройка стиля линии - пунктир, толстая, сплошная
	// TODO: шаблоны отрезков/прямоугольников/треугольников/14 вариант
	// TODO: генерация окружности по алгоритму Брезенхема
	public partial class MainForm : Form
	{
		// начальные x y и конечные.
		private double xn, yn, xk, yk;

		private Pen _pen = new Pen(Color.Black, 1);

		private void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			simpleCDADraw(e);
		}

		/// <summary>
		/// Отрисвока линии алгоритмом обычный ЦДА.
		/// </summary>
		/// <param name="e"></param>
		private void simpleCDADraw(MouseEventArgs e, double xk = 0, double yk = 0)
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
			n = 100;
			xt = xn;
			yt = yn;

			for (i = 1; i <= n; i++)
			{

				var g = Graphics.FromHwnd(pictureBox.Handle);

				g.DrawRectangle(_pen, (int)xt, (int)yt, 2, 2);
				//Рисуем закрашенный прямоугольник:
				//Объявляем объект "redBrush", задающий цвет кисти
				//SolidBrush redBrush = new SolidBrush(Color.Red);
				//Рисуем закрашенный прямоугольник
				//g.FillRectangle(redBrush, (int)xt, (int)yt, 2, 2);
				xt = xt + dx / n;
				yt = yt + dy / n;
			}
		}

		private void clearButton_Click(object sender, EventArgs e)
		{
			pictureBox.Image = null;
		}

		private void pointDrawLabel_Click(object sender, EventArgs e)
		{

		}

		private void lineBuildButton_Click(object sender, EventArgs e)
		{
			try
			{
				xk = Convert.ToDouble(xKtextBox.Text);
				xn = Convert.ToDouble(xNTextBox.Text);
				yk = Convert.ToDouble(yKtextBox.Text);
				yn = Convert.ToDouble(yNTextBox.Text);

			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (CheckPictureBoxSize(xk, yk) || CheckPictureBoxSize(xn, yn))
			{
				MessageBox.Show("Указанные координаты превосходят параметры элемента отображения",
					"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				xKtextBox.Text = String.Empty;
				yKtextBox.Text = String.Empty;
				yNTextBox.Text = "0";
				xNTextBox.Text = "0";
				return;
			}
			if (simpleCDARadioButton.Checked)
			{
				int i, n;
				double xt, yt, dx, dy;

				dx = xk - xn;
				dy = yk - yn;
				n = 100;
				xt = xn;
				yt = yn;

				for (i = 1; i <= n; i++)
				{

					var g = Graphics.FromHwnd(pictureBox.Handle);

					g.DrawRectangle(_pen, (int)xt, (int)yt, 2, 2);
					//Рисуем закрашенный прямоугольник:
					//Объявляем объект "redBrush", задающий цвет кисти
					//SolidBrush redBrush = new SolidBrush(Color.Red);
					//Рисуем закрашенный прямоугольник
					//g.FillRectangle(redBrush, (int)xt, (int)yt, 2, 2);
					xt = xt + dx / n;
					yt = yt + dy / n;
				}
			}
			else
			{
				MessageBox.Show("Выберите алгоритм", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}

		private bool CheckPictureBoxSize(double x, double y)
		{
			if (pictureBox.Width < x || pictureBox.Height < y)
			{
				return true;
			}

			return false;
		}

		private void colorPickerButton_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog1 = new ColorDialog();
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				_pen.Color = colorDialog1.Color;
			}
		}

		public MainForm()
		{
			InitializeComponent();
		}

		private void simpleCDARadioButton_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (simpleCDARadioButton.Checked)
			{
				xn = e.X;
				yn = e.Y;
			}

			else MessageBox.Show("Вы не выбрали алгоритм вывода фигуры!",
								"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
