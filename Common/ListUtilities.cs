namespace Common;

public static class ListUtilities
{
    public static void VerifySorted(IEnumerable<int> input)
    {
        VerifySorted(input, 0, input.Count() - 1);
    }
    
    public static void VerifySorted(IEnumerable<int> input, int start, int end, bool @throw = false)
    {
        var list = input.ToList();
        for (int i = start; i < end; i++)
        {
            if (list[i] > list[i + 1])
            {
                Console.WriteLine("Failed to sort");
                if (@throw)
                {
                    throw new Exception($"IEnumerable not sorted at index {i}");
                }
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