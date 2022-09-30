using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class QuickSort<T> : Istrategy<T> 
{
    Stopwatch zegar = new Stopwatch();
    public List<T> DoAlgorithm<T>(List<T> data)
    {
        zegar.Start();
            var i = 0;
            var j = data.Count;
            var pivot = data[0];
            while (i <= j)
            {
                while (data[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (data[j].CompareTo(pivot) > 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            }

            if (0 < j)
                DoAlgorithm(data);
            if (i < data.Count)
                DoAlgorithm(data);
        
        return data;
        zegar.Stop();
        TimeSpan time = zegar.Elapsed;
        Console.WriteLine(time);
    }
}
