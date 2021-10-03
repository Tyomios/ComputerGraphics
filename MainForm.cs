using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace ComputerGraphics
{
	public partial class MainForm : Form
	{
		private int _matrixSize;

		private Matrix firstMatrix;

		private Matrix secondMatrix;

		private Matrix resultMatrix;

		public MainForm()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (matrixSizeTextBox.Text == "")
			{
				return;
			}

			var inputSize = Convert.ToInt32(matrixSizeTextBox.Text);
			if (inputSize > 4)
			{
				matrixSizeTextBox.BackColor = Color.Orange;
			}

			_matrixSize = inputSize;
		}
	}
}
