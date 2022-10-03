using Octokit;
using System.Linq;

var client = new GitHubClient(new ProductHeaderValue("my-app"));
Console.WriteLine("Podaj Personal Access Token");
var token = Console.ReadLine();
var tokenAuth = new Credentials(token);
client.Credentials = tokenAuth;
var userInfo = await client.User.Current();
Console.WriteLine(userInfo.Login + userInfo.PublicRepos);
List<Repository> GetGithubRepository()
{
    return client.Repository.GetAllForCurrent().Result.ToList();
}
List<Repository> repos = GetGithubRepository();
foreach (var repo in repos)
    Console.WriteLine(repo.Name);



