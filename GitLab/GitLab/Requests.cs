using GitLabApiClient.Models.MergeRequests.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Requests
{
    public string id;
    IList<MergeRequest> requests;
    public void setRepo()
    {
        Console.WriteLine("Podaj id swojego repo");
        id = Console.ReadLine();
    }
    public IList<MergeRequest> setMergeRequests()
    {
        return Login.client.MergeRequests.GetAsync(id).Result;
    }
    public void showMergeRequests()
    {
        requests = setMergeRequests();
        foreach (MergeRequest request in requests)
            Console.WriteLine(request.Title);
    }
}