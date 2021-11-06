
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
			this.simpleCDARadioButton = new System.Windows.Forms.RadioButton();
			this.pointDrawLabel = new System.Windows.Forms.Label();
			this.panel = new System.Windows.Forms.Panel();
			this.templatesComboBox = new System.Windows.Forms.ComboBox();
			this.penSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.prevPenCheckBox = new System.Windows.Forms.CheckBox();
			this.fatPencheckBox = new System.Windows.Forms.CheckBox();
			this.colorPickerButton = new System.Windows.Forms.Button();
			this.yNLabel = new System.Windows.Forms.Label();
			this.xNLabel = new System.Windows.Forms.Label();
			this.yNTextBox = new System.Windows.Forms.TextBox();
			this.xNTextBox = new System.Windows.Forms.TextBox();
			this.yKLabel = new System.Windows.Forms.Label();
			this.xKLabel = new System.Windows.Forms.Label();
			this.lineBuildButton = new System.Windows.Forms.Button();
			this.yKtextBox = new System.Windows.Forms.TextBox();
			this.xKtextBox = new System.Windows.Forms.TextBox();
			this.templatesLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel.SuspendLayout();
			this.penSettingsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// clearButton
			// 
			this.clearButton.Location = new System.Drawing.Point(77, 542);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(136, 23);
			this.clearButton.TabIndex = 2;
			this.clearButton.Text = "Очистить";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox.Location = new System.Drawing.Point(12, 28);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(351, 572);
			this.pictureBox.TabIndex = 3;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.simpleCDARadioButton);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(14, 20);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(254, 113);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Выберите алгоритм";
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
			// pointDrawLabel
			// 
			this.pointDrawLabel.AutoSize = true;
			this.pointDrawLabel.Location = new System.Drawing.Point(14, 146);
			this.pointDrawLabel.Name = "pointDrawLabel";
			this.pointDrawLabel.Size = new System.Drawing.Size(120, 15);
			this.pointDrawLabel.TabIndex = 4;
			this.pointDrawLabel.Text = "Введите координаты";
			this.pointDrawLabel.Click += new System.EventHandler(this.pointDrawLabel_Click);
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.SystemColors.Control;
			this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel.Controls.Add(this.templatesLabel);
			this.panel.Controls.Add(this.templatesComboBox);
			this.panel.Controls.Add(this.penSettingsGroupBox);
			this.panel.Controls.Add(this.yNLabel);
			this.panel.Controls.Add(this.xNLabel);
			this.panel.Controls.Add(this.yNTextBox);
			this.panel.Controls.Add(this.xNTextBox);
			this.panel.Controls.Add(this.yKLabel);
			this.panel.Controls.Add(this.xKLabel);
			this.panel.Controls.Add(this.lineBuildButton);
			this.panel.Controls.Add(this.yKtextBox);
			this.panel.Controls.Add(this.xKtextBox);
			this.panel.Controls.Add(this.groupBox1);
			this.panel.Controls.Add(this.pointDrawLabel);
			this.panel.Controls.Add(this.clearButton);
			this.panel.Location = new System.Drawing.Point(369, 28);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(285, 572);
			this.panel.TabIndex = 5;
			// 
			// templatesComboBox
			// 
			this.templatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.templatesComboBox.FormattingEnabled = true;
			this.templatesComboBox.Location = new System.Drawing.Point(92, 315);
			this.templatesComboBox.Name = "templatesComboBox";
			this.templatesComboBox.Size = new System.Drawing.Size(121, 23);
			this.templatesComboBox.TabIndex = 14;
			this.templatesComboBox.SelectedIndexChanged += new System.EventHandler(this.templatesComboBox_SelectedIndexChanged);
			// 
			// penSettingsGroupBox
			// 
			this.penSettingsGroupBox.Controls.Add(this.prevPenCheckBox);
			this.penSettingsGroupBox.Controls.Add(this.fatPencheckBox);
			this.penSettingsGroupBox.Controls.Add(this.colorPickerButton);
			this.penSettingsGroupBox.Location = new System.Drawing.Point(22, 388);
			this.penSettingsGroupBox.Name = "penSettingsGroupBox";
			this.penSettingsGroupBox.Size = new System.Drawing.Size(246, 148);
			this.penSettingsGroupBox.TabIndex = 6;
			this.penSettingsGroupBox.TabStop = false;
			this.penSettingsGroupBox.Text = "Настройка пера";
			// 
			// prevPenCheckBox
			// 
			this.prevPenCheckBox.AutoSize = true;
			this.prevPenCheckBox.Location = new System.Drawing.Point(138, 68);
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
			this.fatPencheckBox.Location = new System.Drawing.Point(138, 32);
			this.fatPencheckBox.Name = "fatPencheckBox";
			this.fatPencheckBox.Size = new System.Drawing.Size(107, 19);
			this.fatPencheckBox.TabIndex = 15;
			this.fatPencheckBox.Text = "Жирная линия";
			this.fatPencheckBox.UseVisualStyleBackColor = true;
			this.fatPencheckBox.CheckedChanged += new System.EventHandler(this.fatPencheckBox_CheckedChanged);
			// 
			// colorPickerButton
			// 
			this.colorPickerButton.Location = new System.Drawing.Point(15, 32);
			this.colorPickerButton.Name = "colorPickerButton";
			this.colorPickerButton.Size = new System.Drawing.Size(49, 38);
			this.colorPickerButton.TabIndex = 14;
			this.colorPickerButton.Text = "Цвет пера";
			this.colorPickerButton.UseVisualStyleBackColor = true;
			this.colorPickerButton.Click += new System.EventHandler(this.colorPickerButton_Click);
			// 
			// yNLabel
			// 
			this.yNLabel.AutoSize = true;
			this.yNLabel.Location = new System.Drawing.Point(162, 219);
			this.yNLabel.Name = "yNLabel";
			this.yNLabel.Size = new System.Drawing.Size(37, 15);
			this.yNLabel.TabIndex = 13;
			this.yNLabel.Text = "Y нач";
			// 
			// xNLabel
			// 
			this.xNLabel.AutoSize = true;
			this.xNLabel.Location = new System.Drawing.Point(160, 177);
			this.xNLabel.Name = "xNLabel";
			this.xNLabel.Size = new System.Drawing.Size(37, 15);
			this.xNLabel.TabIndex = 12;
			this.xNLabel.Text = "X нач";
			// 
			// yNTextBox
			// 
			this.yNTextBox.Location = new System.Drawing.Point(205, 216);
			this.yNTextBox.Name = "yNTextBox";
			this.yNTextBox.Size = new System.Drawing.Size(63, 23);
			this.yNTextBox.TabIndex = 11;
			// 
			// xNTextBox
			// 
			this.xNTextBox.Location = new System.Drawing.Point(205, 174);
			this.xNTextBox.Name = "xNTextBox";
			this.xNTextBox.Size = new System.Drawing.Size(63, 23);
			this.xNTextBox.TabIndex = 10;
			// 
			// yKLabel
			// 
			this.yKLabel.AutoSize = true;
			this.yKLabel.Location = new System.Drawing.Point(22, 219);
			this.yKLabel.Name = "yKLabel";
			this.yKLabel.Size = new System.Drawing.Size(37, 15);
			this.yKLabel.TabIndex = 9;
			this.yKLabel.Text = "Y кон";
			// 
			// xKLabel
			// 
			this.xKLabel.AutoSize = true;
			this.xKLabel.Location = new System.Drawing.Point(20, 177);
			this.xKLabel.Name = "xKLabel";
			this.xKLabel.Size = new System.Drawing.Size(37, 15);
			this.xKLabel.TabIndex = 8;
			this.xKLabel.Text = "X кон";
			// 
			// lineBuildButton
			// 
			this.lineBuildButton.Location = new System.Drawing.Point(104, 245);
			this.lineBuildButton.Name = "lineBuildButton";
			this.lineBuildButton.Size = new System.Drawing.Size(75, 40);
			this.lineBuildButton.TabIndex = 7;
			this.lineBuildButton.Text = "Построить отрезок";
			this.lineBuildButton.UseVisualStyleBackColor = true;
			this.lineBuildButton.Click += new System.EventHandler(this.lineBuildButton_Click);
			// 
			// yKtextBox
			// 
			this.yKtextBox.Location = new System.Drawing.Point(65, 216);
			this.yKtextBox.Name = "yKtextBox";
			this.yKtextBox.Size = new System.Drawing.Size(63, 23);
			this.yKtextBox.TabIndex = 6;
			// 
			// xKtextBox
			// 
			this.xKtextBox.Location = new System.Drawing.Point(65, 174);
			this.xKtextBox.Name = "xKtextBox";
			this.xKtextBox.Size = new System.Drawing.Size(63, 23);
			this.xKtextBox.TabIndex = 5;
			// 
			// templatesLabel
			// 
			this.templatesLabel.AutoSize = true;
			this.templatesLabel.Location = new System.Drawing.Point(25, 318);
			this.templatesLabel.Name = "templatesLabel";
			this.templatesLabel.Size = new System.Drawing.Size(61, 15);
			this.templatesLabel.TabIndex = 15;
			this.templatesLabel.Text = "Шаблоны";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 612);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.pictureBox);
			this.Name = "MainForm";
			this.Text = "Matrix calculator";
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
		private System.Windows.Forms.Label pointDrawLabel;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button lineBuildButton;
		private System.Windows.Forms.TextBox yKtextBox;
		private System.Windows.Forms.TextBox xKtextBox;
		private System.Windows.Forms.Label xKLabel;
		private System.Windows.Forms.Label yKLabel;
		private System.Windows.Forms.Label yNLabel;
		private System.Windows.Forms.Label xNLabel;
		private System.Windows.Forms.TextBox yNTextBox;
		private System.Windows.Forms.TextBox xNTextBox;
		private System.Windows.Forms.Button colorPickerButton;
		private System.Windows.Forms.GroupBox penSettingsGroupBox;
		private System.Windows.Forms.CheckBox fatPencheckBox;
		private System.Windows.Forms.CheckBox prevPenCheckBox;
		private System.Windows.Forms.ComboBox templatesComboBox;
		private System.Windows.Forms.Label templatesLabel;
	}
}

