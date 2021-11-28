
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
			this.rotateAxisCheckBox = new System.Windows.Forms.CheckBox();
			this.rotateRightButton = new System.Windows.Forms.Button();
			this.rotateButton = new System.Windows.Forms.Button();
			this.sizeComboBox = new System.Windows.Forms.ComboBox();
			this.SizeLabel = new System.Windows.Forms.Label();
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
			this.clearButton.Location = new System.Drawing.Point(153, 393);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(105, 23);
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
			this.pictureBox.Location = new System.Drawing.Point(10, 12);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(375, 587);
			this.pictureBox.TabIndex = 3;
			this.pictureBox.TabStop = false;
			// 
			// panel
			// 
			this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panel.BackColor = System.Drawing.SystemColors.Control;
			this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel.Controls.Add(this.rotateAxisCheckBox);
			this.panel.Controls.Add(this.rotateRightButton);
			this.panel.Controls.Add(this.rotateButton);
			this.panel.Controls.Add(this.sizeComboBox);
			this.panel.Controls.Add(this.SizeLabel);
			this.panel.Controls.Add(this.leftShiftButton);
			this.panel.Controls.Add(this.downShiftButton);
			this.panel.Controls.Add(this.rightShiftButton);
			this.panel.Controls.Add(this.upShiftButton);
			this.panel.Controls.Add(this.shiftLabel);
			this.panel.Controls.Add(this.templatesLabel);
			this.panel.Controls.Add(this.templatesComboBox);
			this.panel.Controls.Add(this.penSettingsGroupBox);
			this.panel.Controls.Add(this.clearButton);
			this.panel.Location = new System.Drawing.Point(395, 12);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(285, 426);
			this.panel.TabIndex = 5;
			// 
			// rotateAxisCheckBox
			// 
			this.rotateAxisCheckBox.AutoSize = true;
			this.rotateAxisCheckBox.Location = new System.Drawing.Point(14, 354);
			this.rotateAxisCheckBox.Name = "rotateAxisCheckBox";
			this.rotateAxisCheckBox.Size = new System.Drawing.Size(157, 19);
			this.rotateAxisCheckBox.TabIndex = 26;
			this.rotateAxisCheckBox.Text = "Показать ось вращения";
			this.rotateAxisCheckBox.UseVisualStyleBackColor = true;
			// 
			// rotateRightButton
			// 
			this.rotateRightButton.BackgroundImage = global::ComputerGraphics.Properties.Resources.imgonline_com_ua_Mirror_n9WB5rtwGg21;
			this.rotateRightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.rotateRightButton.Location = new System.Drawing.Point(228, 223);
			this.rotateRightButton.Name = "rotateRightButton";
			this.rotateRightButton.Size = new System.Drawing.Size(30, 30);
			this.rotateRightButton.TabIndex = 25;
			this.rotateRightButton.UseVisualStyleBackColor = true;
			this.rotateRightButton.Click += new System.EventHandler(this.rotateRightButton_Click);
			// 
			// rotateButton
			// 
			this.rotateButton.BackgroundImage = global::ComputerGraphics.Properties.Resources.outline_rotate_left_black_24dp;
			this.rotateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.rotateButton.Location = new System.Drawing.Point(25, 223);
			this.rotateButton.Name = "rotateButton";
			this.rotateButton.Size = new System.Drawing.Size(30, 30);
			this.rotateButton.TabIndex = 24;
			this.rotateButton.UseVisualStyleBackColor = true;
			this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
			this.rotateButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rotateButton_MouseDown);
			this.rotateButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rotateButton_MouseUp);
			// 
			// sizeComboBox
			// 
			this.sizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sizeComboBox.FormattingEnabled = true;
			this.sizeComboBox.Location = new System.Drawing.Point(81, 393);
			this.sizeComboBox.Name = "sizeComboBox";
			this.sizeComboBox.Size = new System.Drawing.Size(55, 23);
			this.sizeComboBox.TabIndex = 22;
			this.sizeComboBox.SelectedIndexChanged += new System.EventHandler(this.sizeComboBox_SelectedIndexChanged);
			// 
			// SizeLabel
			// 
			this.SizeLabel.AutoSize = true;
			this.SizeLabel.Location = new System.Drawing.Point(14, 397);
			this.SizeLabel.Name = "SizeLabel";
			this.SizeLabel.Size = new System.Drawing.Size(62, 15);
			this.SizeLabel.TabIndex = 21;
			this.SizeLabel.Text = "Масштаб:";
			// 
			// leftShiftButton
			// 
			this.leftShiftButton.BackgroundImage = global::ComputerGraphics.Properties.Resources.outline_west_black_18dp;
			this.leftShiftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.leftShiftButton.Location = new System.Drawing.Point(68, 221);
			this.leftShiftButton.Name = "leftShiftButton";
			this.leftShiftButton.Size = new System.Drawing.Size(40, 35);
			this.leftShiftButton.TabIndex = 20;
			this.leftShiftButton.UseVisualStyleBackColor = true;
			this.leftShiftButton.Click += new System.EventHandler(this.leftShiftButton_Click);
			// 
			// downShiftButton
			// 
			this.downShiftButton.BackgroundImage = global::ComputerGraphics.Properties.Resources.outline_south_black_18dp;
			this.downShiftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.downShiftButton.Location = new System.Drawing.Point(121, 263);
			this.downShiftButton.Name = "downShiftButton";
			this.downShiftButton.Size = new System.Drawing.Size(35, 40);
			this.downShiftButton.TabIndex = 19;
			this.downShiftButton.UseVisualStyleBackColor = true;
			this.downShiftButton.Click += new System.EventHandler(this.downShiftButton_Click);
			// 
			// rightShiftButton
			// 
			this.rightShiftButton.BackgroundImage = global::ComputerGraphics.Properties.Resources.outline_east_black_18dp;
			this.rightShiftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.rightShiftButton.Location = new System.Drawing.Point(173, 221);
			this.rightShiftButton.Name = "rightShiftButton";
			this.rightShiftButton.Size = new System.Drawing.Size(40, 35);
			this.rightShiftButton.TabIndex = 18;
			this.rightShiftButton.UseVisualStyleBackColor = true;
			this.rightShiftButton.Click += new System.EventHandler(this.rightShiftButton_Click);
			// 
			// upShiftButton
			// 
			this.upShiftButton.BackgroundImage = global::ComputerGraphics.Properties.Resources.outline_north_black_18dp;
			this.upShiftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.upShiftButton.Location = new System.Drawing.Point(121, 174);
			this.upShiftButton.Name = "upShiftButton";
			this.upShiftButton.Size = new System.Drawing.Size(35, 40);
			this.upShiftButton.TabIndex = 17;
			this.upShiftButton.UseVisualStyleBackColor = true;
			this.upShiftButton.Click += new System.EventHandler(this.upShiftButton_Click);
			// 
			// shiftLabel
			// 
			this.shiftLabel.AutoSize = true;
			this.shiftLabel.Location = new System.Drawing.Point(121, 231);
			this.shiftLabel.Name = "shiftLabel";
			this.shiftLabel.Size = new System.Drawing.Size(42, 15);
			this.shiftLabel.TabIndex = 16;
			this.shiftLabel.Text = "Сдвиг ";
			// 
			// templatesLabel
			// 
			this.templatesLabel.AutoSize = true;
			this.templatesLabel.Location = new System.Drawing.Point(14, 328);
			this.templatesLabel.Name = "templatesLabel";
			this.templatesLabel.Size = new System.Drawing.Size(61, 15);
			this.templatesLabel.TabIndex = 15;
			this.templatesLabel.Text = "Шаблоны";
			// 
			// templatesComboBox
			// 
			this.templatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.templatesComboBox.FormattingEnabled = true;
			this.templatesComboBox.Location = new System.Drawing.Point(81, 325);
			this.templatesComboBox.Name = "templatesComboBox";
			this.templatesComboBox.Size = new System.Drawing.Size(126, 23);
			this.templatesComboBox.TabIndex = 14;
			this.templatesComboBox.SelectedIndexChanged += new System.EventHandler(this.templatesComboBox_SelectedIndexChanged);
			// 
			// penSettingsGroupBox
			// 
			this.penSettingsGroupBox.Controls.Add(this.penSettingsComboBox);
			this.penSettingsGroupBox.Controls.Add(this.prevPenCheckBox);
			this.penSettingsGroupBox.Controls.Add(this.fatPencheckBox);
			this.penSettingsGroupBox.Controls.Add(this.colorPickerButton);
			this.penSettingsGroupBox.Location = new System.Drawing.Point(14, 3);
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
			this.Text = "Трехмерная фигура";
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
		private System.Windows.Forms.Label SizeLabel;
		private System.Windows.Forms.ComboBox sizeComboBox;
		private System.Windows.Forms.Button rotateButton;
		private System.Windows.Forms.Button rotateRightButton;
		private System.Windows.Forms.CheckBox rotateAxisCheckBox;
	}
}

