using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace BoxGame
{
	public enum MoveScore
	{
		NotAllowed = -1,
		Zero = 0,
		One = 1,
		Two = 2
	}

	public enum BoxDirection
	{
		Up,
		Down,
		Left,
		Right
	}

	class GameBoard : IGameBoard, ICornerMapper
	{
		List<List<Corner>> m_CornerRows;
		List<IMove> m_Moves;
		List<Move> m_RemainingMoves;
		List<Box> m_Boxes;
		IGraphicProvider m_Graphics;

		readonly int m_Rows;
		readonly int m_Columns;
		readonly int m_PointsPerInch = 2;
		readonly int m_PossibleLines;

		public GameBoard(int rows, int columns)
		{
			m_Rows = rows;
			m_Columns = columns;

			m_CornerRows = new List<List<Corner>>(m_Rows);
			for (int i = 0; i < m_Rows; i++)
			{
				List<Corner> row = new List<Corner>(m_Columns);
				for (int col = 0; col < m_Columns; col++)
				{
					row.Add(new Corner(new Point(col, i), this, Color.Black));
				}
				m_CornerRows.Add(row);
			}

			m_PossibleLines = ((m_Rows - 1) * m_Columns) + ((m_Columns - 1) * m_Rows);
			m_Moves = new List<IMove>(m_PossibleLines);
			PopulateAvailableMoves();

			m_Boxes = new List<Box>( (m_Rows-1) * (m_Columns-1) );
		}

		public int MovesRemaining
		{
			get
			{
				return m_PossibleLines - m_Moves.Count;
			}
		}

		public List<Move> AvailableMoves
		{
			get
			{
				return m_RemainingMoves;
			}
		}

		public MoveScore MakeMove(IMove move, Player p)
		{
			List<Box> results  = SpeculateMove(move, p);
			bool foundSlot = false;
			foreach(Move m in AvailableMoves)
			{
				if (move.CompareTo(m) == 0)
				{
					m.SetPlayer(p);
					AvailableMoves.Remove(m);
					Moves.Add(m);
					foundSlot = true;
					break;
				}
			}

			System.Diagnostics.Debug.Assert(foundSlot);

			MoveScore score = MoveScore.Zero;
			if (results.Count > 0)
			{
				foreach (Box b in results)
				{
					m_Boxes.Add(b);
					score = BumpScore(score);
				}

				p.AddScore(results.Count);
			}
			
			return score;
		}

		void PopulateAvailableMoves()
		{
			m_RemainingMoves = new List<Move>(m_PossibleLines);
			for (int row = 0; row < m_Rows; row++)
			{
				for (int col = 0; col < m_Columns; col++)
				{
					if (col != m_Columns - 1)
					{
						Line l = new Line(m_CornerRows[row][col], m_CornerRows[row][col + 1]);
						Move m = new Move(l);
						if (IsAvailableMove(m))
						{
							m_RemainingMoves.Add(m);
						}
					}

					if (row != m_Rows - 1)
					{
						Line l = new Line(m_CornerRows[row][col], m_CornerRows[row + 1][col]);
						Move m = new Move(l);
						if (IsAvailableMove(m))
						{
							m_RemainingMoves.Add(m);
						}
					}
				}
			}
		}

		public IGraphicProvider GraphicsProvider
		{
			get
			{
				return m_Graphics;
			}
			set
			{
				m_Graphics = value;
			}
		}

		int IGameBoard.Rows
		{
			get
			{
				return m_Rows;
			}
		}

		int IGameBoard.Columns
		{
			get
			{
				return m_Columns;
			}
		}

		ICorner[] IGameBoard.this[int index]
		{
			get
			{
				return m_CornerRows[index].ToArray();
			}
		}



		bool bgRendered = false;
		public void Render(IGraphicProvider gfx)
		{
			if (bgRendered == false)
			{
				Bitmap b = GenerateEmptyBackground(Color.White);
				gfx.DrawImage(b, 0, 0);
				bgRendered = true;
			}

			for(int i = 0; i < m_Rows; i++)
			{
				List<Corner> row = m_CornerRows[i];
				foreach (Corner c in row)
				{
					c.Render(gfx);
				}
			}

			foreach (IMove m in m_Moves)
			{
				m.Render(gfx);
			}

			foreach (Box b in m_Boxes)
			{
				b.Render(gfx);
			}

			gfx.Invalidate();
		}

	
		public Point GetGraphicsPoint(ICorner corner)
		{
			int SpacingX = m_Graphics.DpiX / m_PointsPerInch;
			int SpacingY = m_Graphics.DpiY / m_PointsPerInch;

			for (int row = 0; row < m_Rows; row++)
			{
				for (int index = 0; index < m_Columns; index++)
				{
					if(corner.Equals(m_CornerRows[row][index]))
					{
						int x = (SpacingX * index + SpacingX);
						int y = (SpacingY * row + SpacingY);
						return new Point(x, y);
					}
				}
			}

			throw new ArgumentOutOfRangeException("corner");
		}

		public Size GetMinimumGraphicsSize(int DpiX, int DpiY)
		{
			int SpacingX = DpiX / m_PointsPerInch;
			int SpacingY = DpiY / m_PointsPerInch;
			int width = m_Columns * SpacingX + SpacingX;
			int height = m_Rows * SpacingY + SpacingY;

			return new Size(width, height);
		}

		static int Distance(Point p1, Point p2)
		{
			double xprime = Math.Pow((p1.X - p2.X), 2);
			double yprime = Math.Pow((p1.Y - p2.Y), 2);
			return (int) Math.Ceiling(Math.Sqrt(xprime + yprime));
		}

		public ICorner ClosestCornerFromGraphicsPoint(Point p)
		{
			ICorner nearest = null;
			int dist = int.MaxValue;

			for (int row = 0; row < m_Rows; row++)
			{
				foreach (ICorner c in m_CornerRows[row])
				{
					int temp = Distance(p, this.GetGraphicsPoint(c));
					if (temp < dist)
					{
						dist = temp;
						nearest = c;
					}
				}
			}

			return nearest;
		}


		private static void SetBGColor(Bitmap b, Color c)
		{
			for (int x = 0; x < b.Width; x++)
			{
				for (int y = 0; y < b.Height; y++)
				{
					b.SetPixel(x, y, c);
				}
			}
		}

		private Bitmap GenerateEmptyBackground(Color bgColor)
		{
			Size s = GetMinimumGraphicsSize(m_Graphics.DpiX, m_Graphics.DpiY);
			Bitmap b = new Bitmap(s.Width, s.Height, m_Graphics.PixelFormat);
			SetBGColor(b, bgColor);

			return b;
		}


		private bool CornerPointOnBoard(Point p)
		{
			return (p.X >= 0 && p.X < m_Columns &&
					p.Y >= 0 && p.Y < m_Rows);
		}

		public List<IMove> Moves
		{
			get
			{
				return m_Moves;
			}
		}

		public bool AreBoxableCorners(Corner ul, Corner ur, Corner ll, Corner lr)
		{
			bool areBoxable = false;
			if (CornerPointOnBoard(ul.Location) && CornerPointOnBoard(ur.Location) &&
				CornerPointOnBoard(ll.Location) && CornerPointOnBoard(lr.Location))
			{
				if (ul.IsAdjacentTo(ll) && ul.IsAdjacentTo(ur))
				{
					if (lr.IsAdjacentTo(ll) && lr.IsAdjacentTo(ur))
					{
						areBoxable = true;
					}
				}
			}

			return areBoxable;
		}

		public bool MakesBox(Corner ul, Corner ur, Corner ll, Corner lr, Move move)
		{
			int filledLines = 0;
			bool fillsGap = false;
			bool makesBox = false;

			if(AreBoxableCorners(ul, ur, ll, lr))
			{
				if (!IsAvailableMove(ul, ur))
				{
					filledLines++;
				}
				else
				{
					fillsGap = (move.Line.Start.Location == ul.Location &&
								move.Line.End.Location == ur.Location);
				}

				if (!IsAvailableMove(ur, lr))
				{
					filledLines++;
				}
				else
				{
					fillsGap = (move.Line.Start.Location == ur.Location &&
								move.Line.End.Location == lr.Location);
				}

				if (!IsAvailableMove(ll, lr))
				{
					filledLines++;
				}
				else
				{
					fillsGap = (move.Line.Start.Location == ll.Location &&
								move.Line.End.Location == lr.Location);
				}

				if (!IsAvailableMove(ul, ll))
				{
					filledLines++;
				}
				else
				{
					fillsGap = (move.Line.Start.Location == ul.Location &&
								move.Line.End.Location == ll.Location);
				}

				makesBox = filledLines == 3 && fillsGap;
			}

			return makesBox;
		}

		Corner GetCornerFromDirection(Corner orig, BoxDirection direction)
		{
			Corner result = null;

			Point newP = orig.Location;
			switch (direction)
			{
				case BoxDirection.Up:
					newP.Offset(0, -1);
					break;
				case BoxDirection.Down:
					newP.Offset(0, 1);
					break;
				case BoxDirection.Left:
					newP.Offset(-1, 0);
					break;
				case BoxDirection.Right:
					newP.Offset(1, 0);
					break;
			}

			if (CornerPointOnBoard(newP))
			{
				result = m_CornerRows[newP.Y][newP.X];
			}

			return result;
		}

		Box CreateBox(IMove move, BoxDirection direction, Player player)
		{
			bool wouldBox = false;
			Corner ul = null, ur = null, ll = null, lr = null;

			switch (direction)
			{
				case BoxDirection.Up:
					{
						if(!(move.Line as Line).Vertical)
						{
							ll = move.Line.Start as Corner;
							ul = GetCornerFromDirection(ll, BoxDirection.Up);
							lr = move.Line.End as Corner;
							ur = GetCornerFromDirection(lr, BoxDirection.Up);
						}
					}
					break;
				case BoxDirection.Down:
					{
						if (!(move.Line as Line).Vertical)
						{
							ul = move.Line.Start as Corner;
							ur = move.Line.End as Corner;
							ll = GetCornerFromDirection(ul, BoxDirection.Down);
							lr = GetCornerFromDirection(ur, BoxDirection.Down);
						}
					}
					break;
				case BoxDirection.Left:
					{
						if ((move.Line as Line).Vertical)
						{
							ur = move.Line.Start as Corner;
							lr = move.Line.End as Corner;
							ul = GetCornerFromDirection(ur, BoxDirection.Left);
							ll = GetCornerFromDirection(lr, BoxDirection.Left);
						}
					}
					break;
				case BoxDirection.Right:
					{
						if ((move.Line as Line).Vertical)
						{
							ul = move.Line.Start as Corner;
							ll = move.Line.End as Corner;
							ur = GetCornerFromDirection(ul, BoxDirection.Right);
							lr = GetCornerFromDirection(ll, BoxDirection.Right);
						}
					}
					break;
				default:
					throw new ArgumentException("Direction must be one of Up, Down, Left, Right");
			}

			Box box = null;

			if (ul != null && ur != null && ll != null && lr != null)
			{
				wouldBox = MakesBox(ul, ur, ll, lr, move as Move);
				if (wouldBox)
				{
					box = new Box(ul, ur, lr, ll, player, this);
				}
			}

			return box;
		}

		static MoveScore BumpScore(MoveScore score)
		{
			switch (score)
			{
				case MoveScore.NotAllowed:
					return MoveScore.One;
				case MoveScore.Zero:
					return MoveScore.One;
				case MoveScore.One:
					return MoveScore.Two;
				default:
					return MoveScore.NotAllowed;
			}
		}

        static void AddIfNotNull(List<Box> list, Box b)
		{
			if (b != null)
			{
				list.Add(b);
			}
		}

		public List<Box> SpeculateMove(IMove move, Player player)
		{
			List<Box> results = new List<Box>();

			if (IsAvailableMove(move))
			{
				AddIfNotNull(results, CreateBox(move, BoxDirection.Up, player));
				AddIfNotNull(results, CreateBox(move, BoxDirection.Down, player));
				AddIfNotNull(results, CreateBox(move, BoxDirection.Left, player));
				AddIfNotNull(results, CreateBox(move, BoxDirection.Right, player));
			}

			return results;
		}

		public bool IsAvailableMove(Corner start, Corner end)
		{
			return IsAvailableMove(new Move(new Line(start, end)));
		}

		public bool IsAvailableMove(IMove move)
		{
			Point start = move.Line.Start.Location;
			Point end = move.Line.End.Location;

			if (CornerPointOnBoard(start) && CornerPointOnBoard(end))
			{
				foreach (Move m in m_Moves)
				{
					if (m.Line.Start == move.Line.Start &&
						m.Line.End == move.Line.End)
					{
						return false;
					}
				}

				return true;
			}

			return false;
		}
	}
}
