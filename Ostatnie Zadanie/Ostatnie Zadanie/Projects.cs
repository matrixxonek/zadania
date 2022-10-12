using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Projects
{
    void getData()
    {
        List<Atlassian.Jira.Project> lista = Login.connection.Projects.GetProjectsAsync().Result.ToList();
        foreach (Atlassian.Jira.Project project in lista)
        {
            Console.WriteLine("Id: " + project.Id + " Nazwa: " + project.Name + " Klucz: " + project.Key + " Kategoria: " + project.Category);
        }
    }
    public Projects()
    {
        getData();
    }
}
