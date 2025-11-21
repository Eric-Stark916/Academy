// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on branch A03: Spell Bee.
// This program is used to identify all words that can be formed using the provided letters.
// ------------------------------------------------------------------------------------------------
using static System.Console;

#region class Program -----------------------------------------------------------------------------
class Program {
   #region Implementation -------------------------------------------
   static void Main () {
      while (true) {
         string letters = "";
         Write ("Please enter exactly 7 letters to find the matching words: ");
         while (letters.Length < 7) {
            char key = char.ToUpper (ReadKey (intercept: true).KeyChar);
            if (char.IsLetter (key)) {
               Write (key);
               letters += key;
            }
         }
         WriteLine ();
         PrintSortedWords (letters);
         WriteLine ("Press any key to try again, or Esc to quit.");
         if (ReadKey (intercept: true).Key == ConsoleKey.Escape) break;
         WriteLine ();
      }
   }

   // Displays all words from the list that can be formed using the letters provided by the user.
   static void PrintSortedWords (string letters) {
      // Sorting the words.
      var sortedWords = File.ReadAllLines ("C:/etc/words.txt").Where (word => word.Length >= 4
                                                           && word.Contains (letters[0])
                                                           && word.All (c => letters.Contains (c))).ToList ();
      // Scoring the words.
      var scores = sortedWords.ToDictionary (word => word,
         word => letters.All (l => word.Contains (l))
         ? word.Length + 7 : word.Length > 4 ? word.Length : 1);
      // Printing the words.
      foreach (var score in scores.OrderByDescending (x => x.Value)) {
         ForegroundColor = score.Value > score.Key.Length ? ConsoleColor.Green : ConsoleColor.Gray;
         WriteLine ($"{score.Value,2}. {score.Key}");
      }
      ResetColor ();
      WriteLine ($"--------\n{scores.Values.Sum ()} Total\n");
   }
   #endregion
}
#endregion