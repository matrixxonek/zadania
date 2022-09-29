using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Insertion<T> : Istrategy<T>
{
    public List<T> DoAlgorithm(List<T> data)
    {
        List<T> list = data;
        return list;
    }
}
