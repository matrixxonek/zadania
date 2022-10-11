using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLabApiClient;
using GitLabApiClient.Models.Issues.Requests;
using GitLabApiClient.Models.MergeRequests.Responses;

class Issues
{
    IList<GitLabApiClient.Models.Issues.Responses.Issue> issues;
    CreateIssueRequest request;
    UpdateIssueRequest urequest;
    public void selectIssues()
    {
        Console.WriteLine("Co chcesz zrobic? wyswietl, modyfikuj, dodaj, usun");
        string whatToUse = Console.ReadLine();
        switch (whatToUse)
        {
            case "wyswietl":
                listIssues();
                break;
            case "modyfikuj":
                modifyIssues();
                break;
            case "dodaj":
                createIssues();
                break;
            case "usun":
                deleteIssues();
                break;
            default:
                Console.WriteLine("chyba cos ci sie pomylilo kolego");
                break;
        }
    }

    private void listIssues()
    {
        issues = issues = Login.client.Issues.GetAllAsync().GetAwaiter().GetResult();
        foreach (var issue in issues)
        {
            Console.WriteLine(issue);
        }
    }

    private void deleteIssues()
    {
        //Login.client.Issues.DeleteNoteAsync
    }

    private void createIssues()
    {
        Console.WriteLine("Podaj tytol issue");
        string title = Console.ReadLine();
        Login.client.Issues.CreateAsync(Login.id, new CreateIssueRequest(title));
    }

    private void modifyIssues()
    {
        Console.WriteLine("Podaj id issue do usuniecia");
        int issueId = int.Parse(Console.ReadLine());
        Login.client.Issues.UpdateAsync(Login.id, issueId, urequest);
    }
}
