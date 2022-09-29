using System.Diagnostics.Tracing;

class Context
{
    private Istrategy _strategy;
    public Context() { }
    public Context(Istrategy strategy)
    {
        this._strategy = strategy;
    }
    public void SetStrategy(Istrategy strategy)
    {
        this._strategy = strategy;
    }
    public void DoSomeBusinessLogic()
    {
        var result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c"});
        string resultStr = string.Empty;
        foreach (var element in result as List<string>)
        {
            resultStr += element + ", ";
        }
        Console.WriteLine(resultStr);
    }
}
public interface Istrategy
{
    object DoAlgorithm(object data);
}
class BubbleSort : Istrategy
{
    public object DoAlgorithm(object data)
    {
        var list = data as List<string>;
        list.Sort();
        return list;
    }
}
class QuickSort : Istrategy
{
    public object DoAlgorithm(object data)
    {
        var list = data as List<string>;
        list.Sort();
        return list;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var context = new Context();
        context.SetStrategy(new BubbleSort());
        context.DoSomeBusinessLogic();
    }
}


