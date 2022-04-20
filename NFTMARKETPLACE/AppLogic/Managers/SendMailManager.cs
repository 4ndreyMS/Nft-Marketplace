using DTO_POJOS;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace AppLogic.Managers
{
    public class SendMailManager
    {
        static SendMail sendG = new SendMail();
        public static async Task SendMail(int _otp, string _mail)
        {
            sendG.Token = _otp;
            sendG.ApiKey = "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";
            sendG.MailFrom = "atorress@ucenfotec.ac.cr";
            sendG.MailTo = _mail;
            sendG.Group = "Grupo NetQuality";
            sendG.EmailTitle = "A security code has been sent";
            sendG.MailContent = "Hello, A security code has been sent";
            sendG.HtmlContent = "Hi, verify your account with this security code ";

            var client = new SendGridClient(sendG.ApiKey);
            var from = new EmailAddress(sendG.MailFrom, sendG.Group);
            var subject = sendG.EmailTitle;
            var to = new EmailAddress(sendG.MailTo, sendG.Group);
            var plainTextContent = sendG.MailContent;
            var htmlContent = "<strong>" + sendG.HtmlContent + sendG.Token + "</strong>";

            //Con el MailHelper se construye el correo
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.StatusCode);

        }

        public static async Task SendRecoveryPassword(string _name, string _mail)
        {

            string urlRecovery = "";
            sendG.ApiKey = "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";
            sendG.MailFrom = "atorress@ucenfotec.ac.cr";
            sendG.MailTo = _mail;
            sendG.Group = "Grupo NetQuality";
            sendG.EmailTitle = "A security URL has been sent";
            sendG.MailContent = "Hello, A security URL has been sent";
            sendG.HtmlContent = "Hi " + _name + " ,changes your password " + urlRecovery;

            var client = new SendGridClient(sendG.ApiKey);
            var from = new EmailAddress(sendG.MailFrom, sendG.Group);
            var subject = sendG.EmailTitle;
            var to = new EmailAddress(sendG.MailTo, sendG.Group);
            var plainTextContent = sendG.MailContent;
            var htmlContent = "<strong>" + sendG.HtmlContent + urlRecovery + "</strong>";

            //Con el MailHelper se construye el correo
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.StatusCode);

        }
    }
}
