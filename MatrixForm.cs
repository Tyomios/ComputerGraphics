using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using TextBox = System.Windows.Forms.TextBox;

namespace ComputerGraphics
{
	public partial class MatrixForm : Form
	{
		private Matrix _matrix = new Matrix();

		private int _size;

		public int Size 
		{ 
			private get => _size;
			set
			{
				_size = value;
				if (value == 3)
				{
					LockOneField();
				}
				if (value == 2)
				{
					LockTwoFields();
				}
				if (value == 1)
				{
					LockThreeFields();
				}

				_matrix = new Matrix(value);
			}
		}

		public MatrixForm()
		{
			InitializeComponent();
		}


		public Matrix Matrix
		{
			get => _matrix;
			set
			{
				_matrix = value;
			}
		}

		private void LockOneField()
		{
			textBoxV3.Enabled = false;
			textBoxV7.Enabled = false;
			textBoxV11.Enabled = false;
			textBoxV12.Enabled = false;
			textBoxV13.Enabled = false;
			textBoxV14.Enabled = false;
			textBoxV15.Enabled = false;
		}

		private void LockTwoFields()
		{
			LockOneField();
			textBoxV2.Enabled = false;
			textBoxV6.Enabled = false;
			textBoxV8.Enabled = false;
			textBoxV9.Enabled = false;
			textBoxV10.Enabled = false;
		}

		private void LockThreeFields()
		{
			LockTwoFields();
			textBoxV1.Enabled = false;
			textBoxV4.Enabled = false;
			textBoxV5.Enabled = false;
		}

		private void autoInputButton_Click(object sender, EventArgs e)
		{
			var random = new Random();
			foreach (TextBox textbox in panel1.Controls)
			{
				if (textbox.Enabled)
				{
					textbox.Text = random.Next(-300, 700).ToString();
				}
				
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			CheckValues();
			var values = new List<double>();
			for (int i = 0; i < panel1.Controls.Count; i++)
			{
				var currentValue = (TextBox)panel1.Controls[i];
				if (currentValue.Enabled)
				{
					values.Add(Convert.ToDouble(currentValue.Text));
				}
			}

			var stringIndex = 0;
			for (int i = 0; i < Size; i++)
			{
				for (int j = 0; j < Size; j++)
				{
					Matrix.MatrixValues[i, j] = values[i + j + stringIndex];
				}

				stringIndex += Size - 1;
			}
			DialogResult = DialogResult.OK;
			Close();

		}

		private void CheckValues()
		{
			foreach (TextBox textbox in panel1.Controls)
			{
				foreach (var letter in textbox.Text)
				{
					if (!Char.IsNumber(letter) && letter != ',' && letter != '-')
					{
						MessageBox.Show("Уберите буквы из значений матрицы", "Ошибка", MessageBoxButtons.OK,
							MessageBoxIcon.Error);
						textbox.ForeColor = Color.Red;
						return;
					}
				}
			}
		}
	}
}
