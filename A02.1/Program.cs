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
   char key; int maxNum = 100, minNum = 1, guess = 50;
   WriteLine ("Welcome to \"Computer Guessing Game\"\nThink of a number from 1 to 100 and press S to start the game.\n");
   while (char.ToLower (ReadKey (true).KeyChar) != 's');
   while (true) {
      Write ($"My guess is {guess}. Is your number higher(H), lower(L), or correct(S) ?");
      do key = char.ToLower (ReadKey (true).KeyChar);
      while (key is not ('h' or 'l' or 's'));
      Write ($"{key}\n");
      if (key == 's') {
         WriteLine ($"\nFinally, I found the number! it's: {guess}. Press Enter to play again.\n");
         break;
      } else if (key == 'h') minNum = guess + 1;
      else if (key == 'l') maxNum = guess - 1;
      if (minNum > maxNum) {
         WriteLine ("\nAh! I could not guess the number. Press Enter to play again.\n");
         break;
      }
      guess = (maxNum + minNum) / 2;
   }
   if (ReadKey ().Key != ConsoleKey.Enter) break;
}