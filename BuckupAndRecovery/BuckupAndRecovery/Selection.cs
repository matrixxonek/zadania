using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Selection
{
    public string selection;
    void select()
    {
        Console.WriteLine("Używasz GitHub czy Bitbucket?");
        selection = Console.ReadLine();
    }
    public Selection()
    {
        select();
    }
}
