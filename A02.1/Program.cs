// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on A02.1: Computer Guessing Game.
// This program finds the number you are thinking, between 0 to 100 within 7 guesses.
// ------------------------------------------------------------------------------------------------
using static System.Console;

char key; int maxNum = 100, minNum = 1, midNum = 50, count = 0;
WriteLine ("Welcome to \"Computer Guessing Game\".\n" +
           "Game Rules:\nS => Accept the guess or to start the game.," +
           "\nH => Your number is higher than the guessed one., " +
           "\nL => Your number is lower than the guessed one.," +
           "\nX => Exit the game.\n\nLets start the game! Guess a number between 0 to 100.");
while ((key = char.ToLower (ReadKey (intercept: true).KeyChar)) != 's')
   if (key == 'x') return;
while (count < 7) {
   count++;
   Write ($"Is the number {midNum}? ");
   do key = char.ToLower (ReadKey (true).KeyChar);
   while (key is not ('s' or 'h' or 'l' or 'x'));
   Write ($"{key}\n");
   if (key is 'x' or 's') break;
   else if (key == 'h') minNum = midNum + 1;
   else if (key == 'l') maxNum = midNum - 1;
   midNum = (maxNum + minNum) / 2;
}
if (count > 6 && key != 's') WriteLine ("\nAh! I could not guess the number.");
else if (key == 's') WriteLine ($"\nFinally, I found the number, its: {midNum}!");