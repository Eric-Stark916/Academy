using static System.Console;
namespace A09;

#region class Program -----------------------------------------------------------------------------
class Program {
   #region Implementation ------------------------------------------------
   static void Main () {
      var eval = new Evaluator ();
      for (; ; )
      {
         Write ("> ");
         string text = ReadLine () ?? "".ToLower ();
         if (text == "exit") break;
         try {
            double result = eval.Evaluate (text);
            ForegroundColor = ConsoleColor.Green;
            WriteLine (result);
         } catch (Exception e) {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine (e.Message);
         }
         ResetColor ();
      }
   }
   #endregion
}
#endregion