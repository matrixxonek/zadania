using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using SQLitePCL;
using System.Security.Cryptography;
using SharpBucket;
using System.Xml.Linq;

public class DBConection 
{
    public SQLiteConnection db;
    List<Issues> myIssues;
    string option;
    public void setConnection()
    {
        SQLiteConnection sqlite_conn;
         try
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "test1.db");
            var options = new SQLiteConnectionString(databasePath, SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite, false);
            db = new SQLiteConnection(options);
            db.CreateTable<Issues>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public DBConection()
    {
        setConnection();
        selectProgram();
    }
    public List<Issues> getIssues()
    {
        return db.Query<Issues>("SELECT * FROM Issues");
    }
    public void selectProgram()
    {
        Console.WriteLine("wybierz program: Backup, Recovery");
        option = Console.ReadLine();
        switch (option)
        {
            case "Backup":
                DoBackup();
                break;
            case "Recovery":
                Recovery();
                break;
            default:
                Console.WriteLine("Nie wybrano poprawnej opcji.");
                break;
        }
    }
    public void Recovery()
    {
        myIssues = getIssues();
        switch (Login.select.selection)
        {
            case "GitHub":
                foreach (Issues issue in myIssues)
                {
                    Octokit.NewIssue issue1 = new Octokit.NewIssue(issue.Title);
                    issue1.Body = issue.Body;
                    Login.client.Issue.Create(Login.client.User.Current().Result.Login, Login.repoName, issue1);
                }
                break;
            case "Bitbucket":
                foreach (Issues issue in myIssues)
                {
                    Console.WriteLine("CreateIssue");
                    Octokit.NewIssue issue1 = new Octokit.NewIssue(issue.Title);
                    issue1.Body = issue.Body;
                    Login.client.Issue.Create(Login.client.User.Current().Result.Login, Login.repoName, issue1);
                }
                break;
            default:
                Console.WriteLine("Cos poszlo nie tak przepraszamy");
                break;
        }
    }
    public void Backup(int id, string title, int comments, string body)
    {
        var issue = new Issues()
        {
            Id = id,
            Title = title,
            Comment = comments,
            Body = body
        };
        db.Insert(issue);
    }
    public void DoBackup()
    {
        switch (Login.select.selection)
        {
            case "GitHub":
                foreach(var issue in Login.GitIssues)
                {
                    Backup(issue.Id, issue.Title, issue.Comments, issue.Body);
                }
                break;
            case "Bitbucket":
                foreach (var issue in Login.BitIssues)
                {
                    Backup(issue.id, issue.title, 0, issue.content);
                }
                break;
            default:
                Console.WriteLine("Cos poszlo nie tak przepraszamy");
                break;
        }
    }
}
