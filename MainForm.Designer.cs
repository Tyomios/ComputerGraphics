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
			this.clearButton = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.fillRadioButton = new System.Windows.Forms.RadioButton();
			this.simpleCDARadioButton = new System.Windows.Forms.RadioButton();
			this.panel = new System.Windows.Forms.Panel();
			this.templatesLabel = new System.Windows.Forms.Label();
			this.templatesComboBox = new System.Windows.Forms.ComboBox();
			this.penSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.penSettingsComboBox = new System.Windows.Forms.ComboBox();
			this.prevPenCheckBox = new System.Windows.Forms.CheckBox();
			this.fatPencheckBox = new System.Windows.Forms.CheckBox();
			this.colorPickerButton = new System.Windows.Forms.Button();
			this.fillStackRadioButton = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel.SuspendLayout();
			this.penSettingsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// clearButton
			// 
			this.clearButton.Location = new System.Drawing.Point(72, 359);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(136, 23);
			this.clearButton.TabIndex = 2;
			this.clearButton.Text = "Очистить";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pictureBox.BackgroundImage = global::ComputerGraphics.Properties.Resources.panelBack;
			this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox.Location = new System.Drawing.Point(10, 30);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(350, 570);
			this.pictureBox.TabIndex = 3;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.fillStackRadioButton);
			this.groupBox1.Controls.Add(this.fillRadioButton);
			this.groupBox1.Controls.Add(this.simpleCDARadioButton);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(14, 20);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(254, 113);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Выберите алгоритм";
			// 
			// fillRadioButton
			// 
			this.fillRadioButton.AutoSize = true;
			this.fillRadioButton.Location = new System.Drawing.Point(6, 63);
			this.fillRadioButton.Name = "fillRadioButton";
			this.fillRadioButton.Size = new System.Drawing.Size(211, 19);
			this.fillRadioButton.TabIndex = 4;
			this.fillRadioButton.TabStop = true;
			this.fillRadioButton.Text = "Заливка (рекурсивный алгоритм)";
			this.fillRadioButton.UseVisualStyleBackColor = true;
			// 
			// simpleCDARadioButton
			// 
			this.simpleCDARadioButton.AutoSize = true;
			this.simpleCDARadioButton.Location = new System.Drawing.Point(6, 35);
			this.simpleCDARadioButton.Name = "simpleCDARadioButton";
			this.simpleCDARadioButton.Size = new System.Drawing.Size(108, 19);
			this.simpleCDARadioButton.TabIndex = 3;
			this.simpleCDARadioButton.TabStop = true;
			this.simpleCDARadioButton.Text = "Обычный ЦДА";
			this.simpleCDARadioButton.UseVisualStyleBackColor = true;
			this.simpleCDARadioButton.CheckedChanged += new System.EventHandler(this.simpleCDARadioButton_CheckedChanged);
			// 
			// panel
			// 
			this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel.BackColor = System.Drawing.SystemColors.Control;
			this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel.Controls.Add(this.templatesLabel);
			this.panel.Controls.Add(this.templatesComboBox);
			this.panel.Controls.Add(this.penSettingsGroupBox);
			this.panel.Controls.Add(this.groupBox1);
			this.panel.Controls.Add(this.clearButton);
			this.panel.Location = new System.Drawing.Point(370, 30);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(285, 395);
			this.panel.TabIndex = 5;
			// 
			// templatesLabel
			// 
			this.templatesLabel.AutoSize = true;
			this.templatesLabel.Location = new System.Drawing.Point(14, 155);
			this.templatesLabel.Name = "templatesLabel";
			this.templatesLabel.Size = new System.Drawing.Size(61, 15);
			this.templatesLabel.TabIndex = 15;
			this.templatesLabel.Text = "Шаблоны";
			// 
			// templatesComboBox
			// 
			this.templatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.templatesComboBox.FormattingEnabled = true;
			this.templatesComboBox.Location = new System.Drawing.Point(97, 152);
			this.templatesComboBox.Name = "templatesComboBox";
			this.templatesComboBox.Size = new System.Drawing.Size(135, 23);
			this.templatesComboBox.TabIndex = 14;
			this.templatesComboBox.SelectedIndexChanged += new System.EventHandler(this.templatesComboBox_SelectedIndexChanged);
			// 
			// penSettingsGroupBox
			// 
			this.penSettingsGroupBox.Controls.Add(this.penSettingsComboBox);
			this.penSettingsGroupBox.Controls.Add(this.prevPenCheckBox);
			this.penSettingsGroupBox.Controls.Add(this.fatPencheckBox);
			this.penSettingsGroupBox.Controls.Add(this.colorPickerButton);
			this.penSettingsGroupBox.Location = new System.Drawing.Point(14, 194);
			this.penSettingsGroupBox.Name = "penSettingsGroupBox";
			this.penSettingsGroupBox.Size = new System.Drawing.Size(254, 148);
			this.penSettingsGroupBox.TabIndex = 6;
			this.penSettingsGroupBox.TabStop = false;
			this.penSettingsGroupBox.Text = "Настройка пера";
			// 
			// penSettingsComboBox
			// 
			this.penSettingsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.penSettingsComboBox.FormattingEnabled = true;
			this.penSettingsComboBox.Location = new System.Drawing.Point(128, 72);
			this.penSettingsComboBox.Name = "penSettingsComboBox";
			this.penSettingsComboBox.Size = new System.Drawing.Size(49, 23);
			this.penSettingsComboBox.TabIndex = 17;
			this.penSettingsComboBox.SelectedIndexChanged += new System.EventHandler(this.penSettingsComboBox_SelectedIndexChanged);
			// 
			// prevPenCheckBox
			// 
			this.prevPenCheckBox.AutoSize = true;
			this.prevPenCheckBox.Location = new System.Drawing.Point(15, 109);
			this.prevPenCheckBox.Name = "prevPenCheckBox";
			this.prevPenCheckBox.Size = new System.Drawing.Size(73, 19);
			this.prevPenCheckBox.TabIndex = 16;
			this.prevPenCheckBox.Text = "Пунктир";
			this.prevPenCheckBox.UseVisualStyleBackColor = true;
			this.prevPenCheckBox.CheckedChanged += new System.EventHandler(this.prevPenCheckBox_CheckedChanged);
			// 
			// fatPencheckBox
			// 
			this.fatPencheckBox.AutoSize = true;
			this.fatPencheckBox.Location = new System.Drawing.Point(15, 74);
			this.fatPencheckBox.Name = "fatPencheckBox";
			this.fatPencheckBox.Size = new System.Drawing.Size(107, 19);
			this.fatPencheckBox.TabIndex = 15;
			this.fatPencheckBox.Text = "Жирная линия";
			this.fatPencheckBox.UseVisualStyleBackColor = true;
			this.fatPencheckBox.CheckedChanged += new System.EventHandler(this.fatPencheckBox_CheckedChanged);
			// 
			// colorPickerButton
			// 
			this.colorPickerButton.BackColor = System.Drawing.Color.Black;
			this.colorPickerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.colorPickerButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
			this.colorPickerButton.FlatAppearance.BorderSize = 10;
			this.colorPickerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
			this.colorPickerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
			this.colorPickerButton.ForeColor = System.Drawing.Color.White;
			this.colorPickerButton.Location = new System.Drawing.Point(15, 36);
			this.colorPickerButton.Name = "colorPickerButton";
			this.colorPickerButton.Size = new System.Drawing.Size(85, 25);
			this.colorPickerButton.TabIndex = 14;
			this.colorPickerButton.Text = "Цвет пера";
			this.colorPickerButton.UseVisualStyleBackColor = false;
			this.colorPickerButton.Click += new System.EventHandler(this.colorPickerButton_Click);
			// 
			// fillStackRadioButton
			// 
			this.fillStackRadioButton.AutoSize = true;
			this.fillStackRadioButton.Location = new System.Drawing.Point(6, 88);
			this.fillStackRadioButton.Name = "fillStackRadioButton";
			this.fillStackRadioButton.Size = new System.Drawing.Size(209, 19);
			this.fillStackRadioButton.TabIndex = 5;
			this.fillStackRadioButton.TabStop = true;
			this.fillStackRadioButton.Text = "Заливка (итеративный алгоритм)";
			this.fillStackRadioButton.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(659, 611);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.pictureBox);
			this.MinimumSize = new System.Drawing.Size(675, 650);
			this.Name = "MainForm";
			this.Text = "Растровые алгоритмы";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.penSettingsGroupBox.ResumeLayout(false);
			this.penSettingsGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton simpleCDARadioButton;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button colorPickerButton;
		private System.Windows.Forms.GroupBox penSettingsGroupBox;
		private System.Windows.Forms.CheckBox fatPencheckBox;
		private System.Windows.Forms.CheckBox prevPenCheckBox;
		private System.Windows.Forms.ComboBox templatesComboBox;
		private System.Windows.Forms.Label templatesLabel;
		private System.Windows.Forms.ComboBox penSettingsComboBox;
		private System.Windows.Forms.RadioButton fillRadioButton;
		private System.Windows.Forms.RadioButton fillStackRadioButton;
	}
}

