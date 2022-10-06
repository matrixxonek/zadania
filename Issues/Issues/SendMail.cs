using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using System.Web;
using System.Net;
using Octokit;
using System.ComponentModel;

class SendMail
{
    public static MailMessage message = new MailMessage();
    public static MailAddress from = new MailAddress("matrixxon@gmail.com", "matrixxon");
    public static MailAddress to = new MailAddress("matrixxon@gmail.com");
    public static SmtpClient smtp = new SmtpClient("smtp.gmail.com");
    public static string password;
    public static NetworkCredential credentials;
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

    public SendMail(string change)
    {
        setMail(change);
    }
}
