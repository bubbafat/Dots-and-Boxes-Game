using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace BoxGame
{
	/// <summary>
	/// A class that can draw itself onto a Graphics instance.
	/// </summary>
	public interface IRenderable
	{
		/// <summary>
		/// Render the class to the Graphics instance.
		/// </summary>
		/// <param name="gfx">The Graphics instance to draw on</param>
		void Render(IGraphicProvider gfx);
	}

	public interface IPlayer
	{
		string DisplayName
		{
			get;
		}

		string Initials
		{
			get;
		}

		System.Drawing.Color Color
		{
			get;
		}

		int Score
		{
			get;
		}

		IMove GetNextMove(IGameBoard board);
	}

	public interface IGame
	{
		IPlayer[] Players
		{
			get;
		}

		IGameBoard Board
		{
			get;
		}

		void Start(IGraphicProvider gfx);
	}

	public interface IGameBoard : IRenderable
	{
		int Rows
		{
			get;
		}

		int Columns
		{
			get;
		}

		ICorner[] this[int index]
		{
			get;
		}
	}

	public interface IMove : IRenderable, IComparable<IMove>
	{
		ILine Line
		{
			get;
		}

		IPlayer Player
		{
			get;
		}
	}

	public interface ICorner : IRenderable, IComparable<ICorner>
	{
		Point Location
		{
			get;
		}
	}

	public interface ILine: IComparable<ILine>
	{
		ICorner Start
		{
			get;
		}

		ICorner End
		{
			get;
		}
	}

	interface IBox : IRenderable
	{
		ILine Top
		{
			get;
		}

		ILine Bottom
		{
			get;
		}

		ILine Left
		{
			get;
		}

		ILine Right
		{
			get;
		}
	}

	public interface IGraphicProvider
	{
		void Invalidate();
		void DrawLine(Point start, Point end, Color color);
		void DrawRectangle(Rectangle rect, Color color);
		void DrawImage(Image img, int x, int y);
		void DrawString(Point loc, Font font, Color color, string str);
		void ShowUserTurn(IPlayer player);

		int DpiX
		{
			get;
		}
		int DpiY
		{
			get;
		}

		System.Drawing.Imaging.PixelFormat PixelFormat
		{
			get;
		}
	}

	public interface ICornerMapper
	{
		Point GetGraphicsPoint(ICorner corner);
		ICorner ClosestCornerFromGraphicsPoint(Point point);
		Size GetMinimumGraphicsSize(int DpiX, int DpiY);
	}
}
