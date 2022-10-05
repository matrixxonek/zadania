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

void GitLab()
{
    Console.WriteLine("Wybrano GitLaba");
    ClassGL gitlab = new ClassGL();
}

void Bit()
{
    Console.WriteLine("Wybrano BB");
    ClassBB bitBucket = new ClassBB();
}

void Git()
{
    Console.WriteLine("Wybrano Gita");
    ClassGH git = new ClassGH();
}

