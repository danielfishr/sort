namespace Common;

public static class ListUtilities
{
    public static void VerifySorted(IEnumerable<int> input)
    {
        var list = input.ToList();
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] > list[i + 1])
            {
                Console.WriteLine("Failed to sort");
                Environment.Exit(-1);
            }
        }
    }

    public static List<int> CreateList(int size, int? seed = null)
    {
        List<int> ints = new List<int>();
        Random random = new Random(seed ?? new Random().Next());
        foreach (var _ in Enumerable.Range(1, size))
        {
            ints.Add(random.Next(size * 2));
        }
        return ints;
    }
}