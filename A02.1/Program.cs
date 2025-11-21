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
WriteLine ("""
   Welcome to "Computer Guessing Game"

   Game Rules:
   S => Accept the guess or to start the game.
   H => Your number is higher than the guessed one.
   L => Your number is lower than the guessed one.

   Let's start the game! Guess a number between 0 to 100.
   
   """);
while ((key = char.ToLower (ReadKey (intercept: true).KeyChar)) != 's');
while (count < 7) {
   count++;
   Write ($"Is the number {midNum}? ");
   do key = char.ToLower (ReadKey (true).KeyChar);
   while (key is not ('h' or 'l' or 's'));
   Write ($"{key}\n");
   if (key == 'h') minNum = midNum + 1;
   else if (key == 'l') maxNum = midNum - 1;
   else if (key == 's') break;
   midNum = (maxNum + minNum) / 2;
}
if (key == 's') WriteLine ($"\nFinally, I found the number, its: {midNum}!");
else WriteLine ("\nAh! I could not guess the number.");