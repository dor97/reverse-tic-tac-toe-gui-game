using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	class PlayerManager
	{
		private readonly string[] r_PlayerNames;
		private eGameCharacter m_CurrentTurnPlayer;
		private readonly ePlayingMode r_PlayingMode;
		private int oScore = 0;
		private int xScore = 0;

		public PlayerManager(ePlayingMode i_PlayingMode, string[] i_PlayerNames)
		{
			this.r_PlayingMode = i_PlayingMode;
			this.r_PlayerNames = i_PlayerNames;
		}

		public int XScore
		{
			get { return xScore; }
		}

		public int OScore
		{
			get { return oScore; }
		}

		public eGameCharacter CurrentTurnPlayer
		{
			get { return m_CurrentTurnPlayer; }
		}

		public void StartNewGame()
		{
			m_CurrentTurnPlayer = eGameCharacter.Circle;
		}

		public string GetCurrentPlayerName()
		{
			string currentPlayerName;
			bool isPlayingAgainstComputer = r_PlayingMode == ePlayingMode.Computer;
			bool isCircleCurrentTurnPlayer = eGameCharacter.Circle == m_CurrentTurnPlayer;

			if (isPlayingAgainstComputer)
			{
				currentPlayerName = r_PlayerNames[0];
			}
			else if (isCircleCurrentTurnPlayer)
			{
				currentPlayerName = r_PlayerNames[0];
			}
			else
			{
				currentPlayerName = r_PlayerNames[1];
			}

			return currentPlayerName;
		}

		public bool IsPlayingAgainstComputer()
		{
			return r_PlayingMode == ePlayingMode.Computer;
		}

		public void SwitchTurnPlayer()
		{
			bool isCircleCurrentTurnPlayer = m_CurrentTurnPlayer == eGameCharacter.Circle;

			if (isCircleCurrentTurnPlayer)
			{
				m_CurrentTurnPlayer = eGameCharacter.Cross;
			}
			else
			{
				m_CurrentTurnPlayer = eGameCharacter.Circle;
			}
		}

		public void UpdateWinnerScore(eGameCharacter i_Winner)
		{
			if(i_Winner == eGameCharacter.Circle)
			{
				oScore++;
			}
			else if(i_Winner == eGameCharacter.Cross)
			{
				xScore++;
			}
		}

		public string GetCircleName()
		{
			return r_PlayerNames[0];
		}

		public string GetCrossName()
		{
			string name;
			bool isPlayingAgainstComputer = r_PlayingMode == ePlayingMode.Computer;

			if (isPlayingAgainstComputer)
			{
				name = "Computer";
			}
			else
			{
				name = r_PlayerNames[1];
			}

			return name;
		}
	}
}
