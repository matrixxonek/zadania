using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

class Fields
{
    string key;
    void getData()
    {
        Console.WriteLine("Podaj klucz produktu");
        key = Console.ReadLine();
        List<Atlassian.Jira.CustomField> lista = Login.connection.Fields.GetCustomFieldsForProjectAsync(key).Result.ToList();
        foreach (Atlassian.Jira.CustomField field in lista)
        {
            Console.WriteLine("Id: " + field.Id + " Nazwa: " + field.Name);
        }
    }

    public Fields()
    {
        getData();
    }
}