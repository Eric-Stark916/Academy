// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2025.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on branch A09.1: Circular Queue
// This program implements a generic queue.
// ------------------------------------------------------------------------------------------------
using static System.Console;

#region class Program -----------------------------------------------------------------------------
class Program {
   #region Implementation ------------------------------------------------
   static void Main () => TestMyQueue ();
  
   //Test cases for Queue
   static void TestMyQueue () {
      TQueue<int> n = new ();
      WriteLine ($"No of free slots: {n.Slots}");
      n.Enqueue (1);
      n.Enqueue (2);
      Write ("These are the current elements in the queue: "); n.PrintQueue ();
      WriteLine ($"\nOccupied: {n.Occupied}");
      n.Enqueue (3);
      //n.Dequeue();
      n.Enqueue (4);
      Write ("These are the current elements in the queue: "); n.PrintQueue ();
      WriteLine ($"\nNo of free slots: {n.Slots}");
      n.Enqueue (5);
      Write ("These are the current elements in the queue: "); n.PrintQueue ();
      WriteLine ($"\nNo of free slots: {n.Slots}");
   }
   #endregion
}
#endregion

#region class TQueue<T> -----------------------------------------------------------------------
class TQueue<T> {
   #region Constructor --------------------------------------------------
   public TQueue () {
      _data = new T[4];
      _count = 0;
      _isEmpty = 0;
      _whtNxt = 0;
   }
   #endregion

   #region Methods ------------------------------------------------------
   /// <summary>Inserts an element at the end of the queue.</summary>
   public void Enqueue (T input) {
      _count++;
      if (_count > _data.Length) Resize ();
      _data[_isEmpty++] = input;
      // Also adds elements to the front of the queue once it reaches the rear end.
      if (_count != _isEmpty) _isEmpty = (_isEmpty + 1) % _data.Length;
   }

   /// <summary>Removes and returns the item at the front of the queue.</summary>
   public T Dequeue () {
      if (_count == 0) throw new Exception ("Nothing found to remove");
      T item = _data[_whtNxt++];
      _whtNxt = Calculate ();
      _count--;
      return item;
   }

   /// <summary>Prints all elements in the queue or prints and returns a specific element when an index is provided.</summary>
   public T? PrintQueue (int? num = null) {
      if (num.HasValue) {
         if (num < 0 || num >= _count) throw new Exception ("Invalid index");
         T item = _data[Calculate ((int)num)]; // gets the element in the particular index.
         return item;
      }
      for (int i = 0; i < _count; i++) Console.Write (_data[Calculate (i)] + " ");
      return default;
   }

   /// <summary>Number of items currently in the queue</summary>
   public int Occupied => _count;

   /// <summary>Current number of empty slots in the queue.</summary>
   public int Slots => _data.Length - _count;
   #endregion

   #region Implementation -----------------------------------------------
   // Doubles the size of the queue when the queue is full.
   void Resize () {
      int newSize = _data.Length * 2; // Doubles the size.
      T[] newData = new T[newSize];
      // Copies existing queue elements into the new array in correct FIFO order starting from the front.
      for (int i = 0; i < _data.Length; i++) newData[i] = _data[(_whtNxt + i) % _data.Length];
      _data = newData; // Switches the reference to the larger array.
      _whtNxt = 0;
   }
   #endregion

   // Helper --------------------------------------------------------
   int Calculate (int n = 0) => (_whtNxt + n) % _data.Length;

   #region Private Variables ----------------------------------------
   T[] _data;
   int _count, _isEmpty, _whtNxt;
   #endregion
}
#endregion