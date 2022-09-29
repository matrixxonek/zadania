using System.Diagnostics.Tracing;

class Context<T>
{
    private Istrategy<T> _strategy;
    public Context() { }
    public Context(Istrategy<T> strategy)
    {
        this._strategy = strategy;
    }
    public void SetStrategy(Istrategy<T> strategy)
    {
        this._strategy = strategy;
    }
    public void DoSomeBusinessLogic(T list)
    {
        var result = this._strategy.DoAlgorithm(list);
        string resultStr = string.Empty;
        foreach (var element in result as List<T>)
        {
            resultStr += element + ", ";
        }
        Console.WriteLine(resultStr);
    }
}
public interface Istrategy<T>
{
    public T DoAlgorithm(T data);
}
class BubbleSort<T> : Istrategy<T>
{
    public T DoAlgorithm(T data)
    {
        T list = data;
        return list;
    }
}
class QuickSort<T> : Istrategy<T>
{
    public T DoAlgorithm(T data)
    {
        T list = data;
        return list;
    }
}

class Program 
{
    static void Main(string[] args)
    {
        List<string> wyrazy = new List<string>();
        wyrazy.Add("a");
        wyrazy.Add("b");
        Context<T> context = new Context<T>();
        context.SetStrategy(new BubbleSort<T>());
        context.DoSomeBusinessLogic(wyrazy);
    }
}


