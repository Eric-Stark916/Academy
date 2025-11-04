// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// This program lets the user guess a random number between 1 to 100. And shows feedback
// ------------------------------------------------------------------------------------------------
using static System.Console;

int randomNum = new Random ().Next (1, 101);
while (true) {
   Write ("Guess the number between 1 to 100: ");
   if (int.TryParse (ReadLine (), out int num) && num < 101 && num > 0) {
      if (randomNum == num) {
         Write ($"You guessed correctly. The number is {randomNum}.\n");
         break;
      } else WriteLine (num > randomNum + 5 ? "Your guess is too high.\n" : num < randomNum - 5 ?
         "Your guess is too low.\n" : "Your guess is close!\n");
   }
}