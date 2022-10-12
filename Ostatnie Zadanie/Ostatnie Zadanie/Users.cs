using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

class Users
{
    void getData()
    {
        Console.WriteLine("Podaj zapytanie");
        string query = Console.ReadLine();
        List<Atlassian.Jira.JiraUser> lista = Login.connection.Users.SearchUsersAsync(query).Result.ToList();
        foreach (Atlassian.Jira.JiraUser user in lista)
        {
            Console.WriteLine("nazwa: " + user.Username + " email: " + user.Email + " klucz: " + user.Key);
        }
    }
    public Users()
    {
        getData();
    }
}