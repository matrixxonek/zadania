using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
public class Program
{
    static string typSortu;
    static Context<List<string>> context;
    static Context<List<int>> contextInt;
    static void Main(string[] args)
    {
        Console.WriteLine("Sortowanie danych z pliku");
        string folder = "C:\\Users\\Admin\\Source\\Repos\\zadania\\sortowanie";
        string nazwaPliku;
        List<string> wyrazy = new List<string>();
        List<int> liczby = new List<int>();
        Console.WriteLine("Przosze podac nazwe pliku z rozszerzeniem.");
        nazwaPliku = Console.ReadLine();
        StreamReader reader = new StreamReader(folder + "\\" + nazwaPliku);
        bool czyLiczba;
        while (!reader.EndOfStream)
        {
            czyLiczba = true;
            string linia = reader.ReadLine();
            for (int i = 0; i < linia.Length; i++)
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
        typSortu = Console.ReadLine();
        

        context = new Context<List<string>>();
        //context.DoSomeBusinessLogic(wyrazy);
        contextInt = new Context<List<int>>();
        SetContextType();
        context.DoSomeBusinessLogic(wyrazy);
        contextInt.DoSomeBusinessLogic(liczby);

        
    }
    public static void SetContextType() 
    {
        switch (typSortu)
        {
            case "bubblesort":
                Console.WriteLine("Wybrano bubblesort");
                context.SetStrategy(new BubbleSort<List<string>>());
                contextInt.SetStrategy(new BubbleSort<List<int>>());
                break;
            case "quicksort":
                Console.WriteLine("Wybrano quicksort");
                context.SetStrategy(new QuickSort<List<string>>());
                contextInt.SetStrategy(new QuickSort<List<int>>());
                break;
            case "insertion":
                Console.WriteLine("Wybrano insertion");
                context.SetStrategy(new Insertion<List<string>>());
                contextInt.SetStrategy(new Insertion<List<int>>());
                break;
            default:
                Console.WriteLine("Wpisano niepoprawna opcje");
                break;
        }
    }
}
