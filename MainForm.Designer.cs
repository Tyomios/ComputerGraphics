﻿
namespace ComputerGraphics
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.createFirstMartixButton = new System.Windows.Forms.Button();
			this.createSecondMatrixButton = new System.Windows.Forms.Button();
			this.resultButton = new System.Windows.Forms.Button();
			this.saveResultButton = new System.Windows.Forms.Button();
			this.matrixSizeLabel = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.firstMatrixStatusLabel = new System.Windows.Forms.Label();
			this.secondMatrixStatusLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// createFirstMartixButton
			// 
			this.createFirstMartixButton.Location = new System.Drawing.Point(13, 39);
			this.createFirstMartixButton.Name = "createFirstMartixButton";
			this.createFirstMartixButton.Size = new System.Drawing.Size(136, 39);
			this.createFirstMartixButton.TabIndex = 0;
			this.createFirstMartixButton.Text = "Создать первую матрицу";
			this.createFirstMartixButton.UseVisualStyleBackColor = true;
			// 
			// createSecondMatrixButton
			// 
			this.createSecondMatrixButton.Location = new System.Drawing.Point(12, 84);
			this.createSecondMatrixButton.Name = "createSecondMatrixButton";
			this.createSecondMatrixButton.Size = new System.Drawing.Size(137, 42);
			this.createSecondMatrixButton.TabIndex = 1;
			this.createSecondMatrixButton.Text = "Создать вторую матрицу";
			this.createSecondMatrixButton.UseVisualStyleBackColor = true;
			// 
			// resultButton
			// 
			this.resultButton.Location = new System.Drawing.Point(306, 150);
			this.resultButton.Name = "resultButton";
			this.resultButton.Size = new System.Drawing.Size(136, 23);
			this.resultButton.TabIndex = 2;
			this.resultButton.Text = "Результат";
			this.resultButton.UseVisualStyleBackColor = true;
			// 
			// saveResultButton
			// 
			this.saveResultButton.Location = new System.Drawing.Point(13, 132);
			this.saveResultButton.Name = "saveResultButton";
			this.saveResultButton.Size = new System.Drawing.Size(136, 41);
			this.saveResultButton.TabIndex = 3;
			this.saveResultButton.Text = "Сохранить результат";
			this.saveResultButton.UseVisualStyleBackColor = true;
			// 
			// matrixSizeLabel
			// 
			this.matrixSizeLabel.AutoSize = true;
			this.matrixSizeLabel.Location = new System.Drawing.Point(13, 13);
			this.matrixSizeLabel.Name = "matrixSizeLabel";
			this.matrixSizeLabel.Size = new System.Drawing.Size(30, 15);
			this.matrixSizeLabel.TabIndex = 4;
			this.matrixSizeLabel.Text = "Size:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(49, 10);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 23);
			this.textBox1.TabIndex = 5;
			// 
			// firstMatrixStatusLabel
			// 
			this.firstMatrixStatusLabel.AutoSize = true;
			this.firstMatrixStatusLabel.Location = new System.Drawing.Point(155, 51);
			this.firstMatrixStatusLabel.Name = "firstMatrixStatusLabel";
			this.firstMatrixStatusLabel.Size = new System.Drawing.Size(68, 15);
			this.firstMatrixStatusLabel.TabIndex = 6;
			this.firstMatrixStatusLabel.Text = "Не создана";
			// 
			// secondMatrixStatusLabel
			// 
			this.secondMatrixStatusLabel.AutoSize = true;
			this.secondMatrixStatusLabel.Location = new System.Drawing.Point(155, 98);
			this.secondMatrixStatusLabel.Name = "secondMatrixStatusLabel";
			this.secondMatrixStatusLabel.Size = new System.Drawing.Size(68, 15);
			this.secondMatrixStatusLabel.TabIndex = 7;
			this.secondMatrixStatusLabel.Text = "Не создана";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 183);
			this.Controls.Add(this.secondMatrixStatusLabel);
			this.Controls.Add(this.firstMatrixStatusLabel);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.matrixSizeLabel);
			this.Controls.Add(this.saveResultButton);
			this.Controls.Add(this.resultButton);
			this.Controls.Add(this.createSecondMatrixButton);
			this.Controls.Add(this.createFirstMartixButton);
			this.Name = "MainForm";
			this.Text = "Matrix calculator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button createFirstMartixButton;
		private System.Windows.Forms.Button createSecondMatrixButton;
		private System.Windows.Forms.Button resultButton;
		private System.Windows.Forms.Button saveResultButton;
		private System.Windows.Forms.Label matrixSizeLabel;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label firstMatrixStatusLabel;
		private System.Windows.Forms.Label secondMatrixStatusLabel;
	}
}

