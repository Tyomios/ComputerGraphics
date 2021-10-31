using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
			actionsComboBox.Items.Add("Выберите действие");
			actionsComboBox.Items.Add("Сложение");
			actionsComboBox.Items.Add("Вычитание");
			actionsComboBox.Items.Add("Произведение");

			actionsComboBox.SelectedItem = "Выберите действие";
			resultRichTextBox.ReadOnly = true;
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
			actionsComboBox.Enabled = false;
			saveResultButton.Enabled = false;
		}

		private void UnlockControls()
		{
			createFirstMatrixButton.Enabled = true;
			createSecondMatrixButton.Enabled = true;
			actionsComboBox.Enabled = true;
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

			secondMatrix = matrixForm.Matrix;
			secondMatrixStatusLabel.Text = "Матрица создана";
		}

		private void saveResultButton_Click(object sender, EventArgs e)
		{
			if (resultRichTextBox.Text == "" || resultMatrix == null)
			{
				MessageBox.Show("Выполните доступные операции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "MatrixCS.txt"))
			{
				byte[] info = new UTF8Encoding(true).GetBytes(resultRichTextBox.Text);
				fs.Write(info, 0, info.Length);
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			resultRichTextBox.Clear();
			if (CheckMatrix())
			{
				return;
			}
			if (firstMatrix.Size != secondMatrix.Size)
			{
				MessageBox.Show("Размеры матрицы не совпадают", "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}
			if (actionsComboBox.SelectedItem == "Сложение")
			{
				resultMatrix = firstMatrix.AddictionMatrix(secondMatrix);
				resultRichTextBox.Text = GetMatrixTextValue(resultMatrix);
			}
			if (actionsComboBox.SelectedItem == "Вычитание")
			{
				resultMatrix = firstMatrix.SubtractMatrix(secondMatrix);
				resultRichTextBox.Text = GetMatrixTextValue(resultMatrix);
			}
			if (actionsComboBox.SelectedItem == "Произведение")
			{
				resultMatrix = firstMatrix.MultiplyMatrix(secondMatrix);
				resultRichTextBox.Text = GetMatrixTextValue(resultMatrix);
			}
		}

		private string GetMatrixTextValue(Matrix matrix)
		{
			string result = "";
			var stringIndex = 0;
			for (int i = 0; i < _matrixSize; i++)
			{
				for (int j = 0; j < _matrixSize; j++)
				{
					result += $"{matrix.MatrixValues[i, j]} \t";
				}

				result += "\n";
			}

			return result;
		}

		private bool CheckMatrix()
		{
			if (firstMatrix == null && secondMatrix == null)
			{
				return true;
			}

			return false;
		}
	}
}
