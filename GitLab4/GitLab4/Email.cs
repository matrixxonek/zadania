using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel;

class Email
{
    public static MailMessage message = new MailMessage();
    public static MailAddress from = new MailAddress("matrixxon@gmail.com", "matrixxon");
    public static MailAddress to = new MailAddress("matrixxon@gmail.com");
    public static SmtpClient smtp = new SmtpClient("smtp.gmail.com");
    public static string password;
    public static NetworkCredential credentials;
    static string toDo = " ToDoList: " + Login.client.ToDoList.GetAsync().Result.ToString();
    static string issues = " Issues: " + Login.client.Issues.GetAsync(Login.id).Result.ToString();
    static string commits = " Commits: " + Login.client.Commits.ToString();
    static string requests = " Requests: " + Login.client.MergeRequests.GetAsync().Result.ToString();
    string change = toDo + issues + commits + requests;
    public static void setMail(string changes)
    {
        message.From = from;
        message.To.Add(to);
        message.Subject = "Your Issues changes";
        message.Body = changes;
        //message.Body = "";
        smtp.UseDefaultCredentials = false;
        credentials = new NetworkCredential("matrixxonsmtp@gmail.com", "bqcwitwhvpltcyew");
        smtp.Credentials = credentials;
        smtp.EnableSsl = true;
        smtp.Port = 587;
        smtp.Send(message);
    }

    public void SendMail(string change)
    {
        setMail(change);
    }
    Email()
    {
        SendMail(change);
    }
}

