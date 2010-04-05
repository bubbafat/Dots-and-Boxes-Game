namespace BoxGame
{
	partial class GameSettings: System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}


		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPlayer1Type = new System.Windows.Forms.ComboBox();
            this.cbPlayer2Type = new System.Windows.Forms.ComboBox();
            this.txtPlayer1Name = new System.Windows.Forms.TextBox();
            this.txtPlayer2Name = new System.Windows.Forms.TextBox();
            this.cbBoardWidth = new System.Windows.Forms.ComboBox();
            this.cbBoardHeight = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbFreeMove = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 2";
            // 
            // cbPlayer1Type
            // 
            this.cbPlayer1Type.FormattingEnabled = true;
            this.cbPlayer1Type.Items.AddRange(new object[] {
            "Human Player",
            "Computer (Good)",
            "Computer (Random)",
            "Computer (Intentionally Bad)"});
            this.cbPlayer1Type.Location = new System.Drawing.Point(97, 18);
            this.cbPlayer1Type.Name = "cbPlayer1Type";
            this.cbPlayer1Type.Size = new System.Drawing.Size(121, 21);
            this.cbPlayer1Type.TabIndex = 2;
            // 
            // cbPlayer2Type
            // 
            this.cbPlayer2Type.FormattingEnabled = true;
            this.cbPlayer2Type.Items.AddRange(new object[] {
            "Human Player",
            "Computer (Good)",
            "Computer (Random)",
            "Computer (Intentionally Bad)"});
            this.cbPlayer2Type.Location = new System.Drawing.Point(97, 46);
            this.cbPlayer2Type.Name = "cbPlayer2Type";
            this.cbPlayer2Type.Size = new System.Drawing.Size(121, 21);
            this.cbPlayer2Type.TabIndex = 3;
            // 
            // txtPlayer1Name
            // 
            this.txtPlayer1Name.Location = new System.Drawing.Point(242, 18);
            this.txtPlayer1Name.Name = "txtPlayer1Name";
            this.txtPlayer1Name.Size = new System.Drawing.Size(100, 20);
            this.txtPlayer1Name.TabIndex = 4;
            this.txtPlayer1Name.Text = "Player 1";
            // 
            // txtPlayer2Name
            // 
            this.txtPlayer2Name.Location = new System.Drawing.Point(242, 45);
            this.txtPlayer2Name.Name = "txtPlayer2Name";
            this.txtPlayer2Name.Size = new System.Drawing.Size(100, 20);
            this.txtPlayer2Name.TabIndex = 5;
            this.txtPlayer2Name.Text = "Player 2";
            // 
            // cbBoardWidth
            // 
            this.cbBoardWidth.FormattingEnabled = true;
            this.cbBoardWidth.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.cbBoardWidth.Location = new System.Drawing.Point(96, 75);
            this.cbBoardWidth.Name = "cbBoardWidth";
            this.cbBoardWidth.Size = new System.Drawing.Size(122, 21);
            this.cbBoardWidth.TabIndex = 6;
            // 
            // cbBoardHeight
            // 
            this.cbBoardHeight.FormattingEnabled = true;
            this.cbBoardHeight.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.cbBoardHeight.Location = new System.Drawing.Point(96, 103);
            this.cbBoardHeight.Name = "cbBoardHeight";
            this.cbBoardHeight.Size = new System.Drawing.Size(122, 21);
            this.cbBoardHeight.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Board Width";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Board Height";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(267, 75);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(267, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Quit";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbFreeMove
            // 
            this.cbFreeMove.Checked = true;
            this.cbFreeMove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFreeMove.Location = new System.Drawing.Point(18, 131);
            this.cbFreeMove.Name = "cbFreeMove";
            this.cbFreeMove.Size = new System.Drawing.Size(200, 24);
            this.cbFreeMove.TabIndex = 12;
            this.cbFreeMove.Text = "Free Move When Box is Made";
            // 
            // GameSettings
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(363, 176);
            this.Controls.Add(this.cbFreeMove);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbBoardHeight);
            this.Controls.Add(this.cbBoardWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPlayer2Name);
            this.Controls.Add(this.cbPlayer2Type);
            this.Controls.Add(this.txtPlayer1Name);
            this.Controls.Add(this.cbPlayer1Type);
            this.Controls.Add(this.label1);
            this.Name = "GameSettings";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.Text = "GameSettings.Designer";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}


		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbPlayer1Type;
		private System.Windows.Forms.ComboBox cbPlayer2Type;
		private System.Windows.Forms.TextBox txtPlayer1Name;
		private System.Windows.Forms.TextBox txtPlayer2Name;
		private System.Windows.Forms.ComboBox cbBoardWidth;
		private System.Windows.Forms.ComboBox cbBoardHeight;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox cbFreeMove;
	}
}