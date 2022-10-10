using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using SharpBucket;
using SharpBucket.V2;
using SharpBucket.V2.EndPoints;
using SharpBucket.V2.Pocos;


public class Login
{
    public static GitHubClient client = new GitHubClient(new Octokit.ProductHeaderValue("my-app"));
    public SharpBucketV2 sharpBucket = new SharpBucketV2();
    public static Selection select = new Selection();
    public static List<Octokit.Issue> GitIssues;
    public static string repoName;

    public void LoginGit()
    {
        Console.WriteLine("Podaj token");
        string token = Console.ReadLine();
        Credentials tokenAuth = new Credentials(token);
        client.Credentials = tokenAuth;
        Console.WriteLine("Podaj nazwę repo");
        repoName = Console.ReadLine();
        GitIssues = client.Issue.GetAllForRepository(client.User.Current().Result.Login, repoName).Result.ToList();
    }
    public void LoginBucket()
    {
        string consumerKey;
        string consumerSecretKey;
        Console.WriteLine("Podaj klucz");
        consumerKey = Console.ReadLine();
        Console.WriteLine("Podaj sekreny klucz");
        consumerSecretKey = Console.ReadLine();
        sharpBucket.OAuth2ClientCredentials(consumerKey, consumerSecretKey);
        //sharpBucket.UserEndPoint().GetUser().
        //sharpBucket.RepositoriesEndPoint().RepositoryResource().
    }
    public void getSwitch()
    {
        switch (select.selection)
        {
            case "GitHub":
                LoginGit();
                break;
            case "Bitbucket":
                LoginBucket();
                break;
            default:
                Console.WriteLine("Wybrano nieistniejącą opcję");
                break;
        }
    }
    public Login()
    {
        getSwitch();
    }
}