
namespace ComputerGraphics
{
	partial class MatrixForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.autoInputButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// autoInputButton
			// 
			this.autoInputButton.Location = new System.Drawing.Point(12, 174);
			this.autoInputButton.Name = "autoInputButton";
			this.autoInputButton.Size = new System.Drawing.Size(102, 38);
			this.autoInputButton.TabIndex = 0;
			this.autoInputButton.Text = "Заполнить автоматически";
			this.autoInputButton.UseVisualStyleBackColor = true;
			// 
			// saveButton
			// 
			this.saveButton.BackColor = System.Drawing.SystemColors.Control;
			this.saveButton.Location = new System.Drawing.Point(181, 174);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 38);
			this.saveButton.TabIndex = 1;
			this.saveButton.Text = "Сохранить";
			this.saveButton.UseVisualStyleBackColor = false;
			// 
			// MatrixForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 224);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.autoInputButton);
			this.Name = "MatrixForm";
			this.Text = "MatrixForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button autoInputButton;
		private System.Windows.Forms.Button saveButton;
	}
}