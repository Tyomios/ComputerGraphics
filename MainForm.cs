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

		private void matrixSizeTextBox_TextChanged(object sender, EventArgs e)
		{
			if (matrixSizeTextBox.Text == "")
			{
				matrixSizeTextBox.BackColor = Color.White;
				UnlockControls();
				_matrixSize = 0;
				return;
			}

			try
			{
				var inputSize = Convert.ToInt32(matrixSizeTextBox.Text);
				if (inputSize > 4 || inputSize < 0)
				{
					matrixSizeTextBox.BackColor = Color.Orange;
					LockControls();
				}
				else if (inputSize <= 4 && inputSize > 0)
				{
					matrixSizeTextBox.BackColor = Color.White;
					UnlockControls();
				}

				_matrixSize = inputSize;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				LockControls();
			}
			
			
		}

		private void LockControls()
		{
			createFirstMatrixButton.Enabled = false;
			createSecondMatrixButton.Enabled = false;
			resultButton.Enabled = false;
			saveResultButton.Enabled = false;
		}

		private void UnlockControls()
		{
			createFirstMatrixButton.Enabled = true;
			createSecondMatrixButton.Enabled = true;
			resultButton.Enabled = true;
			saveResultButton.Enabled = true;
		}

		private void createFirstMatrixButton_Click(object sender, EventArgs e)
		{
			if (_matrixSize == 0)
			{
				MessageBox.Show("Выберете размер матрицы", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var matrixForm = new MatrixForm();
			matrixForm.Size = _matrixSize;
			var result =  matrixForm.ShowDialog();
			if (result != DialogResult.OK)
			{
				return;
			}

			firstMatrix = matrixForm.Matrix;
			firstMatrixStatusLabel.Text = "Матрица создана";
		}

		private void createSecondMatrixButton_Click(object sender, EventArgs e)
		{
			if (_matrixSize == 0)
			{
				MessageBox.Show("Выберете размер матрицы", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var matrixForm = new MatrixForm();
			matrixForm.Size = _matrixSize;
			var result = matrixForm.ShowDialog();
			if (result != DialogResult.OK)
			{
				return;
			}

			firstMatrix = matrixForm.Matrix;
			firstMatrixStatusLabel.Text = "Матрица создана";
		}

		private void resultButton_Click(object sender, EventArgs e)
		{

		}

		private void saveResultButton_Click(object sender, EventArgs e)
		{

		}
	}
}
