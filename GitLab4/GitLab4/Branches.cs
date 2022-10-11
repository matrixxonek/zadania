using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLabApiClient;
using GitLabApiClient.Models.Branches.Requests;
using GitLabApiClient.Models.MergeRequests.Responses;

class Branches
{
    public string name;
    CreateBranchRequest request;
    void listBranches()
    {
        Console.WriteLine(Login.client.Branches.GetAsync(Login.id, name).Result);
    }
    void deleteBranches()
    {
        Login.client.Branches.DeleteBranch(Login.id, name);
    }
    void getName()
    {
        Console.WriteLine("Podaj nazwe brancha");
        name = Console.ReadLine();
    }
    void createBranches()
    {
        Login.client.Branches.CreateAsync(Login.id, request);
    }
    public void selectBranches()
    {
        Console.WriteLine("Co chcesz zrobic? wyswietl, modyfikuj, dodaj, usun");
        string whatToUse = Console.ReadLine();
        switch (whatToUse)
        {
            case "wyswietl":
                listBranches();
                break;
            case "modyfikuj":
                Console.WriteLine("Nie mozna zmodyfikowac");
                break;
            case "dodaj":
                createBranches();
                break;
            case "usun":
                deleteBranches();
                break;
            default:
                Console.WriteLine("chyba cos ci sie pomylilo kolego");
                break;
        }
    }
    public Branches()
    {
        selectBranches();
    }
}
