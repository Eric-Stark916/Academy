// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// This program lets the user guess a random number between 1 to 100.
// This program also provides feedback after each attempt.
// ------------------------------------------------------------------------------------------------
using static System.Console;

while (true) {
   int numToGuess = 80, attempt = 0, guess = 0;
   while (guess != numToGuess) {
      Write ("Guess the number between 1 to 100: ");
      if (!int.TryParse (ReadLine (), out guess) || guess > 100 || guess < 1) {
         WriteLine ("Invalid input.\n");
         continue;
      }
      attempt++;
      if (guess == numToGuess) break;
      WriteLine (guess > numToGuess ?
        "Your guess is high. Try again.\n" : "Your guess is low. Try again.\n");
   }
   Write ($"You guessed correctly in {attempt} attempt{(attempt > 1 ? "s" : "")}. " +
      $"The number is {numToGuess}." + $"\n\nPress Enter to play again!");
   if (ReadKey ().Key != ConsoleKey.Enter) break;
   Clear ();
}