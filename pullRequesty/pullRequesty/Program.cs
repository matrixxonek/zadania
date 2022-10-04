using Octokit;

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
        break;
        Gl();
    default:
        Console.WriteLine("Podano niepoprawa opcje");
        break;
}

void Gl()
{
    Console.WriteLine("Wybrano GL");
}

void Bit()
{
    Console.WriteLine("Wybrano BB");
}

async void Git()
{
    List<PullRequest> requests = new List<PullRequest>();
    var request = new PullRequestRequest();
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
    List<PullRequest> GetPullRequests(Repository repo)
    {
        return client.Repository.PullRequest.GetAllForRepository(userInfo.Login, repo.Name).Result.ToList();
    }
    List<Repository> repos = GetGithubRepository();
    List<PullRequest> pulls = client.PullRequest.GetAllForRepository(repos[1].Id).Result.ToList();

    //Console.WriteLine(client.Repository.PullRequest.GetAllForRepository("Daruyami", "praktyki-xopero").Result);
    var abc = client.Repository.PullRequest.GetAllForRepository("Daruyami", "praktyki-xopero").Result;
    foreach (var a in abc)
        Console.WriteLine(a.Title);
    /*foreach (var repo in repos)
    {
        requests = GetPullRequests(repo);
        Console.WriteLine(requests);
    }
}

