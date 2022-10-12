using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class Groups
{
    void getData()
    {
        Console.WriteLine("Podaj nazwe grupy");
        string name = Console.ReadLine();
        List<Atlassian.Jira.JiraUser> lista = Login.connection.Groups.GetUsersAsync(name).Result.ToList();
        foreach (Atlassian.Jira.JiraUser user in lista)
        {
            Console.WriteLine("Nazwa: " + user.Username + " Email: " + user.Email + " Klucz: " + user.Key);
        }
    }
    public Groups()
    {
        getData();
    }
}
