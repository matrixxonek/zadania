using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Octokit;

public class LoginData{
    public string token;
    public string repoName;
    public string[] loginData = new string[2];

    public void getDataFromFile()
    {
        StreamReader reader = new StreamReader(@"C:\Users\Admin\source\repos\zadania\Issues\config.txt");
        int i = 0;
        foreach (string line in System.IO.File.ReadLines(@"C:\Users\Admin\source\repos\zadania\Issues\config.txt"))
        {
            loginData[i] = line;
            i++;
        }
        token = loginData[0];
        repoName = loginData[1];
        Console.WriteLine(repoName);
    }
    public void getDataFromUser()
    {
        Console.WriteLine("Podaj token");
        token = Console.ReadLine();
        Console.WriteLine("Nazwe repo");
        repoName = Console.ReadLine();
    }
    public LoginData()
    {
        try
        {
            getDataFromFile();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            getDataFromUser();
        }
    }
}