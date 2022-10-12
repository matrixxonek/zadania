using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Priorities
{
    void getData()
    {
        List<Atlassian.Jira.IssuePriority> lista = Login.connection.Priorities.GetPrioritiesAsync().Result.ToList();
        foreach (Atlassian.Jira.IssuePriority item in lista)
        {
            Console.WriteLine("Id: " + item.Id + " Nazwa: " + item.Name + " Opis: " + item.Description);
        }
    }
    public Priorities()
    {
        getData();
    }
}
