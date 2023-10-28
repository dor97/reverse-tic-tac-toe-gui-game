
namespace UserInterface
{
	partial class FormGameSettings
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
			this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
			this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numbericUpDownRow = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDownCol = new System.Windows.Forms.NumericUpDown();
			this.buttonStart = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numbericUpDownRow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCol)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Players:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Player 1:";
			// 
			// textBoxPlayer1
			// 
			this.textBoxPlayer1.Location = new System.Drawing.Point(113, 37);
			this.textBoxPlayer1.Name = "textBoxPlayer1";
			this.textBoxPlayer1.Size = new System.Drawing.Size(100, 20);
			this.textBoxPlayer1.TabIndex = 100;
			// 
			// checkBoxPlayer2
			// 
			this.checkBoxPlayer2.AutoSize = true;
			this.checkBoxPlayer2.Location = new System.Drawing.Point(30, 65);
			this.checkBoxPlayer2.Name = "checkBoxPlayer2";
			this.checkBoxPlayer2.Size = new System.Drawing.Size(70, 17);
			this.checkBoxPlayer2.TabIndex = 150;
			this.checkBoxPlayer2.Text = " Player 2:";
			this.checkBoxPlayer2.UseVisualStyleBackColor = true;
			this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_Checked);
			// 
			// textBoxPlayer2
			// 
			this.textBoxPlayer2.Enabled = false;
			this.textBoxPlayer2.Location = new System.Drawing.Point(113, 63);
			this.textBoxPlayer2.Name = "textBoxPlayer2";
			this.textBoxPlayer2.Size = new System.Drawing.Size(100, 20);
			this.textBoxPlayer2.TabIndex = 200;
			this.textBoxPlayer2.Text = "[Computer]";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 109);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Board Size:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 131);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Rows:";
			// 
			// numbericUpDownRow
			// 
			this.numbericUpDownRow.Location = new System.Drawing.Point(64, 129);
			this.numbericUpDownRow.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numbericUpDownRow.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.numbericUpDownRow.Name = "numbericUpDownRow";
			this.numbericUpDownRow.Size = new System.Drawing.Size(36, 20);
			this.numbericUpDownRow.TabIndex = 300;
			this.numbericUpDownRow.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.numbericUpDownRow.ValueChanged += new System.EventHandler(this.numericUpDown_Updated);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(110, 131);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Cols:";
			// 
			// numericUpDownCol
			// 
			this.numericUpDownCol.Location = new System.Drawing.Point(146, 129);
			this.numericUpDownCol.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDownCol.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.numericUpDownCol.Name = "numericUpDownCol";
			this.numericUpDownCol.Size = new System.Drawing.Size(36, 20);
			this.numericUpDownCol.TabIndex = 400;
			this.numericUpDownCol.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.numericUpDownCol.ValueChanged += new System.EventHandler(this.numericUpDown_Updated);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(24, 179);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(189, 23);
			this.buttonStart.TabIndex = 500;
			this.buttonStart.Text = "Start!";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Pressed);
			// 
			// FormGameSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(232, 225);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.numericUpDownCol);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.numbericUpDownRow);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxPlayer2);
			this.Controls.Add(this.checkBoxPlayer2);
			this.Controls.Add(this.textBoxPlayer1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormGameSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game Settings";
			((System.ComponentModel.ISupportInitialize)(this.numbericUpDownRow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCol)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxPlayer1;
		private System.Windows.Forms.CheckBox checkBoxPlayer2;
		private System.Windows.Forms.TextBox textBoxPlayer2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numbericUpDownRow;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericUpDownCol;
		private System.Windows.Forms.Button buttonStart;
	}
}