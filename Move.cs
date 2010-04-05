using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace BoxGame
{
	class Move : IMove
	{
		Line m_Line;
		Player m_Player;

		public Move(Line line)
			: this(line, null)
		{
		}

		public Move(Line line, Player player)
		{
			m_Line = line;
			m_Player = player;
		}

		public ILine Line
		{
			get
			{
				return m_Line;
			}
		}

		public IPlayer Player
		{
			get
			{
				return m_Player;
			}
		}

		public void SetPlayer(Player p)
		{
			m_Player = p;
		}

		public void Render(IGraphicProvider gfx)
		{
			Point start = (m_Line.Start as Corner).GraphicsPoint;
			Point end = (m_Line.End as Corner).GraphicsPoint;

			gfx.DrawLine(start, end, m_Player.Color);
		}

        public int CompareTo(IMove other)
        {
            return Line.CompareTo(other.Line);
        }
	}
}
