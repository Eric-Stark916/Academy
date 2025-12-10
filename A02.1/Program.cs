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
      Write ($"My guess is {guess, 3}. Is your number lower ? Press 'Y' for Yes or 'N' for No: ");
      do key = char.ToUpper (ReadKey (true).KeyChar);
      while (key is not ('Y' or 'N'));
      Write ($"{key}\n");
      if (key == 'N') minNum = guess + 1;
      else maxNum = guess - 1;
      if (minNum > maxNum) {
         WriteLine ($"\nFinally, I found the number! it's: {(key == 'Y' ? guess - 1 : guess)}. " +
                                                                $"Press Enter to play again.\n");
         break;
      }
      guess = (maxNum + minNum) / 2;
   }
   if (ReadKey ().Key != ConsoleKey.Enter) break;
}