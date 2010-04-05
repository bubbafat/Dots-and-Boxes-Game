using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace BoxGame
{
	class Corner : ICorner
	{
		Point m_Location;
		ICornerMapper m_Mapper;
		Color m_Color;

		public Corner(Point location, ICornerMapper mapper, Color color)
		{
			m_Location = location;
			m_Mapper = mapper;
			m_Color = color;
		}

		public System.Drawing.Point Location
		{
			get
			{
				return m_Location;
			}
		}


		void DrawDot(IGraphicProvider g, Point p)
		{
			p.Offset(-1, -1);
			g.DrawRectangle(new Rectangle(p, new Size(3, 3)), m_Color);
		}

		public void Render(IGraphicProvider gfx)
		{
			DrawDot(gfx, GraphicsPoint);
		}


		public bool Equals(ICorner other)
		{
			return m_Location == other.Location;
		}
		public int CompareTo(ICorner other)
		{
			// these must be run in other.  
			// Do not consolidate these.
			if (m_Location.Y < other.Location.Y)
			{
				return -1;
			}

			if (m_Location.Y > other.Location.Y)
			{
				return 1;
			}

			if (m_Location.X < other.Location.X)
			{
				return -1;
			}

			if (m_Location.X > other.Location.X)
			{
				return 1;
			}

			return 0;
		}


		internal Point GraphicsPoint
		{
			get
			{
				return m_Mapper.GetGraphicsPoint(this);
			}
		}

		internal bool IsAdjacentTo(ICorner c)
		{
			bool bOk = false;

			if (!Equals(c))
			{
				if (Location.X == c.Location.X)
				{
					bOk = (Math.Abs(Location.Y - c.Location.Y) == 1);
				}
				else if (Location.Y == c.Location.Y)
				{
					bOk = (Math.Abs(Location.X - c.Location.X) == 1);
				}
			}

			return bOk;
		}
	}
}
