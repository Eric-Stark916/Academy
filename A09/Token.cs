namespace A09;

# region class Token ------------------------------------------------------------------------------
abstract class Token { }
#endregion

#region class TNumber -----------------------------------------------------------------------------
// Base class for numbers and variables.
abstract class TNumber : Token {
   public abstract double Value { get; }
}
#endregion

#region class TLiteral ----------------------------------------------------------------------------
// Handles numbers.
class TLiteral : TNumber {
   public TLiteral (double f) => mValue = f;
   public override double Value => mValue;
   readonly double mValue;
}
#endregion

#region class TVariable ---------------------------------------------------------------------------
// Handles alphabetical variables.
class TVariable : TNumber {
   public TVariable (Evaluator eval, string name) => (Name, mEval) = (name, eval);
   // Property to read the stored name.
   public string Name { get; }
   public override double Value => mEval.GetVariable (Name);
   // Stores the variable.
   readonly Evaluator mEval;
}
#endregion

#region class TOperator ---------------------------------------------------------------------------
abstract class TOperator : Token {
   protected TOperator (Evaluator eval) => mEval = eval;
   public abstract int Priority { get; }
   readonly protected Evaluator mEval;
}
#endregion

#region class TOpArithmetic -----------------------------------------------------------------------
// Handles mathematical operators.
class TOpArithmetic : TOperator {
   public TOpArithmetic (Evaluator eval, char ch) : base (eval) => Op = ch;
   public char Op { get; }
   public override int Priority => sPriority[Op] + mEval.BasePriority;

   #region Implementation ------------------------------------------------
   static Dictionary<char, int> sPriority = new () {
      ['+'] = 1,
      ['-'] = 1,
      ['*'] = 2,
      ['/'] = 2,
      ['^'] = 3,
      ['='] = 4,
   };
   #endregion

   #region Method --------------------------------------------------------
   public double Evaluate (double a, double b) {
      return Op switch {
         '+' => a + b,
         '-' => a - b,
         '*' => a * b,
         '/' => a / b,
         '^' => Math.Pow (a, b),
         _ => throw new EvalException ($"Unknown operator: {Op}"),
      };
   }
   #endregion
}
#endregion

#region class TOpFunction -------------------------------------------------------------------------
class TOpFunction : TOperator {
   public TOpFunction (Evaluator eval, string name) : base (eval) => Func = name;
   public string Func { get; }
   public override int Priority => 4 + mEval.BasePriority;

   #region Method --------------------------------------------------------
   public double Evaluate (double f) {
      return Func switch {
         "sin" => Math.Sin (D2R (f)),
         "cos" => Math.Cos (D2R (f)),
         "tan" => Math.Tan (D2R (f)),
         "sqrt" => Math.Sqrt (f),
         "log" => Math.Log (f),
         "exp" => Math.Exp (f),
         "asin" => R2D (Math.Asin (f)),
         "acos" => R2D (Math.Acos (f)),
         "atan" => R2D (Math.Atan (f)),
         _ => throw new EvalException ($"Unknown function: {Func}")
      };

      // Helper -----------------------------------------------------------
      double D2R (double f) => f * Math.PI / 180; // Degree to radian.
      double R2D (double f) => f * 180 / Math.PI;
   }
   #endregion
}
#endregion

#region class TOpUnary ----------------------------------------------------------------------------
// Implements unary operation on operand (unary plus, unary minus).
class TOpUnary : TOperator {
   public TOpUnary (Evaluator eval, char ch) : base (eval) => Op = ch;
   public char Op { get; }
   public override int Priority => 5 + mEval.BasePriority;

   #region Method --------------------------------------------------------
   /// <summary>Applies the unary operator to the given value.<summary>
   public double Apply (double val) {
      return Op switch {
         '-' => -val,
         '+' => val,
         _ => throw new EvalException ($"Unknown unary operator: {Op}"),
      };
   }
   #endregion
}
#endregion

#region class TPunctuation ------------------------------------------------------------------------
// Handles brackets.
class TPunctuation : Token {
   public TPunctuation (char ch) => Punct = ch;
   public char Punct { get; private set; }
}
#endregion

#region class TEnd --------------------------------------------------------------------------------
class TEnd : Token { }
#endregion

#region class TError ------------------------------------------------------------------------------
class TError : Token {
   public TError (string message) => Message = message;
   public string Message { get; }
}
#endregion