using System.Net;
using System.Net.Mail;
namespace WebApplication7.BL.Helpers
{
    public static class MailHelper
    {
        public static string sendMail(string Title, string Message)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587);
            smtpClient.EnableSsl=true;

            smtpClient.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");

            smtpClient.Send("abdullahsayed751@gmail.com", "as8338873@gmail.com", Title, Message);

            return "Mail is Sent Sucssfuly";
        }
    }
}
