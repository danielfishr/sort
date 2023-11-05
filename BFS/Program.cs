var n = new Node("A")
{
   Children =
   {
      new Node("A.A")
      {
         Children = { new Node("A.A.A") }
      },
      new Node("A.B")
      {
         Children = {
            new Node("A.B.A"),
            new Node("A.B.B") }
      }
   }
};

BFT(n);

void BFT(Node n)
{
   var q = new Queue<Node>();
   q.Enqueue(n);
   while (q.Count > 0)
   {
      var node = q.Dequeue();
      Console.WriteLine(node.Value);
      node.Children.ForEach(q.Enqueue);
   }
}

public class Node
{
   public string Value { get; }
   public List<Node> Children { get; } = new();

   public Node(string value)
   {
      Value = value;
   }
}