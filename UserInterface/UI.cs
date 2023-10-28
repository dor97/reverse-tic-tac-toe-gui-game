using System;
using System.Windows.Forms;
using GameLogic;

namespace UserInterface
{
	public class UI
	{

		private FormBoard m_FormBoard;
		private GameManager m_GameManager;

		[STAThread]
		public void Start()
		{
			FormGameSettings formGameSettings;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			formGameSettings = new FormGameSettings();
			Application.Run(formGameSettings);

			if (formGameSettings.IsStarting)
			{
				m_GameManager = formGameSettings.GameManager;
				m_FormBoard = new FormBoard(m_GameManager);
				listenToLogicEvents();
				Application.Run(m_FormBoard);
			}
		}

		private void listenToLogicEvents()
		{
			m_GameManager.BoardCellUpdated += m_GameManger_BoardCellUpdated;
			m_GameManager.PlayersSwitched += m_GameManager_PlayersSwitched;
			m_GameManager.NewGameStarted += m_GameManger_NewGameStarted;
			m_GameManager.CurrentGameFinished += m_GameManager_CurrentGameFinished;
		}

		private void m_GameManger_BoardCellUpdated(uint i_Row, uint i_Col)
		{
			m_FormBoard.UpdateGameButton(i_Row, i_Col);
		}

		private void m_GameManger_NewGameStarted()
		{
			m_FormBoard.StartNewGame();
		}

		private void m_GameManager_PlayersSwitched()
		{
			m_FormBoard.SwitchPlayers();
		}

		private void m_GameManager_CurrentGameFinished()
		{
			m_FormBoard.FinishGame();
		}
	}
}
