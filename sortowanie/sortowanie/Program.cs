using System.IO;

Console.WriteLine("Sortowanie danych z pliku");
string folder = "C:\\Users\\Admin\\Source\\Repos\\zadania\\sortowanie";
string nazwaPliku;
List<string> wyrazy = new List<string> ();
List <int> liczby = new List<int> ();
Console.WriteLine("Przosze podac nazwe pliku z rozszerzeniem.");
nazwaPliku = Console.ReadLine();
StreamReader reader = new StreamReader(folder + "\\" + nazwaPliku);
bool czyLiczba;
static ISortingStrategy<T> GetSortingOption(SortType objectToSort)
{
    ISortingStrategy<T> sortingStrategy = null;
    // w zależności od przekazanych danych użyjemy innego sortowania
    // zmiana algorytmu odbywa się w trakcie wykonywania programu

    switch (objectToSort)
    {

        case SortType.insertion:
            sortingStrategy = new InsertionSort<T>();
            break;
        case SortType.bubblesort:
            sortingStrategy = new BubbleSort<T>();
            break;
        case SortType.quicksort:
            sortingStrategy = new QuickSort<T>();
            break;
        default:
            break;
    }
    return sortingStrategy;
}
while (!reader.EndOfStream)
{
    czyLiczba = true;
    string linia = reader.ReadLine();
    for(int i = 0; i < linia.Length; i++)
    {
        //Console.WriteLine(linia[i]);
        if (!(linia[i] == '0' || linia[i] == '1' || linia[i] == '2' || linia[i] == '3' || linia[i] == '4' || linia[i] == '5' || linia[i] == '6' || linia[i] == '7' || linia[i] == '8' || linia[i] == '9'))
        {
            czyLiczba = false;
        }
    }
    if (czyLiczba == true)
        liczby.Add(int.Parse(linia));
    else
        wyrazy.Add(linia);
}
reader.Close();
Console.WriteLine("Podaj typ sortowania: bubblesort, quicksort, insertion");
string typSortu = Console.ReadLine();
//--------------------------------------------------------------------------------------------
ISortingStrategy<T> sortingStrategy = null;
if (typSortu == "bubblesort")
    sortingStrategy = GetSortingOption(SortType.bubblesort);
else if (typSortu == "quicksort")
    sortingStrategy = GetSortingOption(SortType.quicksort);
else
    sortingStrategy = GetSortingOption(SortType.insertion);
sortingStrategy.Sort(liczby);
sortingStrategy.Sort(wyrazy);

interface ISortingStrategy<T> where T : IComparable
{
    void Sort<T>(List<T> dataToSort);
}
class QuickSort<T> : ISortingStrategy<T> where T : IComparable
{
    public void Sort<T>(List<T> dataToSort)
    {
        Console.WriteLine("szybkie sortowanie");
    }
}
class BubbleSort<T> : ISortingStrategy<T> where T : IComparable
{
    public void Sort<T>(List<T> dataToSort)
    {
        Console.WriteLine("sortowanie babelkowe");
        T temp ;

        for (int write = 0; write < dataToSort.Count; write++)
        {
            for (int sort = 0; sort < dataToSort.Count - 1; sort++)
            {
                if (dataToSort[sort] > dataToSort[sort + 1])
                {
                    temp = dataToSort[sort + 1];
                    dataToSort[sort + 1] = dataToSort[sort];
                    dataToSort[sort] = temp;
                }
            }
        }
    }
}
class InsertionSort<T> : ISortingStrategy<T> where T : IComparable
{
    public void Sort<T>(List<T> dataToSort)
    {
        Console.WriteLine("Sortowanie przez wstawienie");
    }
}
public enum SortType
{
    bubblesort,
    quicksort,
    insertion
}
