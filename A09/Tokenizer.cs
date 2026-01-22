namespace A09;

#region class Tokenizer ---------------------------------------------------------------------------
class Tokenizer {
   public Tokenizer (Evaluator eval, string text) {
      mText = text; mN = 0; mEval = eval;
   }

   #region Method --------------------------------------------------------
   public Token Next () {
      while (mN < mText.Length) {
         char ch = mText[mN++];
         switch (ch) {
            case ' ' or '\t': continue;
            case >= '0' and <= '9' or '.': return GetNumber ();
            case '(' or ')': return new TPunctuation (ch);
            case '*' or '/' or '^' or '=': return new TOpArithmetic (mEval, ch);
            case '+' or '-':
               return mEval.GetPrevToken is TLiteral or TVariable or TPunctuation { Punct: ')' }
                                                                    ? new TOpArithmetic (mEval, ch)
                                                                    : new TOpUnary (mEval, ch);
            case >= 'a' and <= 'z': return GetIdentifier ();
            default: return new TError ($"Unknown symbol: {ch}");
         }
      }
      return new TEnd ();
   }
   #endregion

   #region Implementation -------------------------------------------------------------------------
   // Finds out variable and mathematical functions.
   Token GetIdentifier () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is >= 'a' and <= 'z') continue;
         mN--; break;
      }
      string sub = mText[start..mN];
      // Checks whether the given input is a supported mathematical function.
      if (mFuncs.Contains (sub)) return new TOpFunction (mEval, sub);
      return new TVariable (mEval, sub);
   }

   // Extracts numbers from the given input.
   Token GetNumber () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is >= '0' and <= '9' or '.') continue;
         mN--; break;
      }
      string sub = mText[start..mN];
      // Convert the string number to double number.
      if (double.TryParse (sub, out double f)) return new TLiteral (f);
      return new TError ($"Invalid number: {sub}");
   }
   #endregion

   #region Private Data ---------------------------------------------------------------------------
   int mN; // Position within the text.
   readonly Evaluator mEval;
   readonly string mText;
   // Supported mathematical functions.
   readonly HashSet<string> mFuncs = ["sin", "cos", "tan", "sqrt", "log", "exp", "asin", "acos", "atan"];
   #endregion
}
#endregion