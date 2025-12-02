// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on branch A03: Spell Bee.
// This program is used to identify all words that can be formed using the provided letters.
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;

#region class Program -----------------------------------------------------------------------------
class Program {
   #region Implementation -------------------------------------------
   static void Main () {
      while (true) {
         var letters = new StringBuilder ();
         Write ("Please enter exactly 7 letters to find the matching words: ");
         while (letters.Length < 7) {
            char key = char.ToUpper (ReadKey (true).KeyChar);
            if (char.IsLetter (key)) {
               Write (key);
               letters.Append (key);
            }
         }
         WriteLine ();
         PrintSortedWords (letters.ToString ());
         WriteLine ("Press any key to try again, or Esc to quit.");
         if (ReadKey (true).Key == ConsoleKey.Escape) break;
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
      var scores = sortedWords.ToDictionary (word => word, word => {
         int wordLen = word.Length;
         return letters.All (l => word.Contains (l)) ?
         wordLen + 7 : wordLen > 4 ? wordLen : 1;
      });
      // Printing the words along with sorted scores.
      int wordScore; string word;
      foreach (var score in scores.OrderByDescending (s => s.Value)) {
         wordScore = score.Value;
         word = score.Key;
         ForegroundColor = wordScore > word.Length ? ConsoleColor.Green : ConsoleColor.Gray;
         WriteLine ($"{wordScore, 2}. {word}");
      }
      ResetColor ();
      WriteLine ($"--------\n{scores.Values.Sum ()} Total\n");
   }
   #endregion
}
#endregion