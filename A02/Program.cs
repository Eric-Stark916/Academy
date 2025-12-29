// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// This program lets the user guess a random number between 1 to 100.
// This program also provides feedback after each attempt.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace TextEditor {
   internal class Program {
      static void Main () {
         while (true) {
            Write ("What operation to be done (ADD,DEL,UND,RED) or X to exit: ");
            string result = ReadLine ()!.ToLower ();
            while (result == "add") {
               Write ("Enter the words to get added or 'X' to return to the main menu: ");
               string input = ReadLine ()!;
               if (input.ToLower () == "x") break;
               WriteLine (Add (input));
            }
            while (result == "del") {
               Write ("Enter the number of items to be deleted from the last or 'X' to return to the main menu: ");
               string input = ReadLine ()!;
               if (input?.ToLower () == "x") break;
               if (int.TryParse (input, out int res))
                  WriteLine (Del (res));
               else WriteLine ("Wrong input");
            }
            if (result.ToLower () == "und") WriteLine (Undo ());
            if (result.ToLower () == "red") WriteLine (Redo ());
            if (result.ToLower () == "x") break;
         }
      }
      public static string output = "";
      public static string Text = "";
      public static string Add (string text) {
         Text = text;
         output += Text;
         return output;
      }
      public static string Del (int num) {
         string change = output;
         Text = change.Substring (0, change.Length - num);
         return change.Substring (0, change.Length - num);
      }
      public static string Undo () {
         return output;
      }
      public static string Redo () {
         return Text;
      }
   }
}
