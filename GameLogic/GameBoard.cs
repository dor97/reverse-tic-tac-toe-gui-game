using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
	public class GameBoard
	{
		private const int k_MaxBoardSize = 9;
		private const int k_MinBoardSize = 3;
		private readonly uint r_GameSize;
		private List<Tuple<uint, uint>> m_FreeCells;
		private eGameCharacter[,] m_Board;
		private int m_FilledCells;
		private Random m_CellRNG = new Random();

		public GameBoard(uint i_GameSize)
		{
			r_GameSize = i_GameSize;
			m_Board = new eGameCharacter[r_GameSize, r_GameSize];
		}

		public uint GameSize
		{
			get { return r_GameSize; }
		}

		public eGameCharacter[,] Board
		{
			get { return m_Board; }
		}

		public void ResetBoard()
		{
			CreateInitialGameBoard();
			m_FilledCells = 0;
			initializeFreeCells();
		}

		private void initializeFreeCells()
		{
			m_FreeCells = new List<Tuple<uint, uint>> { };
			for (uint i = 0; i < r_GameSize; i++)
			{
				for (uint j = 0; j < r_GameSize; j++)
				{
					Tuple<uint, uint> cell = new Tuple<uint, uint>(i, j);
					m_FreeCells.Add(cell);
				}
			}
		}

		public static bool CheckValidGameSize(uint i_GameSize)
		{
			return i_GameSize >= k_MinBoardSize && i_GameSize <= k_MaxBoardSize;
		}

		public void CreateInitialGameBoard()
		{
			for (int i = 0; i < r_GameSize; i++)
			{
				for (int j = 0; j < r_GameSize; j++)
				{
					m_Board[i, j] = eGameCharacter.Empty;

				}
			}
		}

		public bool CheckValidIndex(uint i_Index)
		{
			return i_Index <= r_GameSize && i_Index >= 1;
		}

		public bool CheckValidMove(uint i_Row, uint i_Col)
		{
			return m_Board[i_Row - 1, i_Col - 1] == eGameCharacter.Empty;
		}

		public void GetComputerMove(out uint o_ComputerRow, out uint o_ComputerCol)
		{
			Tuple<uint, uint> cell;
			int listIndex = m_CellRNG.Next(m_FreeCells.Count);

			cell = m_FreeCells[listIndex];
			o_ComputerRow = cell.Item1;
			o_ComputerCol = cell.Item2;
		}

		public void PlayMove(uint i_Row, uint i_Col, eGameCharacter i_CurrentTurnCharacter)
		{
			fillCell(i_Row, i_Col, i_CurrentTurnCharacter);
			removeCellFromList(i_Row, i_Col);
		}

		private void removeCellFromList(uint i_Row, uint i_Col)
		{
			Tuple<uint, uint> cellToRemove = new Tuple<uint, uint>(i_Row, i_Col);

			m_FreeCells.Remove(cellToRemove);
		}

		private void fillCell(uint i_Row, uint i_Col, eGameCharacter i_CurrentTurnCharacter)
		{
			m_Board[i_Row, i_Col] = i_CurrentTurnCharacter;
			m_FilledCells++;
		}

		public bool CheckForLoss(uint i_Row, uint i_Col, eGameCharacter i_CurrentTurnCharacter)
		{
			bool isLosing = false;
			bool isOnPrimaryDiagnoal;
			bool isOnSecondaryDiagnoal;

			isLosing = checkForLossColumn(i_Col, i_CurrentTurnCharacter);
			isLosing |= checkForLossRow(i_Row, i_CurrentTurnCharacter);
			isOnPrimaryDiagnoal = i_Row == i_Col;
			isOnSecondaryDiagnoal = (r_GameSize - 1) - i_Row == i_Col;
			if (isOnPrimaryDiagnoal)
			{
				isLosing |= checkForLossPrimaryDiagnoal(i_CurrentTurnCharacter);
			}

			if (isOnSecondaryDiagnoal)
			{
				isLosing |= checkForLossSecondaryDiagnoal(i_CurrentTurnCharacter);
			}

			return isLosing;
		}

		public bool CheckForTie()
		{
			return m_FilledCells == r_GameSize * r_GameSize;
		}

		private bool checkForLossSecondaryDiagnoal(eGameCharacter i_CurrentTurnCharacter)
		{
			bool isLosing = true;

			for (int i = 0; i < r_GameSize; i++)
			{
				if (m_Board[i, r_GameSize - 1 - i] != i_CurrentTurnCharacter)
				{
					isLosing = false;
					break;
				}
			}

			return isLosing;
		}

		private bool checkForLossPrimaryDiagnoal(eGameCharacter i_CurrentTurnCharacter)
		{
			bool isLosing = true;

			for (int i = 0; i < r_GameSize; i++)
			{
				if (m_Board[i, i] != i_CurrentTurnCharacter)
				{
					isLosing = false;
					break;
				}
			}

			return isLosing;
		}

		private bool checkForLossColumn(uint i_Col, eGameCharacter i_CurrentTurnCharacter)
		{
			bool isLosing = true;

			for (int i = 0; i < r_GameSize; i++)
			{
				if (m_Board[i, i_Col] != i_CurrentTurnCharacter)
				{
					isLosing = false;
					break;
				}
			}

			return isLosing;
		}
		private bool checkForLossRow(uint i_Row, eGameCharacter i_CurrentTurnCharacter)
		{
			bool isLosing = true;

			for (int i = 0; i < r_GameSize; i++)
			{
				if (m_Board[i_Row, i] != i_CurrentTurnCharacter)
				{
					isLosing = false;
					break;
				}
			}

			return isLosing;
		}
	}
}
