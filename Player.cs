using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace BoxGame
{
	public abstract class Player :IPlayer
	{
		string m_Name;
		string m_Initials;
		Color m_Color;
		int m_Score;

		protected Player(string name, string initials, Color color)
		{
			m_Name = name;
			m_Initials = initials;
			m_Color = color;
		}

		public string DisplayName
		{
			get 
			{ 
				return m_Name; 
			}
		}

		public string Initials
		{
			get 
			{
				return m_Initials;
			}
		}

		public System.Drawing.Color Color
		{
			get 
			{
				return m_Color;
			}
		}

		public int Score
		{
			get
			{
				return m_Score;
			}
		}

		public IMove GetNextMove(IGameBoard board)
		{
			return GetNextMove_Impl(board);
		}

		protected abstract IMove GetNextMove_Impl(IGameBoard board);

		public int AddScore(int score)
		{
			return (m_Score += score);
		}

		public int AddScore(MoveScore score)
		{
			if(score == MoveScore.One)
			{
				m_Score++;
			}
			else if(score == MoveScore.Two)
			{
				m_Score += 2;
			}

			return m_Score;
		}
	}
}
