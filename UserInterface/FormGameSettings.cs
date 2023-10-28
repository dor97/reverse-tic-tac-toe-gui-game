using GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserInterface
{
	public partial class FormGameSettings : Form
	{

		private GameManager m_GameManager;
		private bool m_IsStarting = false;


		public FormGameSettings()
		{
			InitializeComponent();
		}

		private void checkBoxPlayer2_Checked(object sender, EventArgs e)
		{
			CheckBox checkbox = sender as CheckBox;

			textBoxPlayer2.Enabled = checkbox.Checked;
			textBoxPlayer2.Text = checkbox.Checked ? "" : "[Computer]";
		}

		private void numericUpDown_Updated(object sender, EventArgs e)
		{
			NumericUpDown numericUpDown = sender as NumericUpDown;

			numericUpDownCol.Value = numericUpDown.Value;
			numbericUpDownRow.Value = numericUpDown.Value;
		}

		private void buttonStart_Pressed(object sender, EventArgs e)
		{
			bool isTwoPlayers = checkBoxPlayer2.Checked;
			ePlayingMode mode = GameManager.ConvertToPlayingMode(isTwoPlayers);
			string player1Name = textBoxPlayer1.Text;
			string player2Name = isTwoPlayers ? textBoxPlayer2.Text : "Computer";
			uint boardSize = (uint)numbericUpDownRow.Value;
			string[] players = new string[2] { player1Name, player2Name };
			bool invalidInput = string.IsNullOrEmpty(player1Name) || string.IsNullOrEmpty(player2Name);

			if (invalidInput)
			{
				MessageBox.Show("Error: Empty player name");
			}
			else
			{
				m_GameManager = new GameManager(boardSize, mode, players);
				m_IsStarting = true;
				Close();
			}
		}

		public GameManager GameManager
		{
			get { return m_GameManager; }
		}

		public bool IsStarting
		{
			get { return m_IsStarting; }
		}
	}
}
