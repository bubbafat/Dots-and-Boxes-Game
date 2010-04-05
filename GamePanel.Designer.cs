namespace BoxGame
{
	public partial class GamePanel : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.inkPanel = new Microsoft.Ink.InkPicture();
            ((System.ComponentModel.ISupportInitialize)(this.inkPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // inkPanel
            // 
            this.inkPanel.BackColor = System.Drawing.Color.White;
            this.inkPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inkPanel.Location = new System.Drawing.Point(9, 9);
            this.inkPanel.MarginX = -2147483648;
            this.inkPanel.MarginY = -2147483648;
            this.inkPanel.Name = "inkPanel";
            this.inkPanel.Size = new System.Drawing.Size(160, 129);
            this.inkPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(178, 147);
            this.Controls.Add(this.inkPanel);
            this.Name = "Game Panel";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.Text = "Box Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GamePanel_FormClosing);
            this.Load += new System.EventHandler(this.GamePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inkPanel)).EndInit();
            this.ResumeLayout(false);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		internal Microsoft.Ink.InkPicture inkPanel;
	}
}

