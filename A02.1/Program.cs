// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on A02.1: Computer Guessing Game.
// This program finds the number you are thinking, between 1 to 100 within 7 guesses.
// ------------------------------------------------------------------------------------------------
using static System.Console;

while (true) {
   char key; int maxNum = 101, minNum = 0, midNum = 50; // maxNum=101 to include 100 in guessing.
   WriteLine ("Welcome to \"Computer Guessing Game\"\nThink of a number from 1 to 100 and press S to start the game.\n");
   while (char.ToLower (ReadKey (intercept: true).KeyChar) != 's');
   while (true) {
      Write ($"My guess is {midNum}. Is your number higher(H), lower(L), or correct(S) ?");
      do key = char.ToLower (ReadKey (true).KeyChar);
      while (key is not ('h' or 'l' or 's'));
      Write ($"{key}\n");
      if (key == 'h') minNum = midNum;
      else if (key == 'l') maxNum = midNum;
      else if (key == 's') break;
      midNum = (maxNum + minNum) / 2;
      if (midNum <= minNum) break;
   }
   WriteLine ((key == 's' ? $"\nFinally, I found the number! it's: {midNum}." : "\nAh! I could not guess the number.") +
                                                                                " Press Enter to play again.\n");
   if (ReadKey ().Key != ConsoleKey.Enter) break;
}