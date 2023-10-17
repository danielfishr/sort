using System.Diagnostics;
using static Common.ListUtilities;

// Description: maximums are bubbled out of the unsorted section.
// stable
// space complexity O(1) aka in-place
// O(n²) time complexity in the average and worst cases
// O(n) time complexity in best case

CreateListAndSort(listSize: 10_000);
CreateListAndSort(listSize: 20_000);
CreateListAndSort(listSize: 30_000);
CreateListAndSort(listSize: 40_000);

void CreateListAndSort(int listSize)
{
    List<int> toSort = CreateList(listSize);
    Stopwatch sw = Stopwatch.StartNew();
    Sort(toSort);
    sw.Stop();
    VerifySorted(toSort);
    Console.WriteLine($"Sorted {listSize:N0} items in {sw.ElapsedMilliseconds}ms");
}

void Sort(List<int> input)
{
    var iterations = 0;
    bool swapped;
    do
    {
        swapped = false;
        for (int j = 0; j < input.Count-1-iterations; j++)
        {
            if (input[j] > input[j + 1])
            {
                swapped = true;
                (input[j + 1], input[j]) = (input[j], input[j + 1]);
            }
        }
        iterations++;
    } while (swapped);
}