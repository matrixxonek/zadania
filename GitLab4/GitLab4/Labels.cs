using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLabApiClient;
using GitLabApiClient.Models.MergeRequests.Requests;
using GitLabApiClient.Models.MergeRequests.Responses;

class Labels
{
    public void selectLabels()
    {
        Console.WriteLine("Co chcesz zrobic? wyswietl, modyfikuj, dodaj, usun");
        string whatToUse = Console.ReadLine();
        switch (whatToUse)
        {
            case "wyswietl":
                listLabels();
                break;
            case "modyfikuj":
                modifyLabels();
                break;
            case "dodaj":
                createLabels();
                break;
            case "usun":
                deleteLabels();
                break;
            default:
                Console.WriteLine("chyba cos ci sie pomylilo kolego");
                break;
        }
    }

    private void deleteLabels()
    {
        Console.WriteLine("Nie mozna usunac");
    }

    private void createLabels()
    {
        Console.WriteLine("Podaj nazwe");
        string name = Console.ReadLine();
        Console.WriteLine("Podaj descrption");
        string desc = Console.ReadLine();
        Login.client.MergeRequests.CreateAsync("group/project", new CreateMergeRequest("featureBranch", "master", "Merge request title")
        {
            Labels = new[] { name },
            Description = desc
        });
    }

    private void modifyLabels()
    {
        Console.WriteLine("Nie mozna modyfikowac");
    }

    private void listLabels()
    {
        Console.WriteLine("Nie mozna wyswietlic");
    }
}