using System.Diagnostics;

class Program
{
    private static Stopwatch _stopwatch = new Stopwatch();
    private static string _inputFile = "";
    private static string _algorithmType = "";
    private static bool _sortingNumbers = true;

    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.Error.WriteLine("Too few arguments!");
            Console.Error.WriteLine("Usage: SortingStrategy <input-file> <algorithm>");
            Console.Error.WriteLine("Available algorithms:");
            Console.Error.WriteLine("- bogosort");
            Console.Error.WriteLine("- bubblesort");
            Console.Error.WriteLine("- quicksort");
            Environment.Exit(1);
        }
        else
        {
            _inputFile = args[0];
            _algorithmType = args[1];
        }

        var inputLines = File.ReadAllLines(_inputFile);

        // Cheking if we're sorting only numbers
        foreach (string line in inputLines)
        {
            if (!Int32.TryParse(line, out _))
            {
                _sortingNumbers = false;
                break;
            }
        }

        if (_sortingNumbers)
        {
            int[] numbers = new int[inputLines.Length];

            for (int i = 0; i < inputLines.Length; i++)
                numbers[i] = Int32.Parse(inputLines[i]);

            BeginSort<int>(numbers);
        }
        else
        {
            BeginSort<string>(inputLines);
        }
    }

    public static void BeginSort<T>(T[] input) where T : IComparable
    {
        SortingContext<T> context = new SortingContext<T>();

        switch (_algorithmType)
        {
            case "bogosort":
                {
                    context.SetAlgorithm(new BogoSort<T>());
                    break;
                }
            case "bubblesort":
                {
                    context.SetAlgorithm(new BubbleSort<T>());
                    break;
                }
            case "quicksort":
                {
                    context.SetAlgorithm(new QuickSort<T>());
                    break;
                }
            default:
                {
                    Console.Error.WriteLine("Unsupported alghoritm!");
                    Environment.Exit(1);
                    break;
                }
        }

        _stopwatch.Start();
        T[] sorted = context.Execute(input);
        _stopwatch.Stop();

        Console.WriteLine(
            $"Sorting {sorted.Length} elements " +
            $"using {_algorithmType} took {_stopwatch.ElapsedMilliseconds} ms"
        );
    }
}
public interface ISortingAlgorithm<T> where T : IComparable
{
    /// <summary>
    /// Sorts given array
    /// </summary>
    /// <returns>Sorted array</returns>
    public T[] Sort(T[] input);
}
public class SortingContext<T> where T : IComparable
{
    private ISortingAlgorithm<T> Algorithm = new BogoSort<T>(); // default

    public void SetAlgorithm(ISortingAlgorithm<T> algorithm)
    {
        this.Algorithm = algorithm;
    }

    public ISortingAlgorithm<T> GetAlgorithm()
    {
        return Algorithm;
    }

    public T[] Execute(T[] input)
    {
        return Algorithm.Sort(input);
    }
}
public class BogoSort<T> : ISortingAlgorithm<T> where T : IComparable
{
    public T[] Sort(T[] input)
    {
        T[] sorted = new T[input.Length];
        Array.Copy(input, sorted, input.Length);

        while (!IsSorted(sorted))
            Suffle(sorted);

        return sorted;
    }

    private void Suffle<U>(U[] input)
    {
        Random rand = new Random();

        for (int i = 0; i < input.Length; i++)
            Swap(ref input[i], ref input[rand.Next(0, input.Length)]);
    }

    private void Swap<U>(ref U a, ref U b) => (a, b) = (b, a);

    private bool IsSorted<U>(U[] input) where U : IComparable
    {
        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i].CompareTo(input[i + 1]) > 0)
                return false;
        }
        return true;
    }
}
public class BubbleSort<T> : ISortingAlgorithm<T> where T : IComparable
{
    public T[] Sort(T[] input)
    {
        T[] sorted = new T[input.Length];
        Array.Copy(input, sorted, input.Length);

        for (int i = 0; i < sorted.Length - 1; i++)
        {
            for (int j = 0; j < sorted.Length - i - 1; j++)
            {
                if (sorted[j].CompareTo(sorted[j + 1]) > 0)
                {
                    // Swap the elements
                    (sorted[j], sorted[j + 1]) = (sorted[j + 1], sorted[j]);
                }
            }
        }

        return sorted;
    }
}
public class QuickSort<T> : ISortingAlgorithm<T> where T : IComparable
{
    public T[] Sort(T[] input)
    {
        T[] sorted = new T[input.Length];
        Array.Copy(input, sorted, input.Length);

        QuickSortImpl(sorted, 0, sorted.Length - 1);

        return sorted;
    }

    private void Swap<U>(ref U a, ref U b) => (a, b) = (b, a);

    private int Partition(T[] input, int low, int high)
    {
        T pivot = input[high];

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (input[j].CompareTo(pivot) < 0)
            {
                i++;
                Swap(ref input[i], ref input[j]);
            }
        }

        Swap(ref input[i + 1], ref input[high]);
        return i + 1;
    }

    private void QuickSortImpl(T[] input, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(input, low, high);

            QuickSortImpl(input, low, pi - 1);
            QuickSortImpl(input, pi + 1, high);
        }
    }
}