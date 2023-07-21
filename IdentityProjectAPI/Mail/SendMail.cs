using MailKit.Net.Smtp;
using MimeKit;

namespace IdentityProjectAPI.Mail
{
    public class SendMail : ISendMail
    {
        public void Send(string mail, string code)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "batuhansarikaya008@gmail.com");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail);
            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Please <a href='{code}'>click</a> to confirm your e-mail address.";
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Easy Cash Onay Kodu";
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("batuhansarikaya008@gmail.com", "iwgiaaqwllzxyjzo");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
