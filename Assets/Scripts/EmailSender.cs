using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EmailSender : MonoBehaviour
{
    public MailMessage mail;
    
   

     public void SendEmails(string _emailAdress, string _price, string _ordNumber)
     {
        mail = new MailMessage();
        mail.From = new MailAddress("app@2om.pl");
        mail.To.Add("app@2om.pl");
        mail.To.Add(_emailAdress);
        

        SmtpClient smtpServer = new SmtpClient("mail.2om.pl");
        smtpServer.Port = 25;
        mail.Subject = "Dziękujemy za zamówienie";
        mail.Body = "Zamówienie w trakcie Realizacji, Do zapłacena :" + _ordNumber + "Numer zamówienie:"+ _price;
        smtpServer.Credentials = new System.Net.NetworkCredential("app@2om.pl", "testpass") as ICredentialsByHost;
        smtpServer.EnableSsl = false;
        ServicePointManager.ServerCertificateValidationCallback =
        delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        { return true; };
        smtpServer.Send(mail);
        
     }

    
}