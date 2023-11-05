namespace BinaryTree;

public class BinaryNode<T> where T : IComparable
{
   public T Value { get; }
   public BinaryNode<T>? Left { get; set;}
   public BinaryNode<T>? Right { get; set;}

   public int? BalanceFactor =>
      (Right?.Count() ?? 0) - (Left?.Count() ?? 0);

   public int Height =>
      Math.Max((Right?.Height ?? 0) + 1, (Left?.Height ?? 0) + 1);

   public BinaryNode(T value)
   {
      Value = value;
   }

   public void Insert(T i)
   {
      if (i.CompareTo(Value) > 0)
      {
         if (Right != null)
            Right.Insert(i);
         else
            Right = new BinaryNode<T>(i);
      }
      if (i.CompareTo(Value) < 0)
      {
         if (Left != null)
            Left.Insert(i);
         else
            Left = new BinaryNode<T>(i);
      }
   }

   public BinaryNode<T> Balance(Action? action = null)
   {
      var root = this;
      while (root.BalanceFactor > 1)
         root = root.RotateLeft();
      while (BalanceFactor < -1)
         root = root.RotateRight();
      root.Left = root.Left?.Balance(action);
      root.Right = root.Right?.Balance(action);
      return root;
   }

   public int Count() => (Left?.Count() ?? 0) + (Right?.Count() ?? 0) + 1;

   public BinaryNode<T> RotateLeft()
   {
      if(Right?.BalanceFactor < 0)
      {
         Right = Right.RotateRight();
      }
      var newLeftRight = Right?.Left;
      BinaryNode<T> newRoot = Right ?? throw new InvalidOperationException("Cannot rotate left with no right node");
      newRoot.Right = Right?.Right;
      newRoot.Left = this;
      newRoot.Left.Right = newLeftRight;
      return newRoot;
   }

   public BinaryNode<T> RotateRight()
   {
      if(Left?.BalanceFactor > 0)
      {
         Left = Left.RotateLeft();
      }
      var newRightLeft = Left?.Right;
      BinaryNode<T> newRoot = Left ?? throw new InvalidOperationException("Cannot rotate right with no left node");
      newRoot.Left = Left?.Left;
      newRoot.Right = this;
      newRoot.Right.Left = newRightLeft;
      return newRoot;
   }

   public BinaryNode<T>? Find(T i)
   {
      var comparison = i.CompareTo(Value);
      if (comparison == 0)
         return this;
      if(comparison > 0)
         return Right?.Find(i) ?? null;
      return Left?.Find(i) ?? null;
   }

   public void Print()
   {
      ActualPrint();
      Console.WriteLine(" - - - ");
   }

   private void ActualPrint()
   {
      string left = Left?.Value.ToString() ?? "";
      string right = Right?.Value.ToString() ?? "";
      if (left != "")
         Console.WriteLine($"{Value} --> {left};");
      if (right != "")
         Console.WriteLine($"{Value} --> {right};");
      //Console.WriteLine($"Value: {Value} Left: {left} Right: {right} Balance: {BalanceFactor} Height: {Height}");
      Left?.ActualPrint();
      Right?.ActualPrint();
   }
}