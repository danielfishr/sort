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
    Sort(toSort, 0, toSort.Length - 1);
    sw.Stop();
    VerifySorted(toSort);
    Console.WriteLine($"Sorted {toSort.Length:N0} items in {sw.ElapsedMilliseconds}ms");
}

int Partition(int[] input, int start, int end)
{
    var pivotIdx = end;
    int pivotValue = input[pivotIdx];
    int idxToPutValSmallerThanPivot = start;
    for (int idxToCmpWithPivot = start; idxToCmpWithPivot <= end - 1; idxToCmpWithPivot++)
    {
        if (input[idxToCmpWithPivot] <= pivotValue)
        {
            (input[idxToPutValSmallerThanPivot], input[idxToCmpWithPivot]) = (input[idxToCmpWithPivot], input[idxToPutValSmallerThanPivot]);
            idxToPutValSmallerThanPivot++;
        }
    }
    (input[idxToPutValSmallerThanPivot], input[pivotIdx]) = (input[pivotIdx], input[idxToPutValSmallerThanPivot]);
    return idxToPutValSmallerThanPivot;
}

void Sort(int[] arr, int start, int end)
{
    if (start < end)
    {
        var i = Partition(arr, start, end);
        Sort(arr, start, i - 1);
        Sort(arr, i + 1, end);
    }
}