using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Statuses
{
    void getData()
    {
        List<Atlassian.Jira.IssueStatus> lista = Login.connection.Statuses.GetStatusesAsync().Result.ToList();
        foreach (Atlassian.Jira.IssueStatus status in lista)
        {
            Console.WriteLine("Id: " + status.Id + " Nazwa: " + status.Name + " Opis: " + status.Description);
        }
    }
    public Statuses()
    {
        getData();
    }
}
