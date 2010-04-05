using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Microsoft.Ink;


namespace BoxGame
{
	class InkInputPlayer : Player, IDisposable
	{
		InkPicture m_InkPicture;
		EventWaitHandle m_Waiter;
		IMove m_Move;
		GameBoard m_GameBoard;

		public InkInputPlayer(string name, string initials, Color color, InkPicture inkPanel, GameBoard board)
			: base(name, initials, color)
		{
			m_InkPicture = inkPanel;
			m_GameBoard = board;
		}

		protected override IMove GetNextMove_Impl(IGameBoard board)
		{
			m_GameBoard = board as GameBoard;
			InkCollectorStrokeEventHandler handler = new InkCollectorStrokeEventHandler(m_InkPicture_Stroke);
			IMove move = null;

			m_Waiter = new EventWaitHandle(false, EventResetMode.ManualReset);
			m_InkPicture.Stroke += handler;

			try
			{
				while (move == null)
				{
					m_Waiter.Reset();
					if (m_Waiter.WaitOne())
					{
						move = m_Move;
					}
				}
			}
			finally
			{
				m_InkPicture.Stroke -= handler;
			}

			return move;
		}

        static Point StrokePointToClientPoint(Graphics g, Point p)
		{
			const double mmPerInch = 25.40;
			const double pointsPerMM = 100;

			const double scalingFactorG = mmPerInch * pointsPerMM;

			int scalingFactorX = (int) Math.Ceiling(scalingFactorG / g.DpiX);
			int scalingFactorY = (int) Math.Ceiling(scalingFactorG / g.DpiY);

            return new Point
            {
                X = p.X / scalingFactorX,
                Y = p.Y / scalingFactorY,

            };
		}

		void m_InkPicture_Stroke(object sender, InkCollectorStrokeEventArgs e)
		{
			m_Move = null;
			e.Cancel = true;
			InkPicture ip = sender as InkPicture;

			Graphics g = null;

			lock (ip.Image)
			{
				g = Graphics.FromImage(ip.Image);
			}

			List<ICorner> corners = new List<ICorner>();

			foreach (Point p in e.Stroke.GetPoints())
			{
				Point clientP = StrokePointToClientPoint(g, p);
				ICorner c = m_GameBoard.ClosestCornerFromGraphicsPoint(clientP);
				if (!corners.Contains(c))
				{
					corners.Add(c);
				}
			}

			if (corners.Count == 2)
			{
				try
				{
					Line l = new Line(corners[0] as Corner, corners[1] as Corner);
					m_Move = new Move(l, this);
				}
				catch (ArgumentException)
				{
					/* the line sucks - eat it */
				}
			}

			m_Waiter.Set();
		}

        public void Dispose()
        {
            using (m_Waiter) { }
        }
	}
}
