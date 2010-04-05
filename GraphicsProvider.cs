using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace BoxGame
{
	class GraphicsProvider : IGraphicProvider
	{
		Microsoft.Ink.InkPicture m_InkPicture;
		Graphics m_Graphics;

		public GraphicsProvider(Microsoft.Ink.InkPicture inkPicture, System.Windows.Forms.Form form)
		{
			m_InkPicture = inkPicture;
			m_Graphics = null;
		}

		private Graphics Gfx
		{
			get
			{
				if (m_Graphics == null)
				{
					lock (m_InkPicture.Image)
					{
						m_Graphics = Graphics.FromImage(m_InkPicture.Image);
					}
				}

				return m_Graphics;
			}
		}


		SizeF m_PrevSize = SizeF.Empty;
		public void ShowUserTurn(IPlayer player)
		{
			Region r = new Region(new RectangleF(0, 0, m_PrevSize.Width, m_PrevSize.Height));
			Gfx.FillRegion(Brushes.White, r);
			Gfx.DrawString(player.DisplayName, new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, new PointF(0, 0));
			m_PrevSize = Gfx.MeasureString(player.DisplayName, new Font(FontFamily.GenericSansSerif, 10));
		}

		public void Invalidate()
		{
			lock (m_InkPicture.Image)
			{
				m_InkPicture.Invalidate();
			}
		}

		public void DrawLine(Point start, Point end, Color color)
		{
			Gfx.DrawLine(new Pen(color), start, end);
		}
		public void DrawRectangle(Rectangle rect, Color color)
		{
			Gfx.DrawRectangle(new Pen(color), rect);
		}

		public void DrawImage(Image img, int x, int y)
		{
			Gfx.DrawImage(img, x, y);
		}

		public int DpiX
		{
			get
			{
				return (int)Math.Ceiling(Gfx.DpiX);
			}
		}

		public int DpiY
		{
			get
			{
				return (int)Math.Ceiling(Gfx.DpiY);
			}
		}

		public System.Drawing.Imaging.PixelFormat PixelFormat
		{
			get
			{
				lock (m_InkPicture.Image)
				{
					return m_InkPicture.Image.PixelFormat;
				}
			}
		}

		public void DrawString(Point loc, Font font, Color color, string str)
		{
			Gfx.DrawString(str, font, new SolidBrush(color), loc);
		}

	}
}
