using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Select
{
    void whatToDo()
    {
        Console.WriteLine("Na czym chcesz dzialac? branches, issues, requests, labels");
        string whatToDo = Console.ReadLine();

        switch (whatToDo)
        {
            case "branches":
                Branches branches = new Branches();
                break;
            case "issues":

                break;
            case "requests":
                Requests request = new Requests();
                break;
            case "labels":

                break;
            default:
                Console.WriteLine("chyba cos ci sie pomylilo kolego");
                break;
        }
    }
    public Select()
    {
        whatToDo();
    }
}
