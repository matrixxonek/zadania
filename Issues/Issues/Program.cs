using Octokit;

static class Program
{
    public static GitHubClient client = new GitHubClient(new Octokit.ProductHeaderValue("my-app"));
    public static LoginData login = new LoginData();
    public static Credentials tokenAuth = new Credentials(login.token);
    public static string userName;
    public static IReadOnlyList<Issue> newIssues;
    public static IReadOnlyList<Issue> startIssues;
    public static IReadOnlyList<Issue> differentIssues;
    public static User user;
    public static System.Timers.Timer timer;
    private static System.Timers.Timer aTimer;
    static public void Main(String[] args)
    {
        client.Credentials = tokenAuth;
        user = client.User.Current().Result;
        userName = user.Login;
        startIssues = getIssues();
        aTimer = new System.Timers.Timer();
        setTime();
    }
    static public IReadOnlyList<Issue> getIssues()
    {
        return client.Issue.GetAllForRepository(userName, login.repoName).Result;
    }
    static public void setNewIssue()
    {
        newIssues = getIssues();
    }
    static public IReadOnlyList<Issue> compareIssue()
    {
        return newIssues.Except(startIssues).Union(startIssues.Except(newIssues)).ToList();
    }
    static public void setDifferentIssues()
    {
        differentIssues = compareIssue();
        startIssues = newIssues;
    }
    static void setTime()
    {
        Console.WriteLine("Podaj czas w sekundach");
        int i = int.Parse(Console.ReadLine());
        aTimer.Interval = i * 1000;
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
        Console.WriteLine("Press the Enter key to exit the program at any time... ");
        Console.ReadLine();
    }
    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        //sendMessage();
    }
}
