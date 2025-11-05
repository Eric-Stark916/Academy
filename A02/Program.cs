// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// This program lets the user guess a random number between 1 to 100.
// This program also provides feedback after each attempt.
// ------------------------------------------------------------------------------------------------
using static System.Console;

int numToGuess = new Random ().Next (1, 101), attempt = 1;
while (true) {
   if (attempt != 1) WriteLine ($"Attempt: {attempt}");
   Write ("Guess the number between 1 to 100 or 'G' to give up: ");
   var inp = ReadLine ()?.Trim ().ToLower ();
   if (inp == "g") break;
   if (int.TryParse (inp, out int guess) && guess < 101 && guess > 0) {
      attempt++;
      if (numToGuess == guess) {
         Write ($"You guessed correctly. The number is {numToGuess}." +
            $"\n\nPress 'P' to play again or 'E' to exit.");
         ConsoleKey key;
         while ((key = ReadKey (true).Key) != ConsoleKey.P && key != ConsoleKey.E)
            Write ("\n\nInvalid input. Press 'P' to play again or 'E' to exit.");
         if (key == ConsoleKey.E) break;
         WriteLine ("\n");
         attempt = 1;
         numToGuess = new Random ().Next (1, 101);
         continue;
      }
      WriteLine (guess > numToGuess ?
         "Your guess is high. Try again.\n" : "Your guess is low. Try again.\n");
   } else WriteLine ("Invalid input.\n");
}