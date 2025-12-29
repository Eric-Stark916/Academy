// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// This program lets the user guess a random number between 1 to 100.
// This program also provides feedback after each attempt.
// ------------------------------------------------------------------------------------------------
namespace DialRotation {
   internal class Program {

      static void Main () {
         int dialPos = 50;
         int maxDialPos = 100;
         int minDialPos = 0;
         int count = 0;
         while (true) {
            Console.WriteLine ("Enter the number to get the dial indication:");
            string input = Console.ReadLine ()!.ToLower ();
            string input2 = input.Substring (1, input.Length - 1);
            int output = 0;
            if (int.TryParse (input2, out int result)) {
               if (input.Contains ("l")) {
                  output = dialPos - result;
                  if (output == 0) count++;
                  if (output < minDialPos) {
                     output = maxDialPos + output;
                     dialPos = output;
                  }
               }
               if (input.Contains ("r")) {
                  output = dialPos + result;
                  if (output == 0) count++;
                  if (output > maxDialPos) {
                     output = minDialPos + (100 - output);
                     dialPos = output;
                  }
               }
               Console.WriteLine ($"Current Dial position {output} - Instruction {input}-number of zeros achieved{count}");

            }
         }

      }
   }
}
