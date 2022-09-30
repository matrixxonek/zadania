using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BubbleSort<T> : Istrategy<T>
{
    Stopwatch zegar = new Stopwatch();
    public List<T> DoAlgorithm<T>(List<T> data)
    {
        zegar.Start();
        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < data.Count; j++)
            {
                if (data[j].CompareTo(data[j + 1]) > 0)
                {
                    var szklanka = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = szklanka;
                    //SwapValues<T>(list, list[j], list[j + 1]);
                }
            }
        }
        return data;
        zegar.Stop();
        TimeSpan time = zegar.Elapsed;
        Console.WriteLine(time);
    }
}


