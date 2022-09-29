using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface Istrategy<T>
{
    public List<T> DoAlgorithm(List<T> data);
}
