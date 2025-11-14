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
internal class Program {
   #region Implementation -------------------------------------------
   static void Main () {
      while (true) {
         Write ("Please enter only letters (without space) to find the matching words, or 'X' to exit: ");
         var letters = ReadLine ()?.Trim ().ToUpper ();
         if (letters == null || letters.Length == 0 || !letters.All (c => char.IsLetter (c))) continue;
         if (letters.All (ch => ch == 'X')) break;
         WriteLine ();
         PrintSortedWords (letters);
      }
   }

   // Prints the words that can be created using the given input.
   static void PrintSortedWords (string letters) {
      // Sorting the words.
      var wordList = File.ReadAllLines ("C:/Work/Datas for code/words (1).txt");
      var sortedWordList = wordList
      .Where (word => word.Length >= 4 && word.Contains (letters[0])
      && word.All (c => letters.Contains (c))).ToList ();
      // Scoring the words.
      Dictionary<string, int> scores = [];
      foreach (var word in sortedWordList) {
         int score = letters.All (l => word.Contains (l, StringComparison.CurrentCultureIgnoreCase))
            ? word.Length + 7 : word.Length > 4 ? word.Length : 1;
         scores.Add (word, score);
      }
      // Printing the words.
      foreach (var word in scores.OrderByDescending (x => x.Value)) {
         ForegroundColor = word.Value > word.Key.Length ? ConsoleColor.Green : ConsoleColor.Gray;
         WriteLine ($"{word.Value,2}. {word.Key}");
      }
      WriteLine ($"--------\n{scores.Values.Sum ()} Total\n");
   }
   #endregion
}
#endregion