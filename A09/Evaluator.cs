namespace A09;

#region EvalException -----------------------------------------------------------------------------
class EvalException : Exception {
   public EvalException (string message) : base (message) { }
}
#endregion

#region Evaluator ---------------------------------------------------------------------------------
class Evaluator {
   /// <summary>Gets previous token evaluated in evaluator.</summary>
   public Token? GetPrevToken { get; private set; }

   #region Method --------------------------------------------------------
   /// <summary>Evaluates an expression and returns its result.</summary>
   public double Evaluate (string text) {
      List<Token> tokens = new ();
      var tokenizer = new Tokenizer (this, text);
      for (; ; )
      {
         var token = tokenizer.Next ();
         GetPrevToken = token; // Save previous token for type inspection.
         if (token is TEnd) break;
         if (token is TError err) throw new EvalException (err.Message);
         tokens.Add (token);
      }
      TVariable? tVariable = null;
      // Checks if this is a variable assignment.
      if (tokens.Count > 2 && tokens[0] is TVariable tvar && tokens[1] is TOpArithmetic { Op: '=' }) {
         tVariable = tvar;
         // Removes the first two tokens.
         tokens.RemoveRange (0, 2);
      }
      foreach (var t in tokens) Process (t);
      while (mOperators.Count > 0) ApplyOperator ();
      double f = mOperands.Pop (); // Pops the number.
      if (tVariable != null) mVars[tVariable.Name] = f; // Stores the variable along with its assigned value.
      return f;
   }
   #endregion

   // Base priority for operator or function evaluation.
   public int BasePriority { get; private set; }
   #region Method --------------------------------------------------------
   public double GetVariable (string name) {
      if (mVars.TryGetValue (name, out double f)) return f;
      throw new EvalException ($"Unknown variable: {name}");
   }
   #endregion

   #region Implementation ------------------------------------------------
   // Pops an operator and its operands, applies it, and pushes the result back.
   void ApplyOperator () {
      var op = mOperators.Pop ();
      var f1 = mOperands.Pop ();
      if (op is TOpFunction func) mOperands.Push (func.Evaluate (f1));
      else if (op is TOpUnary unary) mOperands.Push (unary.Apply (f1));
      else if (op is TOpArithmetic arith) {
         var f2 = mOperands.Pop ();
         mOperands.Push (arith.Evaluate (f2, f1));
      }
   }
   bool hasPunct = false; // Indicates if a bracket is present.

   void Process (Token token) {
      switch (token) {
         case TNumber num:
            mOperands.Push (num.Value);
            break;
         case TOperator op2:
            // Checks if the operator on the stack has higher priority than the current operator.
            if (mOperators.Count > 0 && mOperators.Peek () is TOperator op1 && op1.Priority >= op2.Priority && !hasPunct) {
               Console.WriteLine (mOperators.Peek ().Priority);
               ApplyOperator ();
            }
            mOperators.Push (op2);
            break;
         case TPunctuation p:
            if (p.Punct == '(') {
               hasPunct = true;
            } else if (hasPunct) {
               while (mOperators.Count > 0) ApplyOperator ();
               hasPunct = false;
            }
            break;
         default:
            throw new EvalException ($"Unknown token: {token}");
      }
   }
   #endregion

   #region Private Data ---------------------------------------------------------------------------
   readonly Stack<double> mOperands = new ();
   readonly Stack<TOperator> mOperators = new ();
   readonly Dictionary<string, double> mVars = [];
   #endregion
}
#endregion