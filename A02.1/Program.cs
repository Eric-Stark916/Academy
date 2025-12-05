// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on A02.1: Computer Guessing Game.
// This program finds the number you are thinking, between 0 to 100 within 7 guesses.
// ------------------------------------------------------------------------------------------------
using static System.Console;

while (true) {
   char key; int maxNum = 100, minNum = 1, guess = 50;
   WriteLine ("Welcome to \"Computer Guessing Game\"\nThink of a number from 0 to 100.\n");
   while (true) {
      Write ($"My guess is {guess}. Is your number lower ? Yes(s) or No(n): ");
      do key = char.ToLower (ReadKey (true).KeyChar);
      while (key is not ('s' or 'n'));
      Write ($"{key}\n");
      if (key == 'n') minNum = guess + 1;
      else maxNum = guess - 1;
      if (minNum > maxNum) {
         WriteLine ($"\nFinally, I found the number! it's: {(key == 's' ? guess - 1 : guess)}. " +
                                                                $"Press Enter to play again.\n");
         break;
      }
      guess = (maxNum + minNum) / 2;
   }
   if (ReadKey ().Key != ConsoleKey.Enter) break;
}