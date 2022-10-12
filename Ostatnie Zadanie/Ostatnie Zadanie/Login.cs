using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlassian.Jira;

class Login
{
    static string name;
    static string password;
    public static Jira connection;
    void login()
    {
        Console.WriteLine("Podaj nazwe uzytokwnika");
        name = Console.ReadLine();
        Console.WriteLine("Podaj haslo");
        password = Console.ReadLine();
        connection = Jira.CreateRestClient("https://matrixxon.atlassian.net/", name, password);
    }
    void getData()
    {
        Console.WriteLine("Co chcesz wyswietlic: users, fields, issues, comments, priorities, projects, statuses, groups, tasks");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "users":
                Users user = new Users();
                break;
            case "fields":
                Fields field = new Fields();
                break;
            case "issues":
                Issues issue = new Issues();
                break;
            case "comments":
                Comments comment = new Comments();
                break;
            case "priorities":
                Priorities priorities = new Priorities();
                break;
            case "projects":
                Projects project = new Projects();
                break;
            case "statuses":
                Statuses status = new Statuses();
                break;
            case "groups":
                Groups group = new Groups();
                break;
            case "tasks":
                Tasks task = new Tasks();
                break;
            default:
                Console.WriteLine("Bledna opcja");
                break;
        }
    }

    public Login()
    {
        login();
        getData();
    }
}
