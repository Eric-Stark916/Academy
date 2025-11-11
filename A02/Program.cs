// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// This program lets the user guess a random number between 1 to 100.
// This program also provides feedback after each attempt.
// ------------------------------------------------------------------------------------------------
using static System.Console;

const int min = 1, max = 101;
while (true) {
   int numToGuess = new Random ().Next (min, max);
   while (true) {
      Write ("Guess the number between 1 to 100: ");
      if (!int.TryParse (ReadLine (), out int guess) || guess is < min or >= max) {
         WriteLine ("Invalid input.\n");
         continue;
      }
      if (guess == numToGuess) break;
      WriteLine ($"Your guess is too {(guess > numToGuess ? "high" : "Low")}.\n");
   }
   Write ($"You guessed correctly. The number is {numToGuess}.\n\nPress Enter to play again!");
   if (ReadKey ().Key != ConsoleKey.Enter) break;
   Clear ();
}