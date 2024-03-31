using System.Net.Mail;
using System.Net;

public static class SendEmail
{

    static public void sendEmail(string name ,string tomail, string _message)
    {
        string fromMail = "steptest226@gmail.com";
        string fromPassword = "hibihdeorcokmndd";

        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);

        message.Subject = "Test";
        message.To.Add(new MailAddress(tomail));

        message.Body = $"<html><body><p style='font-size: 50px; color: black;'>Hello,<br/><br/>MessageFrom: <span style='font-weight: bold;'> {name}:\n{_message}</span></p></body></html>";

        message.IsBodyHtml = true;

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true
        };

        smtpClient.Send(message);

    }




}