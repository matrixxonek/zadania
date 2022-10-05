using GitLabApiClient;
using GitLabApiClient.Models.MergeRequests.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ClassGL
{
    public string token;
    public GitLabClient client;
    public string id;
    IList<MergeRequest> requests;
    public void setToken()
    {
        Console.WriteLine("Podaj token weryfikacji");
        token = Console.ReadLine();
    }
    public void createClient()
    {
        client = new GitLabClient("https://gitlab.com", token);
    }
    public void setRepo()
    {
        Console.WriteLine("Podaj id swojego repo");
        id = Console.ReadLine();
    }
    public IList<MergeRequest> setMergeRequests()
    {
        return client.MergeRequests.GetAsync(id).Result;
    }
    public void showMergeRequests()
    {
        requests = setMergeRequests();
        foreach (MergeRequest request in requests)
            Console.WriteLine(request.Title);
    }
    public ClassGL()
    {
        setToken();
        createClient();
        setRepo();
        showMergeRequests();
    }
}
