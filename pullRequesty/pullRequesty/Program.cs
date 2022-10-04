using GitLabApiClient;
using GitLabApiClient.Models.MergeRequests.Responses;
using Octokit;
using System.Net;
using System;
using SharpBucket.V2;
using SharpBucket;

Console.WriteLine("Wybierz Swoje repo: GitHub, Bitbucket, GitLab");
string baza = Console.ReadLine();
switch (baza)
{
    case "GitHub":
        Git();
        break;
    case "Bitbucket":
        Bit();
        break;
    case "GitLab":
        GitLab();
        break;
    default:
        Console.WriteLine("Podano niepoprawa opcje");
        break;
}

async void GitLab()
{
    Console.WriteLine("Podaj personal access token");
    string token = Console.ReadLine();
    var client = new GitLabClient("https://gitlab.com", token);
    Console.WriteLine("Podaj ID swojego repo");
    string id = Console.ReadLine();
    var requests = client.MergeRequests.GetAsync(id).Result;
    foreach(var request in requests)
        Console.WriteLine(request.Title);
}

void Bit()
{
    Console.WriteLine("Wybrano BB");
    var sharpBucket = new SharpBucketV2();
    Console.WriteLine("podaj consumer key");
    var consumerKey = Console.ReadLine();
    Console.WriteLine("podaj consumer secret key");
    var consumerSecretKey = Console.ReadLine();
    sharpBucket.OAuth2ClientCredentials(consumerKey,consumerSecretKey);
   /* Console.WriteLine("Podaj login");
    var username = Console.ReadLine();
    Console.WriteLine("Podaj haslo");
    var password = Console.ReadLine()*/;
    //sharpBucket.BasicAuthentication(username, password);
    Console.WriteLine("podaj nazwe użytkownika");
    var name = Console.ReadLine();
    var userEndPoint = sharpBucket.UsersEndPoint(name);
    var profil = userEndPoint.GetProfile();
    Console.WriteLine("podaj nazwe repo");
    var repoName = Console.ReadLine();
    var requests = sharpBucket.RepositoriesEndPoint().RepositoryResource(name, repoName).PullRequestsResource().EnumeratePullRequests().ToList();
    foreach (var item in requests)
    {
        Console.WriteLine(item.title);
    }
}

async void Git()
{
    Console.WriteLine("Wybrano Gita");
    var client = new GitHubClient(new ProductHeaderValue("my-app"));
    Console.WriteLine("Podaj Personal Access Token");
    var token = Console.ReadLine();
    var tokenAuth = new Credentials(token);
    client.Credentials = tokenAuth;
    var userInfo = client.User.Current().Result;
    Console.WriteLine("wczytano");
    List<Repository> GetGithubRepository()
    {
        return client.Repository.GetAllForCurrent().Result.ToList();
    }
    List<Repository> repos = GetGithubRepository();
    Console.WriteLine("Lista dostępnych repozytoriów");
    foreach (var repo in repos)
        Console.WriteLine(repo.Name);
    Console.WriteLine("Podaj nazwe repo");
    string repoName = Console.ReadLine();
    var pullRequests = client.Repository.PullRequest.GetAllForRepository(userInfo.Login, repoName).Result;
    foreach (var request in pullRequests)
        Console.WriteLine(request.Title);
}

