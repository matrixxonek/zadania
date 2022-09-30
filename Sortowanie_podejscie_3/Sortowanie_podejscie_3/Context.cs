using System.Diagnostics.Tracing;

public class Context<T> 
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
    public void DoSomeBusinessLogic<T>(List<T> list)
    {
        var result = this._strategy.DoAlgorithm(list);
        string resultStr = string.Empty;
        Console.WriteLine(result);
        Console.ReadKey();
        foreach (var element in result)
        {
            resultStr += element + ", ";
        }
        
        Console.WriteLine(resultStr);
    }
}


