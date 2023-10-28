using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserInterface
{
	public class GameButton : Button
	{
		private uint m_Row;
		private uint m_Col;

		public GameButton(uint i_Row, uint i_Col)
		{
			m_Row = i_Row;
			m_Col = i_Col;
		}

		public uint Row
		{
			get { return m_Row; }
		}

		public uint Col
		{
			get { return m_Col; }
		}
	}
}
