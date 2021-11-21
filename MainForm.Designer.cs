
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
			this.panel = new System.Windows.Forms.Panel();
			this.stopButton = new System.Windows.Forms.Button();
			this.leftShiftButton = new System.Windows.Forms.Button();
			this.downShiftButton = new System.Windows.Forms.Button();
			this.rightShiftButton = new System.Windows.Forms.Button();
			this.upShiftButton = new System.Windows.Forms.Button();
			this.shiftLabel = new System.Windows.Forms.Label();
			this.templatesLabel = new System.Windows.Forms.Label();
			this.templatesComboBox = new System.Windows.Forms.ComboBox();
			this.penSettingsGroupBox = new System.Windows.Forms.GroupBox();
			this.penSettingsComboBox = new System.Windows.Forms.ComboBox();
			this.prevPenCheckBox = new System.Windows.Forms.CheckBox();
			this.fatPencheckBox = new System.Windows.Forms.CheckBox();
			this.colorPickerButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.panel.SuspendLayout();
			this.penSettingsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// clearButton
			// 
			this.clearButton.Location = new System.Drawing.Point(71, 199);
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
			this.pictureBox.Size = new System.Drawing.Size(375, 570);
			this.pictureBox.TabIndex = 3;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// panel
			// 
			this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel.BackColor = System.Drawing.SystemColors.Control;
			this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel.Controls.Add(this.stopButton);
			this.panel.Controls.Add(this.leftShiftButton);
			this.panel.Controls.Add(this.downShiftButton);
			this.panel.Controls.Add(this.rightShiftButton);
			this.panel.Controls.Add(this.upShiftButton);
			this.panel.Controls.Add(this.shiftLabel);
			this.panel.Controls.Add(this.templatesLabel);
			this.panel.Controls.Add(this.templatesComboBox);
			this.panel.Controls.Add(this.penSettingsGroupBox);
			this.panel.Controls.Add(this.clearButton);
			this.panel.Location = new System.Drawing.Point(395, 30);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(285, 465);
			this.panel.TabIndex = 5;
			// 
			// stopButton
			// 
			this.stopButton.Location = new System.Drawing.Point(102, 306);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(75, 23);
			this.stopButton.TabIndex = 21;
			this.stopButton.Text = "стоп";
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
			// 
			// leftShiftButton
			// 
			this.leftShiftButton.Location = new System.Drawing.Point(14, 306);
			this.leftShiftButton.Name = "leftShiftButton";
			this.leftShiftButton.Size = new System.Drawing.Size(75, 23);
			this.leftShiftButton.TabIndex = 20;
			this.leftShiftButton.Text = "влево";
			this.leftShiftButton.UseVisualStyleBackColor = true;
			this.leftShiftButton.Click += new System.EventHandler(this.leftShiftButton_Click);
			// 
			// downShiftButton
			// 
			this.downShiftButton.Location = new System.Drawing.Point(102, 347);
			this.downShiftButton.Name = "downShiftButton";
			this.downShiftButton.Size = new System.Drawing.Size(75, 23);
			this.downShiftButton.TabIndex = 19;
			this.downShiftButton.Text = "вниз";
			this.downShiftButton.UseVisualStyleBackColor = true;
			this.downShiftButton.Click += new System.EventHandler(this.downShiftButton_Click);
			// 
			// rightShiftButton
			// 
			this.rightShiftButton.Location = new System.Drawing.Point(193, 306);
			this.rightShiftButton.Name = "rightShiftButton";
			this.rightShiftButton.Size = new System.Drawing.Size(75, 23);
			this.rightShiftButton.TabIndex = 18;
			this.rightShiftButton.Text = "вправо";
			this.rightShiftButton.UseVisualStyleBackColor = true;
			this.rightShiftButton.Click += new System.EventHandler(this.rightShiftButton_Click);
			this.rightShiftButton.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rightShiftButton_KeyPress);
			this.rightShiftButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rightShiftButton_KeyUp);
			// 
			// upShiftButton
			// 
			this.upShiftButton.Location = new System.Drawing.Point(102, 268);
			this.upShiftButton.Name = "upShiftButton";
			this.upShiftButton.Size = new System.Drawing.Size(75, 23);
			this.upShiftButton.TabIndex = 17;
			this.upShiftButton.Text = "вверх";
			this.upShiftButton.UseVisualStyleBackColor = true;
			this.upShiftButton.Click += new System.EventHandler(this.upShiftButton_Click);
			// 
			// shiftLabel
			// 
			this.shiftLabel.AutoSize = true;
			this.shiftLabel.Location = new System.Drawing.Point(29, 256);
			this.shiftLabel.Name = "shiftLabel";
			this.shiftLabel.Size = new System.Drawing.Size(39, 15);
			this.shiftLabel.TabIndex = 16;
			this.shiftLabel.Text = "Сдвиг";
			// 
			// templatesLabel
			// 
			this.templatesLabel.AutoSize = true;
			this.templatesLabel.Location = new System.Drawing.Point(14, 19);
			this.templatesLabel.Name = "templatesLabel";
			this.templatesLabel.Size = new System.Drawing.Size(61, 15);
			this.templatesLabel.TabIndex = 15;
			this.templatesLabel.Text = "Шаблоны";
			// 
			// templatesComboBox
			// 
			this.templatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.templatesComboBox.FormattingEnabled = true;
			this.templatesComboBox.Location = new System.Drawing.Point(81, 16);
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
			this.penSettingsGroupBox.Location = new System.Drawing.Point(14, 45);
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 611);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.pictureBox);
			this.MinimumSize = new System.Drawing.Size(700, 650);
			this.Name = "MainForm";
			this.Text = "Преобразования на плоскости";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.penSettingsGroupBox.ResumeLayout(false);
			this.penSettingsGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button colorPickerButton;
		private System.Windows.Forms.GroupBox penSettingsGroupBox;
		private System.Windows.Forms.CheckBox fatPencheckBox;
		private System.Windows.Forms.CheckBox prevPenCheckBox;
		private System.Windows.Forms.ComboBox templatesComboBox;
		private System.Windows.Forms.Label templatesLabel;
		private System.Windows.Forms.ComboBox penSettingsComboBox;
		private System.Windows.Forms.Label shiftLabel;
		private System.Windows.Forms.Button leftShiftButton;
		private System.Windows.Forms.Button downShiftButton;
		private System.Windows.Forms.Button rightShiftButton;
		private System.Windows.Forms.Button upShiftButton;
		private System.Windows.Forms.Button stopButton;
	}
}

