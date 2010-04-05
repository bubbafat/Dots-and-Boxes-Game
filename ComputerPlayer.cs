using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace BoxGame
{
	class AI_PickRandomPoint : Player
	{
		Random m_RNG = new Random();

		public AI_PickRandomPoint(string name, string initials, Color color)
			: base(name, initials, color)
		{
		}

		protected override IMove GetNextMove_Impl(IGameBoard board)
		{
			GameBoard b = (GameBoard) board;

			if (b.MovesRemaining > 0)
			{
				Move m = b.AvailableMoves[m_RNG.Next(0, b.AvailableMoves.Count - 1)];
				m.SetPlayer(this);

				return m;
			}

			throw new InvalidOperationException("Attempt to move when board is filled");
		}
	}

	class AI_PickWorstPoint : Player
	{
		Random m_RNG = new Random();

		public AI_PickWorstPoint(string name, string initials, Color color)
			: base(name, initials, color)
		{
		}

		protected override IMove GetNextMove_Impl(IGameBoard board)
		{
			GameBoard b = (GameBoard) board;

			if (b.MovesRemaining > 0)
			{
				Move m = null;

				List<Move> worstMoves = new List<Move>();

				foreach (Move am in b.AvailableMoves)
				{
					int score = b.SpeculateMove(am, this).Count;
					if (score == 0)
					{
						worstMoves.Add(am);
					}
				}

				if (worstMoves.Count > 0)
				{
					m = worstMoves[m_RNG.Next(0, worstMoves.Count - 1)];
				}
				else
				{
					m = b.AvailableMoves[m_RNG.Next(0, b.AvailableMoves.Count - 1)];
				}

				m.SetPlayer(this);
				return m;
			}

			throw new InvalidOperationException("Attempt to move when board is filled");
		}
	}

	class AI_PickHighPoint : Player
	{
		Random m_RNG = new Random();

		public AI_PickHighPoint(string name, string initials, Color color)
			: base(name, initials, color)
		{
		}

		protected override IMove GetNextMove_Impl(IGameBoard board)
		{
			GameBoard b = (GameBoard) board;

			if (b.MovesRemaining > 0)
			{
				Move m = null;

				List<Move> twoPointMoves = new List<Move>();
				List<Move> onePointMoves = new List<Move>();

				foreach (Move am in b.AvailableMoves)
				{
					int score = b.SpeculateMove(am, this).Count;
					if (score == 2)
					{
						twoPointMoves.Add(am);
					}
					else if (score == 1)
					{
						onePointMoves.Add(am);
					}
				}

				if (twoPointMoves.Count > 0)
				{
					m = twoPointMoves[m_RNG.Next(0, twoPointMoves.Count - 1)];
				}
				else if (onePointMoves.Count > 0)
				{
					m = onePointMoves[m_RNG.Next(0, onePointMoves.Count - 1)];
				}
				else
				{
					m = b.AvailableMoves[m_RNG.Next(0, b.AvailableMoves.Count - 1)];
				}

				m.SetPlayer(this);

				return m;
			}

			throw new InvalidOperationException("Attempt to move when board is filled");
		}
	}
}
