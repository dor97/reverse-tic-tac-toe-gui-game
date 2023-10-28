
namespace UserInterface
{
	partial class FormBoard
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
			this.labelPlayer1 = new System.Windows.Forms.Label();
			this.labelPlayer2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelPlayer1
			// 
			this.labelPlayer1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.labelPlayer1.AutoSize = true;
			this.labelPlayer1.Location = new System.Drawing.Point(5, 453);
			this.labelPlayer1.Name = "labelPlayer1";
			this.labelPlayer1.Size = new System.Drawing.Size(57, 13);
			this.labelPlayer1.TabIndex = 2;
			this.labelPlayer1.Text = "Player 1: 0";
			// 
			// labelPlayer2
			// 
			this.labelPlayer2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.labelPlayer2.AutoSize = true;
			this.labelPlayer2.Location = new System.Drawing.Point(68, 453);
			this.labelPlayer2.Name = "labelPlayer2";
			this.labelPlayer2.Size = new System.Drawing.Size(57, 13);
			this.labelPlayer2.TabIndex = 4;
			this.labelPlayer2.Text = "Player 2: 0";
			// 
			// FormBoard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(143, 485);
			this.Controls.Add(this.labelPlayer2);
			this.Controls.Add(this.labelPlayer1);
			this.Name = "FormBoard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TicTacToeMisere";
			this.Resize += new System.EventHandler(this.form_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelPlayer1;
		private System.Windows.Forms.Label labelPlayer2;
	}
}