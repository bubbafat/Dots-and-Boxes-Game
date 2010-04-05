using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;


namespace BoxGame
{
	partial class GameSettings: System.Windows.Forms.Form
	{
		public GameSettings()
		{
			InitializeComponent();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			GameBoard gb = new GameBoard(
					int.Parse(cbBoardHeight.Text, CultureInfo.CurrentCulture), 
                    int.Parse(cbBoardWidth.Text, CultureInfo.CurrentCulture)
				);

			GamePanel f = new GamePanel();

			Player[] players = new Player[2];

			switch (this.cbPlayer1Type.SelectedIndex)
			{
				case 0: // human
					players[0] = new InkInputPlayer(txtPlayer1Name.Text, "P1", Color.Tomato, f.inkPanel, gb);
					break;
				case 1: // Computer (Good)
					players[0] = new AI_PickHighPoint(txtPlayer1Name.Text, "P1", Color.Tomato);
					break;
				case 2: // Computer (Random)
					players[0] = new AI_PickRandomPoint(txtPlayer1Name.Text, "P1", Color.Tomato);
					break;
				case 3: // Computer (Intentionally Bad)
					players[0] = new AI_PickWorstPoint(txtPlayer1Name.Text, "P1", Color.Tomato);
					break;
			}

			switch (this.cbPlayer2Type.SelectedIndex)
			{
				case 0: // human
					players[1] = new InkInputPlayer(txtPlayer2Name.Text, "P2", Color.Navy, f.inkPanel, gb);
					break;
				case 1: // Computer (Good)
					players[1] = new AI_PickHighPoint(txtPlayer2Name.Text, "P2", Color.Navy);
					break;
				case 2: // Computer (Random)
					players[1] = new AI_PickRandomPoint(txtPlayer2Name.Text, "P2", Color.Navy);
					break;
				case 3: // Computer (Intentionally Bad)
					players[1] = new AI_PickWorstPoint(txtPlayer2Name.Text, "P2", Color.Navy);
					break;
			}

			Game g = new Game(players, gb);
			g.FreeMoveOnScore = cbFreeMove.Checked;
			f.Initialize(g);
			f.ShowDialog();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void GameSettings_Load(object sender, EventArgs e)
		{
			cbPlayer1Type.SelectedIndex = 0;
			cbPlayer2Type.SelectedIndex = 0;
			cbBoardHeight.SelectedIndex = 6;
			cbBoardWidth.SelectedIndex = 6;
		}
	}
}