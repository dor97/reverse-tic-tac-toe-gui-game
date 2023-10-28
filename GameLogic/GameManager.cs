using System;
using System.Collections.Generic;

namespace GameLogic
{
	public class GameManager
	{
		private readonly GameBoard r_GameBoard;
		private readonly PlayerManager r_PlayerManager;
		private eGameState m_CurrentGameState;

		public event Action<uint , uint> BoardCellUpdated;

		public event Action NewGameStarted;

		public event Action PlayersSwitched;

		public event Action CurrentGameFinished;

		public GameManager(uint i_GameSize, ePlayingMode i_PlayingMode, string[] i_PlayerNames)
		{
			r_GameBoard = new GameBoard(i_GameSize);
			r_PlayerManager = new PlayerManager(i_PlayingMode, i_PlayerNames);
			StartNewGame();
		}

		public uint BoardSize 
		{
			get { return r_GameBoard.GameSize; }
		}

		public eGameState CurrentGameState
		{
			get { return m_CurrentGameState; }
		}

		public void StartNewGame()
		{
			r_GameBoard.ResetBoard();
			m_CurrentGameState = eGameState.Unfinished;
			r_PlayerManager.StartNewGame();
			OnNewGameStared();
		}

		private void OnNewGameStared()
		{
			if (NewGameStarted != null)
			{
				NewGameStarted.Invoke();
			}
		}

		public static bool CheckValidGameSize(uint i_GameSize)
		{
			return GameBoard.CheckValidGameSize(i_GameSize);
		}

		public string GetCurrentPlayerName()
		{
			return r_PlayerManager.GetCurrentPlayerName();
		}

		public bool CheckValidIndex(uint i_Index)
		{
			return r_GameBoard.CheckValidIndex(i_Index);
		}

		public bool CheckValidMove(uint i_Row, uint i_Col)
		{
			return r_GameBoard.CheckValidMove(i_Row, i_Col);
		}

		public void PlayTurn(uint i_Row, uint i_Col)
		{
			bool isComputerTurn;
			bool isGameFinished = false;

			playMove(i_Row, i_Col);
			finishGameIfGameFinished(ref isGameFinished);
			isComputerTurn = !isGameFinished && r_PlayerManager.IsPlayingAgainstComputer();
			if (isComputerTurn)
			{
				r_GameBoard.GetComputerMove(out uint computerRow, out uint computerCol);
				playMove(computerRow, computerCol);
				finishGameIfGameFinished(ref isGameFinished);
			}
		}

		private void finishGameIfGameFinished(ref bool o_IsGameFinished)
		{
			o_IsGameFinished = m_CurrentGameState != eGameState.Unfinished;
			if (o_IsGameFinished)
			{
				OnCurrentGameFinished();
			}
		}

		private void playMove(uint i_Row, uint i_Col)
		{
			bool isLosing;
			bool isTied;

			r_GameBoard.PlayMove(i_Row, i_Col, r_PlayerManager.CurrentTurnPlayer);
			OnBoardCellUpdated(i_Row, i_Col);
			isLosing = r_GameBoard.CheckForLoss(i_Row, i_Col, r_PlayerManager.CurrentTurnPlayer);
			if (isLosing)
			{
				if (r_PlayerManager.CurrentTurnPlayer == eGameCharacter.Circle)
				{
					m_CurrentGameState = eGameState.CrossVictory;
					r_PlayerManager.UpdateWinnerScore(eGameCharacter.Cross);
				}
				else
				{
					m_CurrentGameState = eGameState.CircleVictory;
					r_PlayerManager.UpdateWinnerScore(eGameCharacter.Circle);
				}
			}

			isTied = !isLosing && r_GameBoard.CheckForTie();
			isTied &= !isLosing;
			if (isTied)
			{
				m_CurrentGameState = eGameState.Tie;
			}

			if (m_CurrentGameState == eGameState.Unfinished)
			{
				r_PlayerManager.SwitchTurnPlayer();
				if (!r_PlayerManager.IsPlayingAgainstComputer())
				{
					OnPlayersSwitched();
				}
			}
		}

		private void OnCurrentGameFinished()
		{
			if(CurrentGameFinished != null)
			{
				CurrentGameFinished.Invoke();
			}
		}

		public string GetWinnerName()
		{
			string winnerName;

			if (m_CurrentGameState == eGameState.CircleVictory)
			{
				winnerName = r_PlayerManager.GetCircleName();
			}
			else if (m_CurrentGameState == eGameState.CrossVictory)
			{
				winnerName = r_PlayerManager.GetCrossName();
			}
			else
			{
				throw new ArgumentException("The game doesn't have a winner");
			}

			return winnerName;
		}

		private void OnPlayersSwitched()
		{
			if(PlayersSwitched != null)
			{
				PlayersSwitched.Invoke();
			}
		}

		private void OnBoardCellUpdated(uint i_Row, uint i_Col)
		{
			if(BoardCellUpdated != null)
			{
				BoardCellUpdated.Invoke(i_Row, i_Col);
			}
		}

		public string GetCircleName()
		{
			return r_PlayerManager.GetCircleName();
		}

		public string GetCrossName()
		{
			return r_PlayerManager.GetCrossName();
		}

		public eGameCharacter[,] GetGameBoard()
		{
			return r_GameBoard.Board;
		}

		public eGameCharacter GetCurrentTurnPlayer()
		{
			return r_PlayerManager.CurrentTurnPlayer;
		}

		public int GetCircleScore()
		{
			return r_PlayerManager.OScore;
		}

		public int GetCrossScore()
		{
			return r_PlayerManager.XScore;
		}

		public eGameCharacter GetBoardCellSymbol(uint i_Row, uint i_Col)
		{
			return r_GameBoard.Board[i_Row, i_Col];
		}

		public static ePlayingMode ConvertToPlayingMode(bool i_Mode)
		{
			int playingMode = Convert.ToInt32(i_Mode);

			return (ePlayingMode)playingMode;
		}
	}
}
