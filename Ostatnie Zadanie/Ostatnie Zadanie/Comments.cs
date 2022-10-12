using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Comments
{
    void getData()
    {
        Console.WriteLine("Podaj klucz issue");
        string key = Console.ReadLine();
        List<Atlassian.Jira.Comment> lista = Login.connection.Issues.GetCommentsAsync(key).Result.ToList();
        foreach (Atlassian.Jira.Comment comment in lista)
        {
            Console.WriteLine("Autor: " + comment.Author + " Poziom: " + comment.RoleLevel + " Zawartosc: " + comment.Body);
        }
    }
    public Comments()
    {
        getData();
    }
}