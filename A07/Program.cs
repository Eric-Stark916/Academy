// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on branch A07: Double Parse
// This program Converts a string representation of a number to a double equivalent.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace A07;

#region class Program -----------------------------------------------------------------------------
class Program {
   #region Implementation -------------------------------------------
   static void Main () {
      while (true) {
         Write ("Enter the numbers to convert them into its equivalent double or 'X' to exit: ");
         string? input = ReadLine ()?.ToUpper ();
         if (string.IsNullOrEmpty (input)) continue;
         if (input == "X") break;
         if (Double.TryParse (input, out double result)) {
            WriteLine ($"The converted value: {result}");
            //WriteLine ($"Adding five to the resultant {result + 5}"); // To check if the string is actually converted into number.
         } else WriteLine ("Format is wrong!");
      }
   }
   #endregion
}
#endregion

#region class Double ------------------------------------------------------------------------------
class Double {
   #region Implementation -------------------------------------------
   // Checks whether the input character is a number.
   static bool IsNum (char c) => c >= '0' && c <= '9';
   #endregion

   #region Method ---------------------------------------------------
   /// <summary>
   /// Converts a string representation of a number to a double equivalent and returns true if parsing succeeds; otherwise, false.
   /// </summary>
   public static bool TryParse (string str, out double result) {
      result = 0;
      if (string.IsNullOrWhiteSpace (str)) return false;
      str = str.Trim ().ToUpper ();
      double numValue = 0; int dotPosition = 0, exponentValue = 0;
      bool isNegative = false, hasExponent = false, hasDot = false;
      for (int i = 0; i < str.Length; i++) {
         // Converts a string character to its equivalent number.
         if (IsNum (str[i])) {
            numValue = numValue * 10 + (str[i] - '0');
            if (hasDot) dotPosition++;
            continue;
         }
        // Checks for dot in the string.
        else if (str[i] == '.') {
            if (hasDot || !(i > 0 && IsNum (str[i - 1]) && i + 1 < str.Length && IsNum (str[i + 1])))
               return false;
            hasDot = true;
            continue;
         }
        // Checks for Exponential notation and value in the string.
        else if (str[i] == 'E') {
            if (hasExponent || i + 1 >= str.Length || !(i > 0 && IsNum (str[i - 1])))
               return false;
            if (!int.TryParse (str[(i + 1)..], out exponentValue) || exponentValue > 308 || exponentValue < -324)
               return false;
            hasExponent = true;
            break;
         }
        // Checks for leading sign.
        else if (i == 0 && str[0] == '-') {
            isNegative = true;
            continue;
         } else if (i == 0 && str[0] == '+') continue;
         else return false;
      }
      if (hasDot) numValue /= Math.Pow (10, dotPosition);
      if (hasExponent) numValue *= Math.Pow (10, exponentValue);
      if (isNegative) numValue = -numValue;
      result = numValue;
      return true;
   }
   #endregion
}
#endregion