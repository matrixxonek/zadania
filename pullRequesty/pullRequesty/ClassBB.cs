using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBucket.V2;
using SharpBucket;
using SharpBucket.V2.EndPoints;
using SharpBucket.V2.Pocos;

class ClassBB
{
    public SharpBucketV2 sharpBucket;
    public string consumerKey;
    public string consumerSecretKey;
    public string name;
    public UsersEndpoint endpoint;
    public User profil;
    public string repoName;
    public List<PullRequest> pullRequests;
    public void setSharpBucket()
    {
        sharpBucket = new SharpBucketV2();
    }
    public void setKeys()
    {
        Console.WriteLine("Podaj consumer key");
        consumerKey = Console.ReadLine();
        Console.WriteLine("Podaj consumer secret key");
        consumerSecretKey = Console.ReadLine();
    }
    public void login()
    {
        sharpBucket.OAuth2ClientCredentials(consumerKey, consumerSecretKey);
    }
    public void setName()
    {
        Console.WriteLine("Podaj nazwe uzytkownika");
        name = Console.ReadLine();
    }
    public void setEndPoint()
    {
        endpoint = sharpBucket.UsersEndPoint(name);
    }
    public void setProfil()
    {
        profil = endpoint.GetProfile();
    }public void setRepo()
    {
        Console.WriteLine("Podaj nazwe repo");
        repoName = Console.ReadLine();
    }
    public List<PullRequest> setRequests()
    {
        return sharpBucket.RepositoriesEndPoint().RepositoryResource(name, repoName).PullRequestsResource().EnumeratePullRequests().ToList();
    }
    public void showRequests()
    {
        pullRequests = setRequests();
        foreach (PullRequest pullRequest in pullRequests)
            Console.WriteLine(pullRequest.title);
    }
    public ClassBB()
    {
        setSharpBucket();
        setKeys();
        login();
        setName();
        setProfil();
        setRepo();
        showRequests();
    }
}