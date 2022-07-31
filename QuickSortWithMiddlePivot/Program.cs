using System.Diagnostics;
using static Common.ListUtilities;

// unstable
// space complexity O(1) aka in-place 
// O(n*log(n)) time complexity in the average case
// O(n²) time complexity in the  worst cases

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
    Quicksort(toSort, 0, toSort.Length - 1);
    sw.Stop();
    VerifySorted(toSort);
    Console.WriteLine($"Sorted {toSort.Length:N0} items in {sw.ElapsedMilliseconds}ms");
}

static void Quicksort(int[] arr, int start, int end)
{
    int pivotVal = arr[(end + start) / 2];
    int left = start;
    int right = end;
    while (left <= right)
    {
        while (arr[left] < pivotVal)
        {
            left++;
        }
        while (arr[right] > pivotVal)
        {
            right--;
        }
        if (left <= right)
        {
            (arr[left], arr[right]) = (arr[right], arr[left]);
            left++;
            right--;
        }
    }
    if (start < right)
    {
        Quicksort(arr, start, left - 1);
    }
    if (end > left)
    {
        Quicksort(arr, right + 1, end);
    }
}