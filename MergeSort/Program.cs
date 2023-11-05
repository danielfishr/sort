using System.Diagnostics;
using static Common.ListUtilities;



//CreateListAndSort(listSize: 7);
CreateListAndSort(listSize: 1_000);
CreateListAndSort(listSize: 10_000);
CreateListAndSort(listSize: 100_000);
CreateListAndSort(listSize: 1_000_000);
CreateListAndSort(listSize: 5_000_000);
CreateListAndSort(listSize: 10_000_000);

void CreateListAndSort(int listSize)
{
    int[] toSort = CreateList(listSize).ToArray();
    Stopwatch sw = Stopwatch.StartNew();
    Mergesort(toSort, 0, toSort.Length - 1);
    sw.Stop();
    VerifySorted(toSort);
    Console.WriteLine($"Sorted {toSort.Length:N0} items in {sw.ElapsedMilliseconds}ms");
}

static void Mergesort(int[] arr, int start, int end)
{
    if (start >= end)
    {
        return;
    }
    int midIdx = (end + start) / 2;
    Mergesort(arr, start, midIdx);
    Mergesort(arr, midIdx+1, end);
    Merge(arr, start, midIdx, end);
}

static void Merge(int[] arr, int start, int midIdx, int end)
{
    //Console.WriteLine($"{start} {midIdx} {end}");
    var first = new int[midIdx - start+1];
    var second = new int[end - midIdx];
    Array.Copy(arr, start, first, 0, midIdx - start+1);
    Array.Copy(arr, midIdx+1,  second, 0, end - midIdx);
    var firstIdx = 0;
    var secondIdx = 0;
    for (int i = start; i <= end; i++)
    {
        if (firstIdx == first.Length && secondIdx == second.Length-1)
        {
            arr[i] = second[secondIdx++];
        }
        else if (firstIdx == first.Length)
        {
            arr[i] = Math.Min(second[secondIdx], second[secondIdx++ + 1]);
        }
        else if (secondIdx == second.Length && firstIdx == first.Length -1)
        {
            arr[i] = first[firstIdx++];
        }
        else if (secondIdx == second.Length )
        {
            arr[i] = Math.Min(first[firstIdx], first[firstIdx + 1]);
            firstIdx++;
        }
        else if (first[firstIdx] < second[secondIdx])
        {
            arr[i] = first[firstIdx++];
        }
        else
        {
            arr[i] = second[secondIdx++];
        } 
    } 
    //Console.WriteLine(string.Join(" ", arr));
    try
    {
        VerifySorted(arr, start, end, true);
    }
    catch
    {
        Console.WriteLine(string.Join(" ", arr));
        throw;
    }
}