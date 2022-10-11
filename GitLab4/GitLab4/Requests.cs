using GitLabApiClient.Models.Issues.Requests;
using GitLabApiClient.Models.MergeRequests.Requests;
using GitLabApiClient.Models.MergeRequests.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Requests
{
    IList<MergeRequest> requests;
    UpdateMergeRequest update;
    public CreateMergeRequest request;
    int id;
    public IList<MergeRequest> setMergeRequests()
    {
        return Login.client.MergeRequests.GetAsync(Login.id).Result;
    }
    public void showMergeRequests()
    {
        requests = setMergeRequests();
        foreach (MergeRequest request in requests)
            Console.WriteLine(request.Title);
    }
    void modifyRequest()
    {
        Console.WriteLine("Podaj id merge requesta");
        id = int.Parse(Console.ReadLine());
        Console.WriteLine("podaj tytol");
        Login.client.MergeRequests.UpdateAsync(Login.id, id, update).Result.Title = Console.ReadLine();
    }
    void addRequest()
    {
        Console.WriteLine("Podaj tytol requesta");
        string title = Console.ReadLine();
        Login.client.MergeRequests.CreateAsync(Login.id, new CreateMergeRequest("featureBranch", "master", title));
    }
    void deleteRequest()
    {
        Console.WriteLine("Podaj id requesta do usuniecia");
        int mergeid = int.Parse(Console.ReadLine());
        Login.client.MergeRequests.DeleteAsync(Login.id, mergeid);
    }
    public void selectRequest()
    {
        Console.WriteLine("Co chcesz zrobic? wyswietl, modyfikuj, dodaj, usun");
        string whatToUse = Console.ReadLine();
        switch (whatToUse)
        {
            case "wyswietl":
                showMergeRequests();
                break;
            case "modyfikuj":
                modifyRequest();
                break;
            case "dodaj":
                addRequest();
                break;
            case "usun":
                deleteRequest();
                break;
            default:
                Console.WriteLine("chyba cos ci sie pomylilo kolego");
                break;
        }
    }
    public Requests()
    {
        selectRequest();
    }
}