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
	public partial class FormBoard : Form
	{

		private GameManager m_GameManager;
        private Button[,] m_GameButtonBoard;
        private const int k_ButtonSize = 50;
        private const int k_WidthMargin = 5;
        private const int k_HeightMargin = 5;
        private const int k_WidthExtention = 30;
		private const int k_HeightExtention = 90;

		public FormBoard(GameManager i_GameManager)
		{
			this.m_GameManager = i_GameManager;
			InitializeComponent();
            initializeGameButtonBoard();
            initializeFormSize();
            updateLabels();
        }

        private void initializeGameButtonBoard()
        {
            m_GameButtonBoard = new Button[m_GameManager.BoardSize, m_GameManager.BoardSize];
            for (uint i = 0; i < m_GameManager.BoardSize; i++)
            {
                for (uint j = 0; j < m_GameManager.BoardSize; j++)
                {
                    m_GameButtonBoard[i, j] = new GameButton(i, j);
                    initializeGameButton(m_GameButtonBoard[i, j] as GameButton);
                }
            }
        }

		public void UpdateGameButton(uint i_Row, uint i_Col)
		{
            eGameCharacter gameSymbol = m_GameManager.GetBoardCellSymbol(i_Row, i_Col);
            Button gameButton = m_GameButtonBoard[i_Row, i_Col];

            if (gameSymbol != eGameCharacter.Empty)
			{
                gameButton.Enabled = false;
            }

            gameButton.Text = ((char)gameSymbol).ToString();
		}

        public void StartNewGame()
		{
            resetGameButtonBoard();
            updateLabels();
		}
        
        public void SwitchPlayers()
		{
            eGameCharacter currentTurnPlayer = m_GameManager.GetCurrentTurnPlayer();

            indicateTurnPlayer(currentTurnPlayer);
		}

        public void FinishGame()
		{
            DialogResult dialogResult;

            getMessageBoxTitleAndMsg(out string message, out string title);
            dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                m_GameManager.StartNewGame();
            }
            else if (dialogResult == DialogResult.No)
            {
                Close();
            }
        }

        private void getMessageBoxTitleAndMsg(out string o_Message, out string o_Title)
		{
            eGameState gameResult = m_GameManager.CurrentGameState;

            if (gameResult == eGameState.Tie)
			{
                o_Title = "A Tie!";
                o_Message = string.Format(
@"Tie!
Would you like to play another round?"
                    );
			}
			else
			{
                o_Title = "A Win!";
                o_Message = string.Format(
@"The winner is {0}!
Would you like to play another round?",
                   m_GameManager.GetWinnerName());
            }
		}

        private void resetGameButtonBoard()
		{
            foreach (GameButton gameButton in m_GameButtonBoard)
            {
                resetGameButton(gameButton);
            }
        }

		private void resetGameButton(GameButton i_GameButton)
		{
            i_GameButton.Enabled = true;
            i_GameButton.Text = string.Empty;
		}

		private void initializeGameButton(GameButton i_Button)
        {
            i_Button.Size = new Size(k_ButtonSize, k_ButtonSize);
            i_Button.Top = k_HeightMargin + k_ButtonSize * (int)i_Button.Row;
            i_Button.Left = k_WidthMargin + k_ButtonSize * (int)i_Button.Col;
			i_Button.Click += gameButton_Click;
            Controls.Add(i_Button);
        }

		private void gameButton_Click(object sender, EventArgs e)
		{
            GameButton gameButton = sender as GameButton; 

            m_GameManager.PlayTurn(gameButton.Row, gameButton.Col);
		}

        private void form_Resize(object sender, EventArgs e)
		{
            foreach (GameButton button in m_GameButtonBoard)
			{
                resizeButton(button);
			}
		}

        private void resizeButton(GameButton i_Button)
		{
            int resizedButtonWidth = (this.Size.Width - k_WidthExtention) / (int)m_GameManager.BoardSize;
            int resizedButtonHeight = (this.Size.Height - k_HeightExtention) / (int)m_GameManager.BoardSize;

            i_Button.Size = new Size(resizedButtonWidth, resizedButtonHeight);
            i_Button.Top = k_HeightMargin + resizedButtonHeight * (int)i_Button.Row;
            i_Button.Left = k_WidthMargin + resizedButtonWidth * (int)i_Button.Col;
        }

        private void initializeFormSize()
        {
            this.Size = new Size(
                (int)m_GameManager.BoardSize * k_ButtonSize + k_WidthExtention, 
                (int)m_GameManager.BoardSize * k_ButtonSize + k_HeightExtention);
            this.MinimumSize = this.Size;
        }

        private void updateLabels()
		{
            labelPlayer1.Text = string.Format("{0}: {1}",m_GameManager.GetCircleName(), m_GameManager.GetCircleScore());
            labelPlayer2.Text = string.Format("{0}: {1}", m_GameManager.GetCrossName(), m_GameManager.GetCrossScore());
            indicateTurnPlayer(eGameCharacter.Circle);
        }

        private void indicateTurnPlayer(eGameCharacter i_CurrentTurnPlayer)
		{
            Font boldFont = new Font(labelPlayer1.Font, FontStyle.Bold);
            Font unboldFont = new Font(labelPlayer1.Font, FontStyle.Regular);

			if (i_CurrentTurnPlayer == eGameCharacter.Circle)
			{
                labelPlayer1.Font = boldFont;
                labelPlayer2.Font = unboldFont;
            }
			else if(i_CurrentTurnPlayer == eGameCharacter.Cross)
			{
                labelPlayer1.Font = unboldFont;
                labelPlayer2.Font = boldFont;
            }
		}
	}
}
