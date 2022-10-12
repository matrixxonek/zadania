using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Issues
{
    void getData()
    {
        List<System.Collections.Generic.KeyValuePair<string, Atlassian.Jira.Issue>> lista = Login.connection.Issues.GetIssuesAsync().Result.ToList();
        foreach(var issue in lista)
        {
            Console.WriteLine("Wartosc: " + issue.Value + " Klucz: " + issue.Key);
        }
    }
    public Issues()
    {
        getData();
    }
}