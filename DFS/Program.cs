
var n1 = new Node("A")
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


DFS(n1);

void DFS(Node n)
{
   var s = new Stack<Node>();
   s.Push(n);
   while (s.Count > 0)
   {
      var node = s.Pop();
      Console.WriteLine(node.Value);
      foreach (var child in node.Children
                  .Select((x,i) => (x,i))
                  .OrderByDescending(x=>x.i).Select(x=>x.x))
      {
         s.Push(child);
      }
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

