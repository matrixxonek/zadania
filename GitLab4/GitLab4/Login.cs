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
    public static string id;
    public static GitLabClient client;
    void setToken()
    {
        Console.WriteLine("Podaj token weryfikacji");
        token = Console.ReadLine();
    }
    public void createClient()
    {
        try {
            client = new GitLabClient("https://gitlab.com", token);
        } catch (Exception ex) {
            Console.WriteLine(ex);
        }
    }
    public void setRepo()
    {
        Console.WriteLine("Podaj id swojego repo");
        id = Console.ReadLine();
    }
    public Login()
    {
        setToken();
        createClient();
        setRepo();
    }
}