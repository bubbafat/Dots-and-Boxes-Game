using System;
using System.Windows.Forms;

namespace BoxGame
{
	static class EntryPoint
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(new GameSettings());
		}
	}
}
