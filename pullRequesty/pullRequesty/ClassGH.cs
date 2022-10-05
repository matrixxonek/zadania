using Octokit;
using SharpBucket.V2.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ClassGH
{
    static GitHubClient client = new GitHubClient(new ProductHeaderValue("my-app"));
    public string token;
    public Credentials tokenAuth;
    List<Octokit.Repository> repos;
    static string repoName;
    static Octokit.User userInfo;
    public IReadOnlyList<Octokit.PullRequest> pullRequests;
    public void setToken()
    {
        Console.WriteLine("Podaj Personal Access Token");
        token = Console.ReadLine();
        tokenAuth = new Credentials(token);
        client.Credentials = tokenAuth;
        userInfo = client.User.Current().Result;
    }
    List<Octokit.Repository> GetGithubRepository()
    {
        return client.Repository.GetAllForCurrent().Result.ToList();
    }
    public void repoList()
    {
        repos = GetGithubRepository();
        Console.WriteLine("Lista dostępnych repozytoriów");
        foreach (var repo in repos)
            Console.WriteLine(repo.Name);
        Console.WriteLine("Podaj nazwe repo");
        repoName = Console.ReadLine();
    }
    public IReadOnlyList<Octokit.PullRequest> setPullRequest()
    {
        return client.Repository.PullRequest.GetAllForRepository(userInfo.Login, repoName).Result;
    }
    public void showPullRequest()
    {
        pullRequests = setPullRequest();
        foreach (var repo in pullRequests)
            Console.WriteLine(repo.Title);
    }
     
    public ClassGH()
    {
        setToken();
        repoList();
        showPullRequest();
    }
}