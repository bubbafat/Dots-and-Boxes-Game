This is a quick-n-dirty implementation of the [Dots and Boxes]( http://en.wikipedia.org/wiki/Dots_and_Boxes)  game in C# using the Microsoft Ink (Tablet PC) API for input.

You can play against another person or against a few computer players (with varying strategies).   You make your move by drawing a line (using the mouse or input stylus) from one dot to another.  You don't need to be exact - the game will try and infer what you meant to do (and if it can't it will reject the move).

I wrote this back in 2003 or so after getting a tablet and wanting to experiment a little with ink input.  This is not a good example of solid coding practices :)  It was hacked together over a few hours and quickly forgotten.

I have made sure it compiles with VS2010 and put out a build that I've tested on Windows 7.

