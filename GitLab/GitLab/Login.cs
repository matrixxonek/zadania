using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLabApiClient;
using GitLabApiClient.Models.MergeRequests.Responses;
class Login
{
    string token;
    public static GitLabClient client;
    IList<MergeRequest> requests;
    void setToken()
    {
        Console.WriteLine("Podaj token weryfikacji");
        token = Console.ReadLine();
    }
    public void createClient()
    {
        client = new GitLabClient("https://gitlab.com", token);
    }
    public Login()
    {
        setToken();
        createClient();
    }
}