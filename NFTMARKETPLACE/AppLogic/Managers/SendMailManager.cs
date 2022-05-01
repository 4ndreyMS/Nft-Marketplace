using DTO_POJOS;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

        public static async Task SendDynamicMail(Validation _validation)
        {
            sendG.Token = _validation.Otp;
            sendG.ApiKey = "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";
            sendG.MailFrom = "atorress@ucenfotec.ac.cr";
            sendG.MailTo = _validation.EmailTo;
            sendG.Group = "NetQuality Group";
            sendG.EmailTitle = _validation.Title;
            sendG.MailContent = "Hello, A security code has been sent";
            sendG.HtmlContent = _validation.Msj+" ";

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

        public static async Task SendDynamicQR(Validation _validation)
        {
            SendValidationsManager genQr = new SendValidationsManager();
            genQr.GenQR(_validation.NFTAsset);

            sendG.ApiKey = "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";
            sendG.MailFrom = "atorress@ucenfotec.ac.cr";
            sendG.MailTo = _validation.EmailTo;
            sendG.Group = "NetQuality Group";
            sendG.EmailTitle = _validation.Title;
            sendG.MailContent = "Hello, QR code has been sent";
            sendG.HtmlContent = _validation.Msj + " ";

            var client = new SendGridClient(sendG.ApiKey);
            var from = new EmailAddress(sendG.MailFrom, sendG.Group);
            var subject = sendG.EmailTitle;
            var to = new EmailAddress(sendG.MailTo, sendG.Group);
            var plainTextContent = sendG.MailContent;
            var htmlContent = "<strong>" + sendG.HtmlContent + "</strong>";

            //Con el MailHelper se construye el correo
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            byte[] byteData = System.IO.File.ReadAllBytes(@"c:\imgs\QR.png");
            msg.Attachments = new List<SendGrid.Helpers.Mail.Attachment>
            {
                new SendGrid.Helpers.Mail.Attachment
                {
                    Content = Convert.ToBase64String(byteData),
                    Filename = "QR.png",
                    Type = "image/png",
                    Disposition = "attachment"
                }
            };

            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.StatusCode);


        }

    }
}
