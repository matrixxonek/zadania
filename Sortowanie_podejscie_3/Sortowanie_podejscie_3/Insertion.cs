using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Insertion<T> : Istrategy<T> 
{
    Stopwatch zegar = new Stopwatch();
    public List<T> DoAlgorithm<T>(List<T> data)
    {
        zegar.Start();
        int n = data.Count;
        int pom, j;
        for (int i = 1; i < n; i++)
        {
            //wstawienie elementu w odpowiednie miejsce
            pom = int.Parse(data[i]); //ten element będzie wstawiony w odpowiednie miejsce
            j = i - 1;

            //przesuwanie elementów większych od pom
            while (j >= 0 && data[j].CompareTo(pom) > 0)
            {
                data[j + 1] = data[j]; //przesuwanie elementów
                --j;
            }
            data[j + 1] = pom; //wstawienie pom w odpowiednie miejsce
        }
        return data;
        zegar.Stop();
        TimeSpan time = zegar.Elapsed;
        Console.WriteLine(time);
    }

}
