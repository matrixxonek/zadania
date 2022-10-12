using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tasks
{
    void getData()
    {
        Console.WriteLine("Podaj klucz issue");
        string key = Console.ReadLine();
        List<Atlassian.Jira.Issue> lista = Login.connection.Issues.GetSubTasksAsync(key).Result.ToList();
        foreach (Atlassian.Jira.Issue issue in lista)
        {
            Console.WriteLine("Identyfikator " + issue.JiraIdentifier + " Reporter: " + issue.Reporter + " Tworca: " + issue.Created + " Opis: " + issue.Description + " Srodowisko: " + issue.Environment + " Priorytet: " + issue.Priority + " Status: " + issue.Status);
        }
    }
    public Tasks()
    {
        getData();
    }
}
